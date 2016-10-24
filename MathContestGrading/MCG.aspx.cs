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

        protected List<contestant> Junior = new List<contestant>(); //List for junior data
        protected List<contestant> Senior = new List<contestant>(); //List for senior data

        public static void parse()  //Goes through the files and puts the corresponding data in the list
        {

        }

        public static void validate()   //Called from parse, ensures data integrity
        {

        }

        public static void grade()  //Takes the scores from the students and calculates the grade
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}