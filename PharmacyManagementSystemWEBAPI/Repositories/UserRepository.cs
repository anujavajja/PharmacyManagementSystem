using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using PharmacyManagementSystemWEBAPI.Models;

namespace PharmacyManagementSystemWEBAPI.Repositories
{
    public class UserRepository : IDataRepository<UserRegistration>
    {
        PharmacyManagementSystemEntities5 _dbcontext;
        public UserRepository(PharmacyManagementSystemEntities5 dbcontext)
        {
            _dbcontext = dbcontext;

        }
       //Implementing Add Method For inserting new user in UserRegistration
        public void Add(UserRegistration newUser)
        {
           var users = _dbcontext.UserRegistrations.Add(newUser);   
            _dbcontext.SaveChanges();
        }
        //Implementing Delete method to delete user by Id
        public void Delete(int userid)
        {
           var users= _dbcontext.UserRegistrations.Remove(_dbcontext.UserRegistrations.FirstOrDefault(e => e.UserID == userid));
            _dbcontext.SaveChanges();
        }
        //implementing GetAll method for retrieving all users details
        public IEnumerable<UserRegistration> GetAll()
        {
            return _dbcontext.UserRegistrations.ToList();
        }
        //Implementing Update method 
        public void Update(int Id, UserRegistration entity)
        {
            var users = new UserRegistration();
            users.UserID = entity.UserID;

            users.UserName = entity.UserName;
            users.EmailID = entity.EmailID;
            users.Password = entity.Password;
            users.ConfirmPassword = entity.ConfirmPassword;

            _dbcontext.Entry(users).State = EntityState.Modified;
            _dbcontext.SaveChanges();
           
        }
        //Implementing GetById method
        public UserRegistration GetById(int Id)
        {
            return _dbcontext.UserRegistrations.Find(Id);
        }
    }
}