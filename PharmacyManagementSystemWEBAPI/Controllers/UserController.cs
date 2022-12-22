using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using PharmacyManagementSystemWEBAPI.Models;
using PharmacyManagementSystemWEBAPI.Repositories;

namespace PharmacyManagementSystemWEBAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        IDataRepository<UserRegistration> _dataRepository;
        public UserController()
        {
            this._dataRepository = new UserRepository(new PharmacyManagementSystemEntities5());
        }
        #region Getuserdetails
        [HttpGet]
        [Route("")]
        //This Method is used to get all users details
        public IEnumerable<UserRegistration> GetAllUsers()
        {
            var users = _dataRepository.GetAll();
            return users;
        }
        #endregion
        #region Insertuser
        [HttpPost]
        [Route("")]
        //To insert new user record.
        public IHttpActionResult CreateUser(UserRegistration user)
        {
            UserRegistration userObj = null;
            try
            {
                if (!ModelState.IsValid)
                
                    return BadRequest("Invalid data.");
                    _dataRepository.Add(user);
            }
            

            catch (Exception)
            {

                throw;
            }
            return Ok("Data Saved!");
        }
        #endregion
        #region getbyid
        [HttpGet]
        [Route("")]
        //This method is used to update the user details
        public UserRegistration GetbyId(int Id)
        {
            var registration = _dataRepository.GetById(Id);
            return registration;
        }
        #endregion
        #region UpdateUser
        [HttpPut]
        public IHttpActionResult Put(int Id , UserRegistration users)
        {
            
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Give valid userid");
                    _dataRepository.Update(Id, users);
                
            }
            catch(Exception)
            {
                throw;
            }
            return Ok("Updated Successfully");
        }
        #endregion
        #region DeleteUser
        [HttpDelete]
        [Route("")]
        //Delete a particular user record
        public IHttpActionResult DeleteUser(int id)
        { 
            try
            {
                
                if (id <= 0)
                    return BadRequest("please enter the userid");
                _dataRepository.Delete(id);
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
