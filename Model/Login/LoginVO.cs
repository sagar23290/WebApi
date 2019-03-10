using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Login
{
    public class LoginVO
    {

        private string _UserName;
        private string _Password;
       
      
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
    }
}
