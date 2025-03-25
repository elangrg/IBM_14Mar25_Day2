using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class CollectionsEg
    {
        static void Main()
        {

            ArrayList objArrList = new ArrayList(); // 1.0/ 1.1

            objArrList.Add("Ganesh");
            objArrList.Add(10000);
            objArrList.Add(DateTime.Now);

            List<IBMStudent> objGlst = new List<IBMStudent>();
            objGlst.Add(new IBMStudent { FirstName="Ganesh", LastName="Mahesh", StudentId=12345 });
            objGlst.Add(new IBMStudent { FirstName = "Mahesh", LastName = "Shiv", StudentId = 12321 });


            // sequential access IEnumerable can be Iterated Foreach loop


            foreach (IBMStudent objstd  in objGlst)
            {
                Console.WriteLine( objstd );
            }

            // Random Access
            Console.WriteLine(   objGlst[1]    );  


            Dictionary<string,IBMStudent> objDic = new Dictionary<string,IBMStudent>();

            objDic.Add("100", new IBMStudent { FirstName = "Suresh", LastName = "Mahesh", StudentId = 12345 });
            objDic.Add("101", new IBMStudent { FirstName = "Ramesh", LastName = "Mahesh", StudentId = 12345 });

            foreach (KeyValuePair<string ,IBMStudent> objstd in objDic)
            {
                Console.WriteLine(objstd.Key + "  - " + objstd.Value);
            }

            // Random Access
            Console.WriteLine(objDic["100"]);

            Console.ReadKey();


        }


        class EmployeeList:ArrayList
        {

            public override int Add(object value)
            {
                if (value is IBMStudent)
                {

                    return base.Add(value);
                }
                else
                    return -1;
            }


        }

    }
}
