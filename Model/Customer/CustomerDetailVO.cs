using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Customer
{
    public class CustomerDetailVO
    {
        private int _ID;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private int _Age;
        private string _Gender;
        private string _Address;
        private string _Hobbies;

        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string Hobbies
        {
            get { return _Hobbies; }
            set { _Hobbies = value; }
        }


        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
    }
}
