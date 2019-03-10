using BAL;
using Model;
using Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication2.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {


        [HttpPost]
        public IHttpActionResult SaveCustomer(CustomerDetailVO objCustomerDetailVO)
        {
            int ResutStatus=0;
            APIResponse objAPIResponse = new APIResponse();
            CustomerDetailsBO objCustomerDetailsBO=new CustomerDetailsBO();
            try
            {
                ResutStatus = objCustomerDetailsBO.SaveCust(objCustomerDetailVO);
                objAPIResponse.STATUS = ResponseStatus.SUCCESS;
                objAPIResponse.DATA = ResutStatus;
            }
            catch (Exception ex)
            {
                objAPIResponse.STATUS = ResponseStatus.SUCCESS;
                objAPIResponse.ERROR = new List<ERRORS> { new ERRORS { CODE = "ERR", MESSAGE = ex.Message, DESCIPTION = ex.StackTrace } };
            }

            return Ok(objAPIResponse);
        }
        [HttpGet]
        public IHttpActionResult GetAllCustomers()
        {
            List<CustomerDetailVO> ResutStatus;
            APIResponse objAPIResponse = new APIResponse();
            CustomerDetailsBO objCustomerDetailsBO = new CustomerDetailsBO();
            try
            {
                ResutStatus = objCustomerDetailsBO.GetAllCustomer();
                objAPIResponse.STATUS = ResponseStatus.SUCCESS;
                objAPIResponse.DATA = ResutStatus;
            }
            catch (Exception ex)
            {
                objAPIResponse.STATUS = ResponseStatus.SUCCESS;
                objAPIResponse.ERROR = new List<ERRORS> { new ERRORS { CODE = "ERR", MESSAGE = ex.Message, DESCIPTION = ex.StackTrace } };
            }

            return Ok(objAPIResponse);
        }

        [HttpGet]
        public IHttpActionResult GetCustName(string CustName)
        {
            APIResponse objAPIResponse = new APIResponse();
            try
            {

                objAPIResponse.STATUS = ResponseStatus.SUCCESS;
                objAPIResponse.DATA = CustName;
            }
            catch (Exception ex)
            {
                objAPIResponse.STATUS = ResponseStatus.SUCCESS;
                objAPIResponse.ERROR = new List<ERRORS> { new ERRORS { CODE = "ERR", MESSAGE = ex.Message, DESCIPTION = ex.StackTrace } };
            }

            return Ok(objAPIResponse);
        }

        [HttpPost]
        public IHttpActionResult UploadFiles()
        {
            int i = 0;
            int cntSuccess = 0;
            var uploadedFileNames = new List<string>();
            string result = string.Empty;

            HttpResponseMessage response = new HttpResponseMessage();

            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[i];
                    var filePath = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + postedFile.FileName);
                    try
                    {
                        postedFile.SaveAs(filePath);
                        uploadedFileNames.Add(httpRequest.Files[i].FileName);
                        cntSuccess++;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    i++;
                }
            }

            result = cntSuccess.ToString() + " files uploaded succesfully.<br/>";

            result += "<ul>";

            foreach (var f in uploadedFileNames)
            {
                result += "<li>" + f + "</li>";
            }

            result += "</ul>";

            return Json(result);
        }

    }
}
