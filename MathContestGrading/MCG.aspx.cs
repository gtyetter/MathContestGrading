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
        protected string JuniorTie;     //Junior Tie String
        protected string SeniorTie;     //Senior Tie String
        bool JKFault = false;           //Junior Key Fault
        bool SKFault = false;           //Senior Key Fault
        bool JTFault = false;           //Junior Tie Fault
        bool STFault = false;           //Senior Tie Fault
        protected List<contestant> Junior = new List<contestant>(); //List for junior data
        protected List<contestant> Senior = new List<contestant>(); //List for senior data
        protected List<schools> School = new List<schools>(); //List for school data

        public static void parse()  //Goes through the files and puts the corresponding data in the list
        {
            List<string> JunFile = new List<string>();
            List<string> SenFile = new List<string>();

            //Input the file by line and save into a list one for junior and senior

            validateKey('J', killWhiteSpace(JunFile[0]));
            validateTie('J', killWhiteSpace(Junfile[1]));
            for(int i=2;i<JunFile.Count();i++)
            {
                killWhiteSpace(JunFile[i]);
            }
            validateKey('S', killWhiteSpace(SenFile[0]));
            validateTie('S', killWhiteSpace(SenFile[1]));
            for(int i=2;i<SenFile.Count();i++)
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

        public static List<string> killWhiteSpace(string line)
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
            return theLine;
        }

        public static void validateKey(char level, List<string> theLine)
        {
            int item = theLine.Count()-1;
            bool issue = false;
            if (theLine[item].Length()!=40)
            {
                issue = true;
            }
            else
            {
                for(int i=0;i<40;i++)
                {
                    if(theLine[item][i]!='1' || theLine[item][i]!='2' || theLine[item][i]!='3' || theLine[item][i]!='4' || theLine[item][i]!='5')
                    {
                        issue = true;
                    }
                }
            }
            if(level='J')
            {
                JuniorKey = theLine[item];
                JKFault = issue;
            }
            else
            {
                SeniorKey = theLine[item];
                SKFault = issue;
            }
        }

        public static void validateTie(char level, List<string> theLine)
        {
            int item = theLine.Count() - 1;
            bool issue = false;
            if (theLine[item].Length() != 40)
            {
                issue = true;
            }
            else
            {
                for (int i = 0; i < 40; i++)
                {
                    if (theLine[item][i] != '1' || theLine[item][i] != '2' || theLine[item][i] != '*')
                    {
                        issue = true;
                    }
                }
            }
            if (level = 'J')
            {
                JuniorTie = theLine[item];
                JTFault = issue;
            }
            else
            {
                SeniorTie = theLine[item];
                STFault = issue;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveSenoirFileBtn_Click(object sender, EventArgs e)
        {

        }

        protected void SaveJuniorFileBtn_Click(object sender, EventArgs e)
        {

        }

        protected void SaveSchoolFileBtn_Click(object sender, EventArgs e)
        {

        }
    }
}