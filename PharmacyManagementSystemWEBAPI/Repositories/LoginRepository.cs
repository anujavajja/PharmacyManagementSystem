using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PharmacyManagementSystemWEBAPI.Models;

namespace PharmacyManagementSystemWEBAPI.Repositories
{
    public class LoginRepository : ILogin
    {
        PharmacyManagementSystemEntities5 _loginentities = null;
        public LoginRepository(PharmacyManagementSystemEntities5 loginentities)
        {
            _loginentities = loginentities;
        }

        public UserRegistration VerifyLogin(string EmailID, string Password)
        {
            UserRegistration login = null;
            try
            {
                var checkValidUser = _loginentities.UserRegistrations.Where(m => m.EmailID == EmailID &&
            m.Password == Password).FirstOrDefault();
                if (checkValidUser != null)
                {
                    login = checkValidUser;
                }

                else
                {
                    login = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return login;
        }

    }
}
