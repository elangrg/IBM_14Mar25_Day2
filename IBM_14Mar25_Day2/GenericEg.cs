using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class GenericEg
    {
        // ver 3 - Generic
        static void Main()
        {
            Console.WriteLine( Min<int>(100,200) );

            Console.WriteLine(Min(100.10, 200.20));


            Console.WriteLine(Min("xyz", "abc"));


            Console.WriteLine(Min<string>("xyz", 100.ToString()));

            MyClass c= new MyClass();

            GenericMethodSyntax<int, MyClass, int>(100,c );


            Console.ReadKey();

        }


        static T  Min<T>(T a, T b) where T:IComparable<T>
            {
            if (a.CompareTo(b) <1) { return a; }
            
             return b; 
         }


        static ReturnTypePlaceholder  GenericMethodSyntax<T1,T2,ReturnTypePlaceholder>(T1 a, T2 b) where T1 : IComparable<T1> 
            where T2 : class, new()
        {
            
            T2 obj= new T2 ();


            return default(ReturnTypePlaceholder);
        }



        //static double Min(double  a, double b)
        //{
        //    if (a < b) { return a; }
        //    return b;
        //}


    }



    class DemoClass<T>
    {

        public DemoClass()
        {
                T abc= default(T);

        }


        public void display(T a) { 
        
        
        }


    }

    class MyClass
    {
        public MyClass(int a)
        {
                
        }

    }
}
