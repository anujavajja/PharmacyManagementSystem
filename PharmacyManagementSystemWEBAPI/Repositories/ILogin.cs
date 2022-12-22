using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyManagementSystemWEBAPI.Models;

namespace PharmacyManagementSystemWEBAPI.Repositories
{
    public interface ILogin
    {
           UserRegistration VerifyLogin(string EmailID, string Password);        
    }
}
