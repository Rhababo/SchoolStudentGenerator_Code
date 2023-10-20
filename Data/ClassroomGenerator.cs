using SchoolSearch.Models;

namespace SchoolSearch.Data;

public class ClassroomGenerator : IClassroomGenerator
{
    public int SchoolId { get; set; }
    private readonly DataAccess _dataAccess;
    private List<Student> _classroom = new List<Student>();
    private School MySchool { get; set; } = new School();
    private Random _random = new Random();
    
    public ClassroomGenerator(DataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    private async Task GenerateClassroomAsync(int schoolId, int size)
    {
        MySchool = _dataAccess.GetSchoolById(schoolId);
        _classroom.Clear();
        for(int i=0;i<size;i++)
        {
            _classroom.Add(new Student(MySchool));
        }
        foreach(var student in _classroom)
        {
            student.UpdateFullName(await _dataAccess.GetFullNameAsync(student.MySex,student.MyRace));
        }
    }

    public async Task<List<StudentCard>> GetClassroomAsync(int schoolId, int size, string grade="Random")
    {
        if (grade == "Random")
        {
            await GenerateClassroomAsync(schoolId, size);
        }
        else
        {
            await GenerateGradeLevelClassroomAsync(schoolId, size, grade);
        }
        List<StudentCard> classCards = new List<StudentCard>();
        foreach(var stu in _classroom)
        {
            classCards.Add(new StudentCard(stu));
        }
        return classCards;
    }

    public async Task GenerateGradeLevelClassroomAsync(int schoolId, int size, string grade)
    {
        MySchool = _dataAccess.GetSchoolById(schoolId);
        _classroom.Clear();
        //Use grade string to determine grade level
        //If grade string starts with "Mostly", then generate a classroom with 85% that grade level
        //and 15% random other grade levels at the school.
        List<Tuple<int, string, float>> gradeList = MySchool.GradeLevelList();
        //check that the grade is present at the school
        
        int targetGrade = -1;
        if (grade.StartsWith("Mostly"))
        {
            for(int i=0;i<gradeList.Count;i++)
            {
                if(gradeList[i].Item2 == grade.Substring(7))
                {
                    targetGrade = i;
                    break;
                }
            }
        }
        else
        {
            for(int i=0;i<gradeList.Count;i++)
            {
                if(gradeList[i].Item2 == grade)
                {
                    targetGrade = i;
                    break;
                }
            }
        }
        //if targetGrade was not found, then throw an exception
        //print the exception message to the console and exit the method
       try{
           if(targetGrade < 0)
           {
               throw new Exception("Grade level not found at school");
           }
         }
         catch(Exception e)
         {
             Console.WriteLine(e.Message);
             return;
         }
       
        if(grade.StartsWith("Mostly"))
        {
            for(int i=0;i<size;i++)
            {
                if(_random.Next(100) < 80)
                {
                    Student nextStudent = new Student(MySchool);
                    nextStudent.SetGrade(gradeList[targetGrade].Item2);
                    _classroom.Add(nextStudent);
                }
                else
                {
                    Student nextStudent = new Student(MySchool);
                    //Set random grade level to one above or one below the target grade level
                    //Assume school has consecutive grade levels
                    int minGrade = targetGrade - 1;
                    if (targetGrade == 0)
                    {
                        minGrade = 0;
                    }
                    int maxGrade = targetGrade+1;
                    if (targetGrade == gradeList.Count - 1)
                    {
                        maxGrade = targetGrade;
                    }
                    nextStudent.SetGrade(gradeList[_random.Next(minGrade,maxGrade+1)].Item2);
                    _classroom.Add(nextStudent);
                }
            }
        }
        else
        {
            for(int i=0;i<size;i++)
            {
                Student nextStudent = new Student(MySchool);
                nextStudent.SetGrade(grade);
                _classroom.Add(nextStudent);
            }
        }
        foreach(var student in _classroom)
        {
            student.UpdateFullName(await _dataAccess.GetFullNameAsync(student.MySex,student.MyRace));
        }
        
    }
    
}