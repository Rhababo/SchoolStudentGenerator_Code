namespace SchoolSearch.Data;

public class SaveToSession //: ISaveToSession
{
    private ISession _session;
    public SaveToSession(ISession session)
    {
        _session = session;
    }
    public void SaveSchoolIdToSession(int OBJECTID)
    {
        _session.SetInt32("OBJECTID", OBJECTID);
    }
   
}



