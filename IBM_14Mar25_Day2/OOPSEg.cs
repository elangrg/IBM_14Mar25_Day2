using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class OOPSEg
    {
        static void Main()
        {

            ClsA objA;//= new ClsA ();

            ClsB objB = new ClsB();

           // objA.Display();
            objB.Display();

            objA = objB;
           
            objA.Display();

            objB = (ClsB) objA;

            objB = new ClsC();


            objB.Display();


        }
    }


   abstract class ClsA
    {
        public abstract void Display();

        //    {
        //    Console.WriteLine(  "In Display of A");
        
        //}


    }


    class ClsB:ClsA
    {

        public sealed override void Display()
        {
            Console.WriteLine("In Display of CLSB");
        }

    }

    class ClsC : ClsB
    {

        //public override void Display()
        //{
        //    Console.WriteLine("In Display of CLSC");
          
        //}

    }

}
