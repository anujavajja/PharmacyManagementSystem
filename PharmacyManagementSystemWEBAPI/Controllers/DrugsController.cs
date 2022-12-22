using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PharmacyManagementSystemWEBAPI.Models;
using PharmacyManagementSystemWEBAPI.Repositories;

namespace PharmacyManagementSystemWEBAPI.Controllers
{
    [RoutePrefix("api/Drugs")]
    public class DrugsController : ApiController
    {
        IDataRepository<DrugsInventory> _drugrepository;
        public DrugsController()
        {
            this._drugrepository = new DrugsRepository(new PharmacyManagementSystemEntities5());
        }
        #region Get Drug Details
        [HttpGet]
        [Route("")]
        //This GetAllDrugs returns all Drug details
        public IEnumerable<DrugsInventory> GetAllDrugs()
        {
            var drugs = _drugrepository.GetAll();
            return drugs;
        }
        #endregion
        #region insert new drug
        [HttpPost]
        [Route("")]
        //By using this method we can add new drugs in DrugsData
        public IHttpActionResult AddDrug(DrugsInventory drug)
        {
            DrugsInventory drugObj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                _drugrepository.Add(drug);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Data Saved!");
        }
        #endregion
        #region getbyId
        [HttpGet]
        [Route("")]
        //This method is used to get drug details by DrugId
        public DrugsInventory GetbyId(int Id)
        {
            var registration = _drugrepository.GetById(Id);
            return registration;
        }
        #endregion
        #region Update Drug Details
        [HttpPut]
        //By using HttpPut method we can update the drug details
        public IHttpActionResult Put(int Id, DrugsInventory drugs)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Give valid userid");
                _drugrepository.Update(Id, drugs);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Updated Successfully");
        }
        #endregion
        #region Delete
        [HttpDelete]
        [Route("")]
        //HttpDelete method is used to delete the record by giving id
        public IHttpActionResult DeleteDrug(int id)
        {
           

            try
            {

                if (id <= 0)
                    return BadRequest("please enter the userid");
                _drugrepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Data Removed");
        }
        #endregion
    }

}
