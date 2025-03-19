using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_14Mar25_Day2
{
    internal class InterfaceEg
    {

        static void Main()
        {

            IStudent objstd;

            IBMStudent iBMStudent = new IBMStudent();
            iBMStudent.FirstName = "Mahesh";
            iBMStudent.LastName = "Shiv";
            Console.WriteLine(iBMStudent.GetFullName());

            objstd = iBMStudent;


            Console.WriteLine( objstd.GetFullName() );  

        }


    }

    interface IStudent
    {
        string FirstName { get; set; }
        int StudentId { get; set; }

        string GetFullName();
    }

    class IBMStudent : IStudent
    {

        string _FirstName = "";

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public int StudentId { get; set; }
        int stdid = 0;

        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string GetFullName()
        { return $"Implicit : {FirstName} {LastName}"; }
        string IStudent.FirstName {
            get { return _FirstName; }
            set  { _FirstName = value; } }
        int IStudent.StudentId
        {
            get { return stdid; }
            set { stdid = value; }
        }

        string IStudent.GetFullName()
        {
            return $" Explicit :  {FirstName} {LastName}";
        }
    }
    


}




