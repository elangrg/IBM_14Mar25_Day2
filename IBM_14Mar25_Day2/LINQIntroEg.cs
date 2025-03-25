using System;
using System.Collections.Generic;
using System.Linq;

//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class LINQIntroEg
    {
        static void Main(string[] args)
        {

            List<Subject> lstSubjects = new List<Subject>()
            {
                new Subject { SubjectID=1, SubjectName="CSharp", SubjectDescription="C-Sharp Programming", SubjectType="PL"},
                new Subject { SubjectID=2, SubjectName="ADO.NET", SubjectDescription="DB API", SubjectType="DB"},
                new Subject { SubjectID=2, SubjectName="VB", SubjectDescription="VB Programming", SubjectType="PL"},
            };



      IEnumerable<Subject> qry=lstSubjects.Where(s => s.SubjectType == "PL"); // deffered Execution

            foreach (var item in qry)
            {
                Console.WriteLine(  item.SubjectName);
            }

           // lstSubjects.Where(s => s.SubjectID > 1);




            Console.ReadKey();

        }


    }



    class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string SubjectDescription { get; set; }
        public string SubjectType { get; set; }
    }
}
