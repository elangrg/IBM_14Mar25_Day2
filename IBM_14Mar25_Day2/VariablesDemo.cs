using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class VariablesEg
    {

        static void Main()
        {

            int i = 100;

            long l = i; // implicit conv


            short s = (short) i; // Exp Conversion 


            string st = "100";

            int k= int.Parse(st);

            st = i.ToString();


            object o = i; // Boxing
            int m = (int) o;



            Console.WriteLine(  i);

            clsA objA = new clsA();
            objA.j = 10;
            clsB objB = new clsB();
            objB.j = 0;
            
        }



        class clsA
        {
            private int i=100;
            public int j = 1000;
            protected int k = 120;


        }

        class clsB:clsA
        {
            public clsB()
            {
                this.j = 0;
                this.k = 200;
            }


            public void Display() { }
            public int Display(int a) { return 0; }

        }

    }
}
