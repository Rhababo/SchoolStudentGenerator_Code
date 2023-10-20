using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SchoolSearch.Models;

namespace SchoolSearch.Data;    

public class DataAccess
{
    private readonly string _connectionString;

    public DataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DBConnection");
    }

    public bool IsDatabaseAccessible()
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return true;
            }
        }
        catch (Exception ex)
        {
            // Handle the exception or log the error message
            // You can examine the exception details to determine the cause of the failure
            Console.WriteLine($"Database access error: {ex.Message}");
            return false;
        }
    }
    
    public IEnumerable<SchoolSearchResult> GetLargeSchools()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var sql = "SELECT * FROM publicSchoolsTX WHERE MEMBER >= 4000";
            return connection.Query<SchoolSearchResult>(sql);
        }
    }

    public async IAsyncEnumerable<SchoolSearchResult> GetLargeSchoolsAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var sql = "SELECT * FROM publicSchoolsTX WHERE MEMBER >= 4000";
            var results = connection.Query<SchoolSearchResult>(sql);
            foreach (var result in results)
            {
                yield return result;
            }
        }
    }

    public IEnumerable<School> GetModelsByZip(string zipCode)
    {
        var dbParams = new DbString()
        {
            Value = zipCode, 
            IsAnsi=true, 
            IsFixedLength=true, 
            Length=5
        };
        return GetModelsByFilter("*", "LZIP", dbParams);
    }

    public School GetSchoolById(int OBJECTID)
    {
        var dbParams = new DbString()
        {
            Value = OBJECTID.ToString(), 
            IsAnsi=true,
        };
        return GetModelsByFilter("*", "OBJECTID", dbParams).FirstOrDefault();
    }
    
    public async IAsyncEnumerable<School> GetSchoolByIdAsync(int OBJECTID)
    {
        var dbParams = new DbString()
        {
            Value = OBJECTID.ToString(), 
            IsAnsi=true,
        };
        var results = GetModelsByFilterAsync("*", "OBJECTID", dbParams);
        await foreach (var result in results)
        {
            //send only the first value
            yield return result;
            break;
        }
            
    }
    
    //Query the database for a school by a given column and value
    private IEnumerable<School> GetModelsByFilter(string column, string filter, Dapper.DbString dbparams)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"SELECT {column} FROM publicSchoolsTX WHERE {filter} = @ColumnValue";
            return connection.Query<School>(sql, new{ColumnValue = dbparams});
        }
    }
    
    private async IAsyncEnumerable<School> GetModelsByFilterAsync(string column, string filter, Dapper.DbString dbparams)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"SELECT {column} FROM publicSchoolsTX WHERE {filter} = @ColumnValue";
            var results = connection.Query<School>(sql, new{ColumnValue = dbparams});
            foreach (var result in results)
            {
                yield return result;
            }
        }
    }
    
    //Query the database for a school by two given columns and values
    private async IAsyncEnumerable<School> GetModelsByTwoFiltersAsync(string column1, string filter1, string filter2, Dapper.DbString dbparams1, Dapper.DbString dbparams2)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"SELECT {column1} FROM publicSchoolsTX WHERE {filter1} = @ColumnValue AND {filter2} = @ColumnValue2";
            var results= connection.Query<School>(sql, new{ColumnValue = dbparams1, ColumnValue2 = dbparams2});
            foreach (var result in results)
            {
                yield return result;
            }
        }
    }
    

    public IEnumerable<SchoolSearchResult> GetSearchResults(string searchEntry)
    {
        var dbParams = new DbString()
        {
            Value = "\""+searchEntry+"*\"", 
            IsAnsi=true,
        };
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"EXEC SchoolSearchBar @searchterm";
            return connection.Query<SchoolSearchResult>(sql, new{searchterm = dbParams});
        }
    }

    public async IAsyncEnumerable<SchoolSearchResult> GetSearchResultsNameAndCityAsync (string sch_name, string city)
    {
        var dbParams1 = new DbString()
        {
            Value = sch_name, 
            IsAnsi=true,
        };
        var dbParams2 = new DbString()
        {
            Value = city, 
            IsAnsi=true,
        };
        var results =  GetModelsByTwoFiltersAsync("*", "SCH_NAME", "LCITY", dbParams1, dbParams2);
        await foreach (var result in results)
        {
            yield return result.toSchoolSearchResult();
        }
    }
    public async IAsyncEnumerable<SchoolSearchResult> GetSearchResultsAsync(string searchEntry)
    {
        var dbParams = new DbString()
        {
            Value = "\""+searchEntry+"*\"", 
            IsAnsi=true,
        };
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sql = $"EXEC SchoolSearchBar @searchterm";
            var results =  connection.Query<SchoolSearchResult>(sql, new { searchterm = dbParams });
            foreach (var result in results)
            {
                yield return result;
            }
        }
    }

    public async Task<String> GetFirstNameAsync(string sex, string race)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string table = "";
            if (sex == "Female")
            {
                switch (race)
                {
                    case "White":
                        table = "first_NameWHIF";
                        break;
                    case "Black":
                        table = "first_NameBLAF";
                        break;
                    case "Hispanic":
                    table = "first_NAMEHISF";
                        break;
                    case "Asian":
                        table = "first_NAMEASIF";
                        break;
                    default:
                        table = "first_NameOTHF";
                        break;
                }
            }
            else
            {
                switch (race)
                {
                    case "White":
                        table = "first_NameWHIM";
                        break;
                    case "Black":
                        table = "first_NameBLAM";
                        break;
                    case "Hispanic":
                        table = "first_NAMEHISM";
                        break;
                    case "Asian":
                        table = "first_NAMEASIM";
                        break;
                    default:
                        table = "first_NameOTHM";
                        break;
                }
            }
            
            string sql = @"DECLARE @randvar int = RAND()*(SELECT MAX(namerank) FROM "+table+@"); 
                         SELECT name FROM "+table+ @" WHERE namerank >= @randvar AND namerank - @randvar < namevalue";
            
            var result = connection.Query<string>(sql,null).FirstOrDefault();
            return result;
        }
    }
    
    public async Task<List<String>> GetFullNameAsync(string sex, string race)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string fnametable;
            string surnametable;
            if (sex == "Female")
            {
                switch (race)
                {
                    case "White":
                        fnametable = "first_NameWHIF";
                        surnametable = "surname_WHI";
                        break;
                    case "Black":
                        fnametable = "first_NameBLAF";
                        surnametable = "surname_BLA";
                        break;
                    case "Hispanic":
                        fnametable = "first_NAMEHISF";
                        surnametable = "surname_HIS";
                        break;
                    case "Asian":
                        fnametable = "first_NAMEASIF";
                        surnametable = "surname_ASI";
                        break;
                    case "American Indian":
                        fnametable = "first_NameOTHF";
                        surnametable = "surname_AIAN";
                        break;
                    case "Pacific Islander":
                        fnametable = "first_NameOTHF";
                        surnametable = "surname_ASI";
                        break;
                    default:
                        fnametable = "first_NameOTHF";
                        surnametable = "surname_TWO";
                        break;
                }
            }
            else
            {
                switch (race)
                {
                    case "White":
                        fnametable = "first_NameWHIM";
                        surnametable = "surname_WHI";
                        break;
                    case "Black":
                        fnametable = "first_NameBLAM";
                        surnametable = "surname_BLA";
                        break;
                    case "Hispanic":
                        fnametable = "first_NAMEHISM";
                        surnametable = "surname_HIS";
                        break;
                    case "Asian":
                        fnametable = "first_NAMEASIM";
                        surnametable = "surname_ASI";
                        break;
                    case "American Indian":
                        fnametable = "first_NameOTHM";
                        surnametable = "surname_AIAN";
                        break;
                    case "Pacific Islander":
                        fnametable = "first_NameOTHM";
                        surnametable = "surname_ASI";
                        break;
                    default:
                        fnametable = "first_NameOTHM";
                        surnametable = "surname_TWO";
                        break;
                }
            }
            
            string fnamesql = @"DECLARE @randvar int = RAND()*(SELECT MAX(namerank) FROM "+fnametable+@"); 
                         SELECT name FROM "+fnametable+ @" WHERE namerank >= @randvar AND namerank - @randvar < namevalue";

            string surnamesql = @"DECLARE @randvar int = RAND()*(SELECT MAX(namerank) FROM " + surnametable + @"); 
                         SELECT name FROM " + surnametable + @" WHERE namerank >= @randvar AND namerank - @randvar < namevalue";
                
            var fnameresult = connection.Query<string>(fnamesql,null).FirstOrDefault();
            var surnameresult = connection.Query<string>(surnamesql,null).FirstOrDefault();
            
            var result = new List<string>() {fnameresult, surnameresult};
            return result;
        }
    }
    
}
