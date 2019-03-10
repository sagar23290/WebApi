using DAL;
using Model.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public  class LoginBO
    {

       LoginDO objLoginDO = new LoginDO();
       public int SaveUserLogin(LoginVO objLoginVO)
        {
            return objLoginDO.SaveUserLogin(objLoginVO);
        }


     
       public int CheckUserLogin(LoginVO objLoginVO)
       {
           return objLoginDO.CheckUserLogin(objLoginVO);
       }
    }
}
