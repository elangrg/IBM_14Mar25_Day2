using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class Iterator_IEnum2Eg
    {
        static void Main()
        {
            List<string> lstNames = new List<string>() {"Ganesh",
            "Mahesh","Dinesh", "Ramesh"};

            StringEnumerable stringEnumerable = new StringEnumerable(lstNames);

            foreach (string str in stringEnumerable) {

                Console.WriteLine(str);
            }

            foreach (string str in GetNames())
            {

                Console.WriteLine(str);
            }

            Console.ReadKey();

        }

        // 2.0
        static IEnumerable GetNames(bool AllValues=false)
        {
            yield return "Suresh";
            yield return "Ganesh";
            yield return "Mahesh";

            if (AllValues == false) { yield break; }

            yield return "Amaresh";

        }
    }

    class StringEnumerable : IEnumerable
    {
        List<string> _lst = null;


        public StringEnumerable( List<string> lst)
        {
                _lst = lst;
        }


        public IEnumerator GetEnumerator()
        {
            return  new stringEnumerator(_lst);
            
        }
    } // dot net 1.0





    class stringEnumerator : IEnumerator
    {
        int _idx = -1;
        List<string> _lst = null;
        public stringEnumerator(List<string> lst)
        {
                _lst= lst;
        }

        public object Current => _lst[_idx];

        public bool MoveNext()
        {
            _idx++;


           if (_idx >= _lst.Count)
                return false;

           return true;

        }

        public void Reset()
        {
            _idx = -1;
        }
    }

}
