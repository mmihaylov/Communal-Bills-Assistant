using CBA.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Service.Abstract
{
    public abstract class EntityService<T> : IEntityService<T> 
        where T : BaseEntity
    {
        protected IDatabaseContext _context;
        
        public EntityService(IDatabaseContext context)
        {
            _context = context;            
        }  

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable<T>();
        }

        public void Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity cannot be null");

            _context.Set<T>().Add(entity);
            _context.SaveChanges(); 
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity cannot be null");

            _context.Set<T>().Remove(entity);
            _context.SaveChanges(); 
        }

        public void Update(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException("Entity cannot be null");

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges(); 
        }
    }
}
