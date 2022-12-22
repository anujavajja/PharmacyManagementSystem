using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystemWEBAPI.Repositories
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);    
        void Add(TEntity entity);
        void Update( int id,TEntity entity);
        void Delete(int entity);
    }
}
