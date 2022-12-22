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
    public class DrugsController : Controller
    {
        // GET: Drugs
        public async Task<ActionResult> DrugsView()
        {
            List<DrugsViewModel> drugs = new List<DrugsViewModel>();
            var service = new UserService();
            {
                using (var response = service.GetResponse("Drugs"))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    drugs = JsonConvert.DeserializeObject<List<DrugsViewModel>>(apiResponse);
                }
            }
            return View(drugs);
        }

       
        public async Task<ActionResult> Create(DrugsViewModel drugs)
        {
            if (ModelState.IsValid)
            {
                DrugsViewModel newdrug = new DrugsViewModel();
                var service = new UserService();
                {
                    using (var response = service.PostResponse("Drugs", drugs))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }
                return RedirectToAction("DrugsView");
            }
            return View(drugs);
        }
        
        public async Task<ActionResult> Delete(int Id)
        {
            var service = new UserService();
            {

                using (var response = service.DeleteResponse("Drugs?id=" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //users = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
                return RedirectToAction("DrugsView");
            }
            return RedirectToAction("DrugsView");
        }

        public async Task<ActionResult> Edit(int Id)
        {
            DrugsViewModel users = new DrugsViewModel();
            var service = new UserService();
            {
                using (var response = service.GetResponse("Drugs" + "/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<DrugsViewModel>(apiResponse);
                }
            }
            return View(users);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(DrugsViewModel users)
        {
            DrugsViewModel update = new DrugsViewModel();
            var service = new UserService();
            {
                using (var response = service.PutResponse("Drugs" + "/" + users.DrugId, users))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //update = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
            }
            return RedirectToAction("DrugsView");
        }


    }
}