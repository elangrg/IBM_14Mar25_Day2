using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class PropertyIndexerEg
    {
        static void Main()
        { 
        
            Project obj = new Project();

            obj.ProjectID = 1000;
            Console.WriteLine(  obj.ProjectID);
            obj.ProjectName = "abc";
            Console.WriteLine( obj.ProjectName);

            obj.ProjectName = "abc xyz";
            Console.WriteLine(obj.ProjectName);

            obj.ProjectStartDate = DateTime.Now.AddDays(-5000);

            Console.WriteLine(  obj.YearsAsOnToday);

            // indexer

            obj[2] = "SQL SERVER";

            Console.WriteLine( obj[2] ); 


        }
    }


    class Project
    {
        string[] _Skills = {"C#", "VB", "SQL" };
        
        private int _ProjectID;
        // 1.0>=
        public int ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }

        // 3.0  Auto Prop
        public string ProjectDescription { get; set; }

        private string _ProjectName;

        public string ProjectName
        {
            get { return _ProjectName; }
            set {
                    if (value.Length>3)
                    {
                        _ProjectName = value; 
                    }
                }
        }



        public DateTime ProjectStartDate { get; set; }

        

        public int YearsAsOnToday
        {
            get { return  DateTime.Now.Year - ProjectStartDate.Year ; }
        }


        public string this[int index]
        {
            get { return _Skills[index]; }
            set { _Skills[index] = value; }
        }


    }
}
