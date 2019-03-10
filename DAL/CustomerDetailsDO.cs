using Model.Customer;
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
    public class CustomerDetailsDO
    {



        public int SaveCustomer(CustomerDetailVO objCustomerDetailVO)
        {
            int RetVal = 0;
            string str = "data source=localhost;initial catalog=Customer;persist security info=True;Integrated Security=SSPI";
            SqlConnection cn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("stp_SAVE_CUSTOMER_DETAILS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", objCustomerDetailVO.ID);
            cmd.Parameters.AddWithValue("@FirstName", objCustomerDetailVO.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", objCustomerDetailVO.MiddleName);
            cmd.Parameters.AddWithValue("@Age", objCustomerDetailVO.Age);
            cmd.Parameters.AddWithValue("@LastName", objCustomerDetailVO.LastName);
            cmd.Parameters.AddWithValue("@Gender", objCustomerDetailVO.Gender);
            cmd.Parameters.AddWithValue("@Address", objCustomerDetailVO.Address);
            cmd.Parameters.AddWithValue("@Hodbbies", objCustomerDetailVO.Hobbies);
            cn.Open();
            RetVal=cmd.ExecuteNonQuery();
            cn.Close();
            return RetVal;
        }

        public List<CustomerDetailVO> GetCustomer(int CustId=0) {
            List<CustomerDetailVO> lst = new List<CustomerDetailVO>();
            DataTable objTable = new DataTable();
            string str = "data source=localhost;initial catalog=Customer;persist security info=True;Integrated Security=SSPI";
            SqlConnection cn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("STP_GET_CUSTOMER_DETAILS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", CustId);
            cn.Open();
           
            SqlDataAdapter objAdapter = new SqlDataAdapter(cmd);
            objAdapter.Fill(objTable);
            cn.Close();
            lst =  objTable.DataTableToList<CustomerDetailVO>();
            return lst;
        }

       
    }
}
