using SchoolSearch.Models;
namespace SchoolSearch.Data;

public interface IRetrieveFromSession
{
    public School GetSchoolFromSession();
    public int GetSchoolIdFromSession();
}