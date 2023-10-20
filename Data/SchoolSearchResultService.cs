using SchoolSearch.Models;

namespace SchoolSearch.Data;

public class SchoolSearchResultService : ISchoolSearchResultService
{
    private readonly DataAccess _dataAccess; 
    private List<SchoolSearchResult> _searchResults = new List<SchoolSearchResult>();

    public SchoolSearchResultService(DataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    //Return a list of the suggestions for autocomplete
    //Should be run after GetSchoolSearchResults()
    //May complete before GetSchoolSearchResults() (not async)
    public List<string> GetSearchSuggestions(string filter = "")
    {
        List<string> suggestions = new List<string>();
        foreach (var result in _searchResults)
        {
            suggestions.Add(result.GetSearchDisplay());
        }

        return suggestions;
    }

    public async Task<List<SchoolSearchResult>> GetSchoolSearchResultsAsync(string filter)
    {
        _searchResults.Clear();
        //If only 2 or fewer characters are entered keep search results as empty
        if(filter.Length >= 3)
        {
            //if filter contains a comma, split it into two strings
            if (filter.Contains(","))
            {
                //split filter into school name, city, and state (if present)
                var splitFilter = filter.Split(",");
                var schoolName = splitFilter[0].Trim();
                var schoolCity = splitFilter[1].Trim();
                
                //propagate search results from SQL database (accessed through DataAccess)
                var resultsNameAndCity = await Task.Run(() => _dataAccess.GetSearchResultsNameAndCityAsync(schoolName, schoolCity));
                await foreach (var result in resultsNameAndCity)
                {
                    _searchResults.Add(result);
                }
            }
            else
            {
                //propagate search results from SQL database (accessed through DataAccess)
                var results = await Task.Run(() => _dataAccess.GetSearchResultsAsync(filter));
                await foreach (var result in results)
                {
                    _searchResults.Add(result);
                }
            }
        }
        return _searchResults;
    }
    //Async version of GetSearchSuggestions(), forces call to GetSchoolSearchResultsAsync()
    public async Task<List<string>> GetSearchSuggestionsAsync(string filter)
    {
        await GetSchoolSearchResultsAsync(filter);
        List<string> suggestions = new List<string>();
        foreach (var result in _searchResults)
        {
            suggestions.Add(result.GetSearchDisplay());
        }

        return suggestions;
    }

    //Leaving this unimplemented for now
    public SchoolSearchResult Get(int id)
    {
        throw new NotImplementedException();
    }
}