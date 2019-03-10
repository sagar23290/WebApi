using BAL;
using Model;
using Model.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class LoginController : ApiController
    {


        [HttpPost]
        public IHttpActionResult SaveUserLogin(LoginVO objLoginVO)
        {
            int ResutStatus = 0;
            APIResponse objAPIResponse = new APIResponse();
            LoginBO objLoginBO = new LoginBO();
            try
            {
                ResutStatus = objLoginBO.SaveUserLogin(objLoginVO);
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

        [HttpPost]
        public IHttpActionResult CheckUserLogin(LoginVO objLoginVO)
        {
            int ResutStatus = 0;
            APIResponse objAPIResponse = new APIResponse();
            LoginBO objLoginBO = new LoginBO();
            try
            {
                ResutStatus = objLoginBO.CheckUserLogin(objLoginVO);
                if (ResutStatus == 1)
                {
                    objAPIResponse.STATUS = ResponseStatus.SUCCESS;
                    objAPIResponse.DATA = ResutStatus;
                }
                else
                {
                    objAPIResponse.STATUS = ResponseStatus.FAIL;
                    objAPIResponse.ERROR = new List<ERRORS> { new ERRORS { CODE = "ERR", MESSAGE = "Login Operation Failed", DESCIPTION = "Error in Login" } };
                }
            }
            catch (Exception ex)
            {
                objAPIResponse.STATUS = ResponseStatus.SUCCESS;
                objAPIResponse.ERROR = new List<ERRORS> { new ERRORS { CODE = "ERR", MESSAGE = ex.Message, DESCIPTION = ex.StackTrace } };
            }

            return Ok(objAPIResponse);
        }
    }
}
