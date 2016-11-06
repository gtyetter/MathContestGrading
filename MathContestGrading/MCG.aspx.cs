using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MathContestGrading
{
    public partial class MCG : System.Web.UI.Page
    {
        public class contestant
        {
            #region FunctionDefs
            string Name;
            string ClassCode;   //41, 49, 51, 59
            string Classy;   //Junior or Senior     //Can't use "class" so "classy" instead
            string Level;   //AA or A
            string SchoolCode;  //Which school they come from
            string SchoolName;  //Name of the school they came from
            string Answers; //The raw answers from the student

            bool NameFlaw = false;
            bool ClassFlaw = false;
            bool LevelFlaw = false;
            bool SchoolCodeFlaw = false;
            bool AnswersFlaw = false;

            double Score;
            #endregion FunctionDefs

            #region Constructor/Destructor
            //Constructor
            public contestant(string name, string classcode, string schoolcode, string answers)
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
            //Returns Score
            public double returnScore()
            {
                return Score;
            }

            //Returns Name
            public string returnName()
            {
                return Name;
            }

            //Returns Class Code
            public string returnClassCode()
            {
                return ClassCode;
            }

            //Returns School Code
            public string returnSchoolCode()
            {
                return SchoolCode;
            }

            //Returns Raw Answers
            public string returnAnswers()
            {
                return Answers;
            }

            //Returns the Error String
            public string returnErrString()
            {
                string it = "";
                if(NameFlaw||ClassFlaw||LevelFlaw||SchoolCodeFlaw||AnswersFlaw)
                {
                    it += "ERR";
                }
                else
                {
                    it += "OK ";
                }

                it += " " + returnName() + "\t\t" + returnClassCode() + " " + returnSchoolCode() + " " + returnAnswers();

                return it;
            }
            #endregion Getters

            #region Setters
            //Updates Name
            public void updateName(string name)
            {
                Name = name;
            }

            //Updates Class Code
            public void updateClassCode(string classcode)
            {
                ClassCode = classcode;
            }

            //Updates Class (Junior or Senior)
            public void updateClass(string classy)
            {
                Classy = classy;
            }

            //Updates Level (AA or A)
            public void updateLevel(string level)
            {
                Level=level;
            }

            //Updates School Code
            public void updateSchoolCode(string schoolcode)
            {
                SchoolCode = schoolcode;
            }

            //Updates School Name
            public void updateSchoolName(string schoolname)
            {
                SchoolName = schoolname;
            }

            //Update Answers
            public void updateAnswers(string answers)
            {
                Answers = answers;
            }

            //Update Score
            public void updateScore(double score)
            {
                Score = score;
            }

            public void updateErr(bool name, bool classy, bool level, bool school, bool answers)
            {
                NameFlaw = name;
                ClassFlaw = classy;
                LevelFlaw = level;
                SchoolCodeFlaw = school;
                AnswersFlaw = answers;
            }
            #endregion Setters

        }

        public class school
        {
            string Number;
            string Name;
            List<contestant> SeniorContestant = new List<contestant>();
            List<contestant> JuniorContestant = new List<contestant>();


            //Constructor
            #region Constructor/Destructor
            public school(string number, string name){
                Number = number;
                Name = name;
            }

            //Destructor
            ~school() { }

            #endregion Constructor/Destructor

            //Getters
            #region Getters

            public string GetNumber() { return Number; }
            public string GetName() { return Name; }
            public List<contestant> GetSeniorList() { return SeniorContestant; }
            public List<contestant> GetJuniorList() { return JuniorContestant; }
            public contestant GetJunStudent(int i) { return JuniorContestant[i]; }
            public contestant GetSenStudent(int i) { return SeniorContestant[i]; }
            public int jlen() { return JuniorContestant.Count; }
            public int slen() { return SeniorContestant.Count; }

            #endregion Getters

            //Setters
            #region Setters

            public void UpdateNumber(string number) { Number = number; }
            public void UpdateName(string name) { Name = name; }
            public void AddSenior(contestant them) { SeniorContestant.Add(them); }
            public void AddJunior(contestant them) { JuniorContestant.Add(them); }

            #endregion Setters
        }

        string JuniorKey;     //Junior Key String
        string SeniorKey;     //Senior Key String
        string JuniorTie;     //Junior Tie String
        string SeniorTie;     //Senior Tie String
        bool JKFault = false;           //Junior Key Fault
        bool SKFault = false;           //Senior Key Fault
        bool JTFault = false;           //Junior Tie Fault
        bool STFault = false;           //Senior Tie Fault
        List<contestant> Junior = new List<contestant>();   //List for junior data
        List<contestant> Senior = new List<contestant>();   //List for senior data
        List<school> School = new List<school>();         //List for school data

        List<string> JunErrorList = new List<string>();      //List of all Juniors and saying ok or error.
        List<string> SenErrorList = new List<string>();      //List of all Seniors and saying ok or error.

        public void parse()  //Goes through the files and puts the corresponding data in the list
        {   

            //Input the file by line and save into a list one for junior and senior
            List<string> SenFile = File.ReadAllLines(SeniorFileUpload.FileName).ToList();
            List<string> JunFile = File.ReadAllLines(JuniorFileUpload.FileName).ToList();
            List<string> SchoolFile = File.ReadAllLines(SchoolFileUpload.FileName).ToList(); 

            //Does the key and tiebreakers then populates the student files
            validateKey('J', killWhiteSpace(JunFile[0]));
            validateTie('J', killWhiteSpace(JunFile[1]));
            for(int i=2;i<JunFile.Count();i++)
            {
                validate('J', killWhiteSpace(JunFile[i]));
            }
            validateKey('S', killWhiteSpace(SenFile[0]));
            validateTie('S', killWhiteSpace(SenFile[1]));
            for(int i=2;i<SenFile.Count();i++)
            {
                validate('S', killWhiteSpace(SenFile[i]));
            }
            
            //Creates the error strings for juniors and seniors
            if(JKFault)
            {
                JunErrorList.Add("ERR " + JuniorKey);
            }
            else
            {
                JunErrorList.Add("OK  " + JuniorKey);
            }
            if (SKFault)
            {
                SenErrorList.Add("ERR " + SeniorKey);
            }
            else
            {
                SenErrorList.Add("OK  " + SeniorKey);
            }

            if (JTFault)
            {
                JunErrorList.Add("ERR " + JuniorTie);
            }
            else
            {
                JunErrorList.Add("OK  " + JuniorTie);
            }
            if (STFault)
            {
                SenErrorList.Add("ERR " + SeniorTie);
            }
            else
            {
                SenErrorList.Add("OK  " + SeniorTie);
            }

            for (int i=0;i<Junior.Count;i++)
            {
                JunErrorList.Add(Junior[i].returnErrString());
            }
            for (int i = 0; i < Senior.Count; i++)
            {
                SenErrorList.Add(Senior[i].returnErrString());
            }
        }

        public void validate(char fileFrom, List<string> theLine)   //Called from parse, ensures data integrity
        {
            int i = 0;
            string Name = "";
            string CLCode = "";
            string SCode = "";
            string ans = "";

            bool nameFlaw = false;
            bool classFlaw = false;
            bool levelFlaw = false;
            bool schoolCodeFlaw = false;
            bool answersFlaw = false;
            
            while(i<theLine.Count() || theLine[i]!="41" || theLine[i]!="49" || theLine[i]!="51" || theLine[i]!="59" || theLine[i].Length!=40)
            {
                Name = Name + " " + theLine[i];
                i++;
            }

            if(i==0)
            {
                nameFlaw = true;
            }

            if (i >= theLine.Count() || theLine[i] != "41" || theLine[i] != "49" || theLine[i] != "51" || theLine[i] != "59")
            {
                classFlaw = true;
                levelFlaw = true;
            }
            else
            {
                CLCode = theLine[i];
            }

            i++;

            if (i >= theLine.Count() || theLine[i].Length != 6)
            {
                schoolCodeFlaw = true;
            }
            else
            {
                SCode = theLine[i];
            }
            i++;

            if(i >= theLine.Count() || theLine[i].Length != 40)
            {
                answersFlaw = true;
            }
            else
            {
                for(int j=0;j<40;j++)
                {
                    if(theLine[i][j] != '1' || theLine[i][j] != '2' || theLine[i][j] != '3' || theLine[i][j] != '4' || theLine[i][j] != '5' || theLine[i][j] != '*')
                    {
                        answersFlaw = true;
                    }
                }
                if(!answersFlaw)
                {
                    ans = theLine[i];
                }
            }

            if(classFlaw || levelFlaw)
            {
                if(fileFrom=='J')
                {
                    Junior.Add(new contestant(Name, CLCode, SCode, ans));
                    Junior[Junior.Count()-1].updateErr(nameFlaw,classFlaw,levelFlaw, schoolCodeFlaw, answersFlaw);
                }
                else
                {
                    Senior.Add(new contestant(Name, CLCode, SCode, ans));
                    Senior[Senior.Count() - 1].updateErr(nameFlaw, classFlaw, levelFlaw, schoolCodeFlaw, answersFlaw);
                }
            }
            else
            {
                if(CLCode[0]=='4')
                {
                    Junior.Add(new contestant(Name, CLCode, SCode, ans));
                    Junior[Junior.Count() - 1].updateErr(nameFlaw, classFlaw, levelFlaw, schoolCodeFlaw, answersFlaw);
                }
                else
                {
                    Senior.Add(new contestant(Name, CLCode, SCode, ans));
                    Senior[Senior.Count() - 1].updateErr(nameFlaw, classFlaw, levelFlaw, schoolCodeFlaw, answersFlaw);
                }
            }

        }

        public void grade()  //Takes the scores from the students and calculates the grade
        {
            for(int i=0;i<Junior.Count;i++)
            {
                Junior[i].updateScore(compare(Junior[i].returnAnswers(), JuniorKey, JuniorTie));
            }

            for (int i = 0; i < Senior.Count; i++)
            {
                Senior[i].updateScore(compare(Senior[i].returnAnswers(), SeniorKey, SeniorTie));
            }
        }

        public double compare(string answers, string key, string tie)
        {
            double grade = 0;
            for (int i = 0; i < 40;i++)
            {
                if(answers[i]==key[i])
                {
                    if(tie[i]=='1')
                    {
                        grade = grade + 1.01;
                    }
                    else if(tie[i]=='2')
                    {
                        grade = grade + 1.0001;
                    }
                    else
                    {
                        grade = grade + 1.0;
                    }
                }
            }
            return grade;
        }

        public List<string> killWhiteSpace(string line)
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

        public void validateKey(char level, List<string> theLine)
        {
            int item = theLine.Count()-1;
            bool issue = false;
            if (theLine[item].Length!=40)
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
            if(level=='J')
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

        public void validateTie(char level, List<string> theLine)
        {
            int item = theLine.Count() - 1;
            bool issue = false;
            if (theLine[item].Length != 40)
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
            if (level == 'J')
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

        public void printErrBoxes()
        {
            string JString = "";
            string SString = "";
            for(int i=0;i<JunErrorList.Count;i++)
            {
                JString = JString + JunErrorList[i] + "\n";
            }
            for(int i=0;i<SenErrorList.Count;i++)
            {
                SString = SString + SenErrorList[i] + "\n";
            }
            Console.Write(JString);
            Console.ReadKey();
            Console.Write(SString);
            Console.ReadKey();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveFileBtn_Click(object sender, EventArgs e)
        {
            string FilePath = @"\Uploads\";
            string AppPath = Request.PhysicalApplicationPath;

            if (SeniorFileUpload.HasFile)
            {
                string SavePath = AppPath + FilePath + Server.HtmlEncode(SeniorFileUpload.FileName);
                SeniorFileUpload.SaveAs(SavePath);
            }

            if (JuniorFileUpload.HasFile)
            {
                string SavePath = AppPath + FilePath + Server.HtmlEncode(JuniorFileUpload.FileName);
                SeniorFileUpload.SaveAs(SavePath);
            }

            if (SchoolFileUpload.HasFile)
            {
                string SavePath = AppPath + FilePath + Server.HtmlEncode(SchoolFileUpload.FileName);
                SchoolFileUpload.SaveAs(SavePath);
            }

            //Begin Doing Stuff
            parse();
            printErrBoxes();
            grade();
        }

        protected void DownloadFilesBtn_Click(object sender, EventArgs e)
        {
            String FileName = "FileName.txt";
            String FilePath = "C:/...."; //Replace this
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
            response.TransmitFile(FilePath);
            response.Flush();
            response.End();
        }
    }
}