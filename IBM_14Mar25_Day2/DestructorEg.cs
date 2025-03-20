using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class DestructorEg
    {
        static void Main()
        {
            Demo obj= new Demo();

            Console.WriteLine(  obj.i);

            obj = null;
            //obj.Dispose();

            using (Demo obj1= new Demo() )
            {
                Console.WriteLine(  obj1.i); 
            }

            //GC.WaitForPendingFinalizers();

            //GC.Collect();

            Console.ReadKey();



        }
    }


    class Demo:IDisposable
    {
        public int i = 100;
        private bool disposedValue;

        ~Demo()
        {
            Dispose(false);
            Console.WriteLine(  "Destructor Called.....");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Demo()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            Console.WriteLine(  "Dispose Called ...." );
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
