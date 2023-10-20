using System.Runtime.InteropServices.JavaScript;
using SchoolSearch.Data;

namespace SchoolSearch.Models;

public class Student
{
    public School MySchool { get; set; }
    public string MyFirstName;
    public string MyLastName;
    public string MyGrade;
    public string MyRace;
    public string MySex;
    public DateTime MyBirthDate;
    public int MyAge;
    public List<string> MyInterests;
    public List<string> MyStruggles;
    private Random _random = new Random();

    public Student(School school)
    {
        MySchool = school;
        GenerateStudent();
    }

    private void GenerateStudent()
    {
        MyFirstName = "Stubely";
        MyLastName = "Student";
        MyGrade = GenerateGrade();
        MyRace = GenerateRace();
        MySex = GenerateSex();
        MyBirthDate = GenerateBirthdate();
        MyAge = CalculateAge();
        MyInterests = GenerateInterests();
    }
    public void UpdateFirstName(string firstname)
    {
        MyFirstName = firstname;
    }
    public void UpdateFullName(List<string> fullname)
    {
        MyFirstName = fullname[0];
        MyLastName = fullname[1];
    }
    private string GenerateRace()
    {
        string race = "Not determined";
        var target = _random.Next(MySchool.MEMBER);
        for(int i = 0; i<MySchool.DemoList().Count; i++)
        {
            target -= MySchool.DemoList()[i];
            if(target <= 0)
            {
                switch (i)
                {
                    case 0:
                        race="American Indian";
                        break;
                    case 1:
                        race="Asian";
                        break;
                    case 2:
                        race="Black";
                        break;
                    case 3:
                        race="Pacific Islander";
                        break;
                    case 4:
                        race="Hispanic";
                        break;
                    case 5:
                        race = "Two or more races";
                        break;
                    case 6:
                        race = "White";
                        break;
                    default:
                        race = "Not determined";
                        break;
                }
                break;
            }
            
        }

        return race;
    }

    private string GenerateSex()
    {
        var target = _random.Next(MySchool.MEMBER);
        string sex;
        if (target - MySchool.TOTF <= 0)
            sex = "Female";
        else
            sex = "Male";
        return sex;

    }

    private DateTime GenerateBirthdate()
    {
        //generate a birthday with a random day of the year with the year dependent on the grade of the student
        //Set school start year to the current year, or the previous year if it is before August
        //The default age is 18 - see switch statement below
        var schoolstartyear = DateTime.Now.Year;
            if(DateTime.Now.Month < 8)
            {
                schoolstartyear -= 1;
            }
        var birthyear = 0;
        //Set the birthyear based on the grade of the student
        switch (MyGrade)
        {
            case "Pre-Kindergarten":
                var ThreeOrFour = _random.Next(3,5);
                birthyear = schoolstartyear - ThreeOrFour;
                break;
            case "Kindergarten":
                birthyear = schoolstartyear - 5;
                break;
            case "First Grade":
                birthyear = schoolstartyear - 6;
                break;
            case "Second Grade":
                birthyear = schoolstartyear - 7;
                break;
            case "Third Grade":
                birthyear = schoolstartyear - 8;
                break;
            case "Fourth Grade":
                birthyear = schoolstartyear - 9;
                break;
            case "Fifth Grade":
                birthyear = schoolstartyear - 10;
                break;
            case "Sixth Grade":
                birthyear = schoolstartyear - 11;
                break;
            case "Seventh Grade":
                birthyear = schoolstartyear - 12;
                break;
            case "Eighth Grade":
                birthyear = schoolstartyear - 13;
                break;
            case "Ninth Grade":
                birthyear = schoolstartyear - 14;
                break;
            case "Tenth Grade":
                birthyear = schoolstartyear - 15;
                break;
            case "Eleventh Grade":
                birthyear = schoolstartyear - 16;
                break;
            case "Twelfth Grade":
                birthyear = schoolstartyear - 17;
                break;
            case "Ungraded":
                birthyear = schoolstartyear - 18;
                break;
            case "Adult Education":
                var adultAge = _random.Next(18, 65);
                birthyear = schoolstartyear - adultAge;
                break;
            default:
                birthyear = schoolstartyear - 18;
                break;
        }
        //Generate a random day of the year
        int dayOfYear = _random.Next(1, DateTime.IsLeapYear(birthyear) ? 367 : 366);
        //If the random day is after the schoolstart date, subtract a year from the birthyear
        if (dayOfYear > DateTime.Parse($"{schoolstartyear}-08-01").DayOfYear)
        {
            birthyear -= 1;
        }
        //convert int dayOfYear and int birthyear to a DateTime
        DateTime birthdate = new DateTime(birthyear, 1, 1).AddDays(dayOfYear - 1);
        return birthdate;
    }

    private int CalculateAge()
    {
        //return the age of the student based on the birthdate
        var today = DateTime.Today;
        var age = today.Year - MyBirthDate.Year;
        //if the birthday has not happened yet this year, subtract a year from the age
        if (MyBirthDate.Date > today.AddYears(-age)) 
            age--;
        return age;
    }

    private string GenerateGrade()
    {
        var target = _random.Next(MySchool.MEMBER);
        string grade = "Not determined";
        List<Tuple<int, string, float>> GradeLevels = MySchool.GradeLevelList();
        for (int i = 0; i < GradeLevels.Count; i++)
        {
            target -= GradeLevels[i].Item1;
            if (target <= 0)
            {
                grade = GradeLevels[i].Item2;
                break;
            }
        }
        return grade;
    }
    
    public void SetGrade(string grade)
    {
        MyGrade = grade;
        
        //Update the birthdate based on the new grade
        MyBirthDate = GenerateBirthdate();
        MyAge = CalculateAge();
        
    }

    private List<string> GenerateInterests()
    {
        StudentInterests interests = new StudentInterests();
        
        return interests.getThreeInterests(MyGrade);
    }
    
}