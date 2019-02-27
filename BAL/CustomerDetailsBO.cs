using DAL;
using Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class CustomerDetailsBO
    {
        CustomerDetailsDO objCustomerDO = new CustomerDetailsDO();
        public int SaveCust(CustomerDetailVO objCustomerDetailVO)
        {
           return  objCustomerDO.SaveCustomer(objCustomerDetailVO);
        }
        public List<CustomerDetailVO> GetAllCustomer(int cusID=0) {
            return objCustomerDO.GetCustomer(cusID);
        }
    }
}
