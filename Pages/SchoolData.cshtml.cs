using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolSearch.Data;
using SchoolSearch.Models;
using System.Text.Json;


namespace SchoolSearch.Pages
{
    public class SchoolDataModel : PageModel
    {
        [BindProperty(SupportsGet = true)] 
        public int OBJECTID { get; set; }
        public string JsonSchool { get; set; }
    
        private readonly DataAccess _dataAccess;
        public School School { get; set; } = new School();

        //private SaveToSession _saveToSession;
       // private RetrieveFromSession _retrieveFromSession;
        
        public SchoolDataModel(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
           // _saveToSession = new SaveToSession(this.HttpContext.Session);
           // _retrieveFromSession = new RetrieveFromSession(dataAccess, this.HttpContext.Session);
        }

        public async Task OnGetAsync()
        {
            await InitializeSchool();
        }
        
        private Task InitializeSchool()
        {
            if(OBJECTID == 0)
                OBJECTID = HttpContext.Session.GetInt32("OBJECTID")??0;
            if (OBJECTID != 0)
            {
 
                School = _dataAccess.GetSchoolById(OBJECTID);
                if (School == null)
                {
                    //Set to default school if no school is found
                    School = new School();
                }
                HttpContext.Session.SetInt32("OBJECTID", OBJECTID);
                
            }
            JsonSchool = SerializeSchool().ToString();
            return Task.CompletedTask;
        }   
        
        private JsonResult SerializeSchool()
        {
            string json = JsonSerializer.Serialize(School,new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            });
            json.Replace("&quot;", "\"");
            return new JsonResult(json);
        }
    }
}