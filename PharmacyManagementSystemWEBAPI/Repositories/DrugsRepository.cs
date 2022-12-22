using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PharmacyManagementSystemWEBAPI.Models;

namespace PharmacyManagementSystemWEBAPI.Repositories
{
    public class DrugsRepository : IDataRepository<DrugsInventory>
    {
        PharmacyManagementSystemEntities5 _drugdetails;
        public DrugsRepository(PharmacyManagementSystemEntities5 drugdetails)
        {
            _drugdetails = drugdetails;
        }

        public void Add(DrugsInventory newdrug)
        {
            var drugs = _drugdetails.DrugsInventories.Add(newdrug);
            _drugdetails.SaveChanges();
        }

        public void Delete(int id)
        {
            DrugsInventory drugs = _drugdetails.DrugsInventories.Find(id);
            _drugdetails.DrugsInventories.Remove(drugs);
            _drugdetails.SaveChanges();
        }

        public IEnumerable<DrugsInventory> GetAll()
        {
            return _drugdetails.DrugsInventories.ToList();
        }

        public DrugsInventory GetById(int id)
        {
            return _drugdetails.DrugsInventories.Find(id);
        }

        public void Update(int did, DrugsInventory entity)
        {
            var drugs = new DrugsInventory();
            drugs.DrugId = entity.DrugId;

            drugs.DrugName = entity.DrugName;
            drugs.Quantity= entity.Quantity;
            drugs.Expiry_Date = entity.Expiry_Date;
            drugs.Price = entity.Price;
            drugs.SupplierId = entity.SupplierId;

            _drugdetails.Entry(drugs).State = EntityState.Modified;
            _drugdetails.SaveChanges();
        }
    }
}