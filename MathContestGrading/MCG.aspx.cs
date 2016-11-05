using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathContestGrading
{
    public partial class MCG : System.Web.UI.Page
    {
        protected class contestant
        {
            #region FunctionDefs
            string Name;
            string ClassCode;   //41, 49, 51, 59
            string Classy;   //Junior or Senior     //Can't use "class" so "classy" instead
            string Level;   //AA or A
            string SchoolCode;  //Which school they come from
            string SchoolName;  //Name of the school they came from
            string Answers; //The raw answers from the student

            int Score;
            #endregion FunctionDefs

            #region Constructor/Destructor
            //Constructor
            contestant(string name, string classcode, string schoolcode, string answers)
            {
                Name=name;
                ClassCode=classcode;
                SchoolCode=schoolcode;
                Answers=answers;
            }

            //Destructor
            ~contestant()
            {
                //Purposefully left blank
            }
            #endregion Constructor/Destructor

            #region Getters
            //Returns Name
            string returnName()
            {
                return Name;
            }

            //Returns Class Code
            string returnClassCode()
            {
                return ClassCode;
            }

            //Returns School Code
            string returnSchoolCode()
            {
                return SchoolCode;
            }

            //Returns Raw Answers
            string returnAnswers()
            {
                return Answers;
            }
            #endregion Getters

            #region Setters
            //Updates Name
            void updateName(string name)
            {
                Name = name;
            }

            //Updates Class Code
            void updateClassCode(string classcode)
            {
                ClassCode = classcode;
            }

            //Updates Class (Junior or Senior)
            void updateClass(string classy)
            {
                Classy = classy;
            }

            //Updates Level (AA or A)
            void updateLevel(string level)
            {
                Level=level;
            }

            //Updates School Code
            void updateSchoolCode(string schoolcode)
            {
                SchoolCode = schoolcode;
            }

            //Updates School Name
            void updateSchoolName(string schoolname)
            {
                SchoolName = schoolname;
            }

            //Update Answers
            void updateAnswers(string answers)
            {
                Answers = answers;
            }

            //Update Score
            void updateScore(int score)
            {
                Score = score;
            }
            #endregion Setters

        }

        protected class schools
        {

        }

        protected string JuniorKey;     //Junior Key String
        protected string SeniorKey;     //Senior Key String
        protected List<contestant> Junior = new List<contestant>(); //List for junior data
        protected List<contestant> Senior = new List<contestant>(); //List for senior data
        protected List<schools> School = new List<schools>(); //List for school data

        public static void parse()  //Goes through the files and puts the corresponding data in the list
        {
            List<string> JunFile = new List<string>();
            List<string> SenFile = new List<string>();

            //Input the file by line and save into a list one for junior and senior
            for(int i=0;i<JunFile.Count();i++)
            {
                killWhiteSpace(JunFile[i]);
            }
            for(int i=0;i<SenFile.Count();i++)
            {
                killWhiteSpace(SenFile[i]);
            }

        }

        public static void validate()   //Called from parse, ensures data integrity
        {

        }

        public static void grade()  //Takes the scores from the students and calculates the grade
        {

        }

        public static void killWhiteSpace(string line)
        {
            List<string> theLine = new List<string>();
            string theWord="";
            int counter = 0;
            for(int i=0;i<line.Length;i++)
            {
                if (line[i] != ' ' && line[i] != '\t')
                {
                    theWord += line[i].ToString();
                    counter++;
                }
                else if ((line[i] == ' ' || line[i] == '\t') && counter > 0)
                {
                    theLine.Add(theWord);
                    theWord = "";
                    counter = 0;
                }
            }
            theLine.Add(theWord);
            validate();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveSeniorFileBtn_Click(object sender, EventArgs e)
        {
            string FilePath = @"\Uploads\";
            string AppPath = Request.PhysicalApplicationPath;

            if (SeniorFileUpload.HasFile)
            {
                string SavePath = AppPath + FilePath + Server.HtmlEncode(SeniorFileUpload.FileName);
                SeniorFileUpload.SaveAs(SavePath);
            }
        }

        protected void SaveJuniorFileBtn_Click(object sender, EventArgs e)
        {
            string FilePath = @"\Uploads\";
            string AppPath = Request.PhysicalApplicationPath;

            if (JuniorFileUpload.HasFile)
            {
                string SavePath = AppPath + FilePath + Server.HtmlEncode(JuniorFileUpload.FileName);
                SeniorFileUpload.SaveAs(SavePath);
            }
        }

        protected void SaveSchoolFileBtn_Click(object sender, EventArgs e)
        {
            string FilePath = @"\Uploads\";
            string AppPath = Request.PhysicalApplicationPath;

            if (SchoolFileUpload.HasFile)
            {
                string SavePath = AppPath + FilePath + Server.HtmlEncode(SchoolFileUpload.FileName);
                SeniorFileUpload.SaveAs(SavePath);
            }
        }
    }
}