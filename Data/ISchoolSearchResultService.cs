using SchoolSearch.Models;

namespace SchoolSearch.Data;

public interface ISchoolSearchResultService
{
    List<string> GetSearchSuggestions(string filter);
    Task<List<SchoolSearchResult>> GetSchoolSearchResultsAsync(string filter);
    
    Task<List<string>> GetSearchSuggestionsAsync(string filter);
    SchoolSearchResult Get(int id);
    
}