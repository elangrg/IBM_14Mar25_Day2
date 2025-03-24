using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    delegate int dlgDemo(int a, int b); // int(int,int)

    internal class DelegateEg
    {
        static void Main()
        {
            #region Delegate basic Syntax
            //dlgDemo fptr = new dlgDemo(Add); //1.0 

            //fptr += Multi;   // 2.0

            //Console.WriteLine(fptr.GetInvocationList()[0].DynamicInvoke(100, 200));

            //Console.WriteLine(fptr(100, 200)); 
            #endregion

            //Action<>

            Func<int,int,int> fptr = Add; //1.0 

            fptr += Multi;   // 2.0

            fptr += delegate (int i, int j) { return i + j; }; // 2.0 Anon block / Method

            fptr +=  (int i, int j) => { return i + j; }; // 3.0 Lambda Expression (Explicitly Typed)
            fptr += ( i,  j) => { return i + j; }; // (Implicitly Typed) - Block Body

            fptr += (i, j) => i + j;  // (Implicitly Typed) - Expression Body

            Console.WriteLine(fptr(100, 200));

            Action<string> prc = (s) => Console.WriteLine(s);

            //Action<string> prc1 = s => Console.WriteLine(s);

            prc("Hello Action Lambda .....");

            // Generic Delegate Action & Func  // 3.0 = 4 overloads , 4.0 = 16 overloads


            Console.ReadKey();
        }


        static int Add(int a, int b) { return a + b; }
        static int Multi(int x, int y) { return x * y; }

        static double  AnotherMethod(int x, double y) { return x * y; }

    }
}
