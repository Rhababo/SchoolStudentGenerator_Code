using SchoolSearch.Models;

namespace SchoolSearch.Data;

public class RetrieveFromSession //: IRetrieveFromSession
{
    private readonly DataAccess _dataAccess;
    private ISession _session;
    public RetrieveFromSession(DataAccess dataAccess, ISession session)
    {
        _dataAccess = dataAccess;
        _session = session;
    }
    public School GetSchoolFromSession()
    {
            var schoolId = GetSchoolIdFromSession();
            return GetSchoolFromDatabase(schoolId);
    }
    public int GetSchoolIdFromSession()
    {
        var schoolId = _session.GetInt32("OBJECTID")??0;
        return schoolId;
    }
    private School GetSchoolFromDatabase(int OBJECTID)
    {
        return _dataAccess.GetSchoolById(OBJECTID);
    }
}
