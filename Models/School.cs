using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.IdentityModel.Tokens;

namespace SchoolSearch.Models;

[Table("publicSchoolsTX")]
public class School
{
    public int OBJECTID { get;} = 0;
    public string LZIP { get; } = "00000";
    public string SCH_NAME { get;} = "School not found.";
    //MEMBER defaults to 1 to avoid divide by zero errors in GradeLevelList()
    public int MEMBER { get; } = 1;
    public string LCITY { get;} = "City not found.";
    public string LSTATE { get;} = "State not found.";
    public float LATCOD { get;} = 0;
    public float LONCOD { get;}= 0;
    public float TOTM { get; } = 0;
    public float TOTF { get; }=0;
    public int AM { get; } = 0;
    public int AS { get; } = 0;
    public int BL { get; } = 0;
    public int HP { get; } = 0;
    public int HI { get; } = 0;
    public int TR { get; } = 0;
    public int WH { get; } = 0;
    
    public int PK { get; } = 0;
    public int KG { get; } = 0;
    public int G01 { get; } = 0;
    public int G02 { get; } = 0;
    public int G03 { get; } = 0;
    public int G04 { get; } = 0;
    public int G05 { get; } = 0;
    public int G06 { get; } = 0;
    public int G07 { get; } = 0;
    public int G08 { get; } = 0;
    public int G09 { get; } = 0;
    public int G10 { get; } = 0;
    public int G11 { get; } = 0;
    public int G12 { get; } = 0;
    public int G13 { get; } = 0;
    public int UG { get; } = 0;
    public int AE { get; } = 0;
    
    public string SCHOOL_LEVEL { get; } = "School Level not found";


    //Create a list of Race values to be used in the Student class
    public List<int> DemoList()
    {
        return new List<int> { AM, AS, BL, HP, HI, TR, WH };
    }
    public List<Tuple<int,string,float>> GradeLevelList()
    {
        List<Tuple<int,string,float>> GradeLevels = new List<Tuple<int,string,float>>();
        if(PK > 0)
        {
            GradeLevels.Add(new Tuple<int,string,float>(PK, "Pre-Kindergarten",PK/MEMBER));
        }
        if(KG > 0)
        {
            GradeLevels.Add(new Tuple<int, string,float>(KG, "Kindergarten",KG/MEMBER));
        }
        if(G01 > 0)
        {
            GradeLevels.Add(new Tuple<int, string,float>(G01, "First Grade",G01/MEMBER));
        }
        if(G02 > 0)
        {
            GradeLevels.Add(new Tuple<int, string,float>(G02, "Second Grade",G02/MEMBER));
        }
        if(G03 > 0)
        {
            GradeLevels.Add(new Tuple<int, string,float>(G03, "Third Grade",G03/MEMBER));
        }
        if(G04 > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(G04, "Fourth Grade",G04/MEMBER));
        }
        if(G05 > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(G05, "Fifth Grade",G05/MEMBER));
        }
        if(G06 > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(G06, "Sixth Grade",G06/MEMBER));
        }
        if(G07 > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(G07, "Seventh Grade",G07/MEMBER));
        }
        if(G08 > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(G08, "Eighth Grade",G08/MEMBER));
        }
        if(G09 > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(G09, "Ninth Grade",G09/MEMBER));
        }
        if(G10 > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(G10, "Tenth Grade",G10/MEMBER));
        }
        if(G11 > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(G11, "Eleventh Grade",G11/MEMBER));
        }
        if(G12 > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(G12, "Twelfth Grade",G12/MEMBER));
        }
        if(G13 > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(G13, "Ungraded",G13/MEMBER));
        }
        if(UG > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float >(UG, "Ungraded",UG/MEMBER));
        }
        if(AE > 0)
        {
            GradeLevels.Add(new Tuple<int, string, float>(AE, "Adult Education",AE/MEMBER));
        }

        return GradeLevels;
    }

    //Convert School to SchoolSearchResult
    public SchoolSearchResult toSchoolSearchResult()
    {
        return new SchoolSearchResult()
        {
            OBJECTID = this.OBJECTID,
            SCH_NAME = this.SCH_NAME,
            LCITY = this.LCITY,
            LSTATE = this.LSTATE
        };
    }

    //The school names can be almost anything in the database, this will require some more detailed formatting to clean up fully
    public string SchoolNameCamelCase()
    {
        var schoolName = SCH_NAME.Split(" ");
        string schoolNameCamelCase = "";
        foreach (var word in schoolName)
        {
            if(word.Length > 4) 
                schoolNameCamelCase += " "+word[0].ToString().ToUpper() + word.Substring(1).ToLower();
            else
            {
                schoolNameCamelCase += " " + word;
            }
        }
       /* 
        if (!schoolName.IsNullOrEmpty())
        {
            
            schoolNameCamelCase += schoolName[0][0].ToString().ToUpper() + schoolName[0].Substring(1).ToLower();

            //No schools have abbreviations that need to be expanded on the first word
            //If a word in a school name is greater than 5 characters, assume it is not an abbreviation and case it.
            for (var i = 1; i < schoolName.Length; i++)
            {
                if(schoolName[i].Length > 4) 
                    schoolNameCamelCase += " "+schoolName[i][0].ToString().ToUpper() + schoolName[i].Substring(1).ToLower();
                else
                {
                    schoolNameCamelCase += " " + schoolName[i];
                }
            }
            //Possible final abbreviations include "EL", "PRI", "EL-SOUTH", "EL-NORTH", "INT", "CTR", "EL II", "CS", "SCH"
            //"EC/PK/PK", "YWLA", "NCC", "ACAD", "JH", "J J A E P", "ELE"
        }*/

        return schoolNameCamelCase;
    }
}

