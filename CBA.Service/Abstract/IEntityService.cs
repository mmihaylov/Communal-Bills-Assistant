using CBA.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Service.Abstract
{
    public interface IEntityService<T> : IService where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        void Create(T entity);
        void Delete(T entity);        
        void Update(T entity);
    }
}
