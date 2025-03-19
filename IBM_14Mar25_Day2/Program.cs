using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayA();
            Console.WriteLine("Hello World!!!");
            Console.ReadKey();
        }

        static void DisplayA()
        {
            int i = 1000;
            int j = 2000;

            Console.WriteLine(  "In DisplayA Method");
            Console.WriteLine(i);
            DisplayB();
            Console.WriteLine( j );
        }

        static void DisplayB()
        {
            Console.WriteLine("In DisplayB Method");
            int k = 1000;
            int l = 2000;

            Console.WriteLine(k);
            Console.WriteLine( l );
        


        }


    }
}
