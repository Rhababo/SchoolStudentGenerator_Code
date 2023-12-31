namespace SchoolSearch.Models;

//The studentCard class is generated by the ClassroomGenerator API which returns List<studentCard> 
//for the StudentGenerator page to display
public class StudentCard
{
    public string MyFirstName { get; set; }
    public string MyLastName { get; set; }
    public string MyGrade { get; set; }
    public string MyRace { get; set; }
    public string MySex { get; set; }
    private DateTime MyBirthDate;
    public string MyBirthDayString { get { return MyBirthDate.ToString("M"); } }
    public int MyAge { get; set; }
    public string MySchoolName { get; set; }
    public List<string> MyInterests { get; set; }

    //StudentCard constructor requires an pre-generated student
    public StudentCard(Student generatedStudent)
    {
        MyFirstName = generatedStudent.MyFirstName;
        MyLastName = generatedStudent.MyLastName;
        MyGrade = generatedStudent.MyGrade;
        MyRace = generatedStudent.MyRace;
        MySex = generatedStudent.MySex;
        MyBirthDate = generatedStudent.MyBirthDate;
        MyAge = generatedStudent.MyAge;
        MySchoolName = generatedStudent.MySchool.SCH_NAME;
        MyInterests = generatedStudent.MyInterests;
    }
    
}