using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolSearch.Models;
using SchoolSearch.Data;

namespace SchoolSearch.Pages;

public class StudentGeneratorModel : PageModel
{
    public Student Student { get; set; } = new Student(new School());

    public List<Student> Classroom { get; set; } = new List<Student>();

    [BindProperty(SupportsGet = true)]
    public int OBJECTID { get; set; } = 0;
    
    [BindProperty]
    public School School { get; set; } = new School();
    
    public bool StudentGenerated { get; set; } = false;

    private DataAccess _dataAccess;
   // private RetrieveFromSession _retrieveFromSession;
    
    public StudentGeneratorModel(DataAccess dataAccess)
    {
        _dataAccess = dataAccess;
       // _retrieveFromSession = new RetrieveFromSession(dataAccess, this.HttpContext.Session);
    }
    
    public async Task OnGetAsync()
    {
        if(OBJECTID == 0)
            OBJECTID = HttpContext.Session.GetInt32("OBJECTID")??0;
        if (OBJECTID != 0)
        {
            var results = _dataAccess.GetSchoolByIdAsync(OBJECTID);
            //Check if school was found using default value for MEMBER
            await foreach(var result in results)
            {
                School = result;
                if (School.MEMBER > 1)
                {
                    await UpdateStudentAsync();
                }
                //only operate on first or default value;
                break;
            }   
        }
        if (School.MEMBER > 1)
        {
            await UpdateStudentAsync();
        }
        else
        {
            //StudentGenerated remains false;
            StudentGenerated = false;
        }
        
    }
    private async Task UpdateStudentAsync()
    {
        Student = await GenerateStudentAsync();
        StudentGenerated = true;
        return;
    }
    private async Task<Student> GenerateStudentAsync()
    {
        Student stu = new Student(School);
        await Task.Run(()=>stu.UpdateFullName(_dataAccess.GetFullNameAsync(stu.MySex,stu.MyRace).Result));
        return stu;
    }
    
    //Should this go in the schools class?
    public List<string> getGradeLevelStrings()
    {
        List<string> gradeLevelStrings = new List<string>();
        foreach (var gradeLevel in School.GradeLevelList())
        {
            gradeLevelStrings.Add(gradeLevel.Item2);
        }

        return gradeLevelStrings;
    }
    
}