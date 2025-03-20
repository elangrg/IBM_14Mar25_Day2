using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class MethodEg
    {
        static void Main()
        {
            int a = 100;

            Console.WriteLine("In Main before DisplayByVal Call value of a is :" + a);
            DisplayByVal(a);
            Console.WriteLine("In Main before DisplayByRef Call value of a is :" + a);

            DisplayByRef(ref a);
            Console.WriteLine("In Main before DisplayByOut Call value of a is :" + a);

            DisplayByOut(out a);
            Console.WriteLine("In Main After DisplayByOut Call value of a is :" + a);




            DisplayParams(10, 120, 234, 2, 1);

            DisplayParams(10, 20, 30, 40);

            int[] arr = {1,2,3,4,5  };

            DisplayParams(arr);
            DisplayParams();

            Console.WriteLine(Sum(100, 200));
            Console.WriteLine(Sum(100, 200,e:100));
            Console.WriteLine(Sum(b:100, a:200, e: 100));

            Console.ReadKey();
        }


        static void DisplayByVal(int i)
        {
            i++;
            Console.WriteLine( "In Display By Val value of i is :" + i);
        
        }


        static void DisplayByRef(ref int i)
        {
            i++;
            Console.WriteLine("In Display By Ref value of i is :" + i);

        }


        static void DisplayByOut(out int i)
        {
            i = 0;
           
            i++;
            Console.WriteLine("In Display By out value of i is :" + i);

        }

        static void DisplayParams(params int[] i)
        {
            if (i.Length==0)
            {
                Console.WriteLine( "I is Empty");
            }

            for (int j = 0; j < i.Length; j++)
            {
                Console.WriteLine(  $"i[{j}]= {i[j]}");
            }
            

        }



        static int Sum(int a, int b, int c=10, int d=100, int e=200) 
        { return a + b+c+d+e; }


    }
}
