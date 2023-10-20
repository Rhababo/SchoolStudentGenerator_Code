using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolSearch.Data;
using SchoolSearch.Models;


namespace SchoolSearch.Pages
{
    public class IndexModel : PageModel 
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly DataAccess _dataAccess;
        /// <summary>
        /// Dont' need School model type here when we can get SearchResults instead
        /// </summary>
        // public IEnumerable<School> Schools { get; set; }
        public IEnumerable<SchoolSearchResult> SearchResults { get; set; }
        public IList <string> SearchSuggestions { get; set; } = new List<string>();
        
        private ISchoolSearchResultService _schoolSearchResultService;

        [BindProperty(SupportsGet = true)] 
        public string SearchString { get; set; } = String.Empty;

        public IndexModel(ILogger<IndexModel> logger, DataAccess dataAccess, ISchoolSearchResultService schoolSearchResultService) 
        {
            // _logger = logger;
            _dataAccess = dataAccess;
            SearchResults = Enumerable.Empty<SchoolSearchResult>();
            _schoolSearchResultService = schoolSearchResultService;
        }

        public async Task<IActionResult> OnGetAsync()
       {
           await PropagateSearchResultsAsync();
          
           await InitializeSchoolList();
           //If SearchResults only has a single value, redirect to the school page
           if (SearchResults.Count() == 1)
           {
               var school = SearchResults.First();
               var schoolId = school.OBJECTID;
               return RedirectToPage("/SchoolData", new {OBJECTID = schoolId});
           }
           return Page();
       }

        public async Task<IActionResult> OnPostItems()
       {
          await PropagateSearchResultsAsync();
          var itemList = SearchSuggestions;
          return new JsonResult(itemList);
       }
       private async Task InitializeSchoolList() 
        {
            if (IsConnected())
            {
                if (SearchString == String.Empty)
                {
                    var asyncSearchResults = _dataAccess.GetLargeSchoolsAsync();
                    await foreach (var result in asyncSearchResults)
                    {
                        SearchResults.Append(result);
                    }
                }
                else
                {
                    SearchResults = await _schoolSearchResultService.GetSchoolSearchResultsAsync(SearchString);
                }
            }
            else
            {
                SearchResults = Enumerable.Empty<SchoolSearchResult>();
            }
        }
       
       //Check if database is accessible
        private bool IsConnected() 
        {
            bool connected = _dataAccess.IsDatabaseAccessible();
            return connected;
        }


        private async Task PropagateSearchResultsAsync()
        {
            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                //Clear search results before appending new ones
                SearchResults = Enumerable.Empty<SchoolSearchResult>();
                var asyncSearchResults = _dataAccess.GetSearchResultsAsync(SearchString);
                await foreach (var result in asyncSearchResults)
                {
                    SearchResults.Append(result);
                }
            }
            else
            {
                SearchResults = Enumerable.Empty<SchoolSearchResult>();
            }
            SearchSuggestions.Clear();
            foreach (var item in SearchResults)
            {
                SearchSuggestions.Add(item.GetSearchDisplay());
            }
        }
    }
}

        


        