using Model.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DAL
{
    public class LoginDO
    {

        public int SaveUserLogin(LoginVO objLoginVO)
        {
            int RetVal = 0;
            string str = "data source=localhost;initial catalog=Customer;persist security info=True;Integrated Security=SSPI";
            SqlConnection cn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("STP_SignUpUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", objLoginVO.UserName);
            cmd.Parameters.AddWithValue("@Password", Common.Encrypt(objLoginVO.Password));
            cn.Open();
            RetVal = cmd.ExecuteNonQuery();
            cn.Close();
            return RetVal;
        }

        public int CheckUserLogin(LoginVO objLoginVO)
        {
            int RetVal = 0;
            DataTable objTable = new DataTable();
            string str = "data source=localhost;initial catalog=Customer;persist security info=True;Integrated Security=SSPI";
            SqlConnection cn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("STP_GET_CUSTOMER_DETAILS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@UserName", objLoginVO.UserName);
            cmd.Parameters.AddWithValue("@Password", objLoginVO.Password);
            cn.Open();
            RetVal = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return RetVal;
        }

    }
}
