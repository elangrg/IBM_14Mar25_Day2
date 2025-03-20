using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class ExceptionHandlingEg
    {

        static void Main()
        {

            int i = 100;
            try
            {
                Console.Write("Enter Number:");
                try
                {

                    i = int.Parse(Console.ReadLine());
                }

                catch (FormatException e)
                {

                    // Scenario 1 if not caught
                    //throw ;


                    // Scenario 2
                    throw new Exception("Failed to process", e);

                    // Console.WriteLine("Only Number...");
                }
             finally
                        {
                            Console.WriteLine("Inner Finally Called ... ");

                        }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error ...." + e.ToString());
            }
            
            finally
            {
                Console.WriteLine("Outer Finally Called ... ");

            }
            

            Console.WriteLine("You Entered " + i);
            Console.ReadKey();


        }


    }

   
}
