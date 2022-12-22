using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using PharmacyManagementSystemWEBAPI.Models;
using PharmacyManagementSystemWEBAPI.Repositories;

namespace PharmacyManagementSystemWEBAPI.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        ILogin _loginrepository;
        public AccountController()
        {
            this._loginrepository = new LoginRepository(new PharmacyManagementSystemEntities5());
        }
        #region Login Method
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult VerifyLogin(UserRegistration objlogin)
        {
           UserRegistration _objlogin = null;
            try
            {
                _objlogin = _loginrepository.VerifyLogin(objlogin.EmailID, objlogin.Password);

                if (_objlogin == null)
                {
                    return NotFound();
                    //return Ok(customer);

                }

            }
            catch (Exception ex)
            {

            }

            //return Ok(customer);
            return Ok(_objlogin);

        }
        #endregion
    }
}
