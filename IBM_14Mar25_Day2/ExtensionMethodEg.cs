using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class ExtensionMethodEg
    {
        static void Main()
        { 
            char c='A'; 
            // trad call 
            ExtensionMethodClass.IsEmpIDValidChar(c);
            
            c.IsEmpIDValidChar("demo");
            string st = "";
            st.IsEmpIDValidChar();

            IBMStudent obj = new IBMStudent();
            obj.IsEmpIDValidChar();
        }

    }


  static   class ExtensionMethodClass 
    {
        public static  bool IsEmpIDValidChar(this object  ch, string st="")
        {
            return true;
        }
    }


}
