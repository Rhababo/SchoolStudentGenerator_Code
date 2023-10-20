using SchoolSearch.Models;

namespace SchoolSearch.Data;

public interface IClassroomGenerator
{
    public int SchoolId { get; set; }
    Task<List<StudentCard>> GetClassroomAsync(int schoolId, int size, string grade="Random");

}