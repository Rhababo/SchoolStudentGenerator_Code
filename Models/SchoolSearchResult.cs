using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSearch.Models;

//It may be better to use a different class for the search results, 
//As the school class can get bloated with info
[Table("publicSchoolsTX")]
public class SchoolSearchResult
{
    public int OBJECTID { get; set; }
    public string LZIP { get; set;  } = string.Empty;
    public string LCITY { get; set; } = string.Empty;
    public string SCH_NAME { get; set; } = string.Empty;
    public string LSTATE { get; set; } = string.Empty;

    public string GetSearchDisplay()
    {
        return SCH_NAME+", "+LCITY+", "+LSTATE;
    }
}