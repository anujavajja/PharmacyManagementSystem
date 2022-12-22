using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PharmacyManagementSystemMVCPart.Models;
using PharmacyManagementSystemMVCPart.Repositories;

namespace PharmacyManagementSystemMVCPart.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        #region getdetails
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> userviews = new List<UserViewModel>();
            var service = new UserService();
            {
                using (var response = service.GetResponse("User"))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    userviews = JsonConvert.DeserializeObject
                                    <List<UserViewModel>>(apiResponse);
                }
            }
            return View(userviews);
        }
        #endregion
        #region insertnewuser

        public async Task<ActionResult> Create(UserViewModel userviewmodel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel newUser = new UserViewModel();
                var service = new UserService();
                {
                    using (var response = service.PostResponse("api/user", userviewmodel))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }
                return RedirectToAction("LoginUser");
            }
            return View(userviewmodel);
        }
        #endregion
        #region LoginUser
        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginViewModel login)
        {

            if (ModelState.IsValid)
            {
                UserViewModel newUser = new UserViewModel();
                var service = new UserService();
                {
                    using (var response = service.VerifyLogin("api/Account/Login", login))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }
                if (newUser != null)
                {
                    return RedirectToAction("DrugsView", "Drugs");
                }

                
            }
            return ViewBag.Message = "Please check the details and try again";
        }
           
        #endregion
        #region HomePage
        public ActionResult HomePage()
        {
            return View();
        }
        #endregion
        #region DeleteUser

        public async Task<ActionResult> Delete(int Id)
        {
                var service = new UserService();
                {
                    using (var response = service.DeleteResponse("User?id=" + Id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //users = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");  
        }
        #endregion
        #region EditUser

        public async Task<ActionResult> Edit(int Id)
        {
            UserViewModel users = new UserViewModel();
                var service = new UserService();
                {
                    using (var response = service.GetResponse("User"+"/"+Id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }
            return View(users);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel users)
        {
            UserViewModel update = new UserViewModel();
            var service = new UserService();
            {
                using (var response = service.PutResponse("User" + "/" + users.UserID, users))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    update = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        #endregion 
    }
}