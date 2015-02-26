using CBA.DataAccess.Abstract;
using CBA.DataAccess.Entities;
using CBA.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Repository.Implementation
{
    public class LocationService : EntityService<Location>, ILocationService
    {
        private IDatabaseContext _context;

        public LocationService(IDatabaseContext context)
           : base(context)
        {           
        }

        public Location GetById(int id)
        {
            return _context.Locations.FirstOrDefault(l => l.Id == id);
        }
    }
}
