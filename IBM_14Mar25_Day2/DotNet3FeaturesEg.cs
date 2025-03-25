using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class DotNet3FeaturesEg
    {


        static void Main()
        {

            #region Local type Inference / Implicitly typed Variable
            //var i = 100;

            //var j;
            //var k = null; 
            #endregion


            IBMStudent objStd = new IBMStudent();

            // Object Init Syntax
            IBMStudent objStd1 = new IBMStudent { FirstName = "Ganesh", StudentId = 1234, LastName = "Shiv" };
            IBMStudent objStd2 = new IBMStudent { FirstName = "Ramesh", LastName = "Mahesh" };

            // Collection init Syntax
            List<IBMStudent> students = new List<IBMStudent>() { 
                new IBMStudent { FirstName = "Ganesh", StudentId = 1234, LastName = "Shiv" }, 
                new IBMStudent {FirstName = "Ramesh", StudentId=12321, LastName = "Mahesh" } };
           
            // Anonymous Type

            IBMStudent obj = new IBMStudent { FirstName = "Ramesh", LastName = "Mahesh" };

            var obj1 = new IBMStudent { FirstName = "Ramesh", LastName = "Mahesh" };

            var obj2 = new  { FirstName = "Ramesh", LastName = "Mahesh" };
            var obj3 = new { FirstName = "Suresh", LastName = "B" };

            var obj4 = new { LastName = "Dinesh",FirstName = "H"  };

            Console.WriteLine(  obj1.GetType());
            Console.WriteLine(obj2.GetType());
            Console.WriteLine(obj3.GetType());
            Console.WriteLine(obj4.GetType());
        }
    }
}
