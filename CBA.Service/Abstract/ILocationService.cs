using CBA.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Service.Abstract
{
    public interface ILocationService : IEntityService<Location>
    {
        Location GetById(int Id);
    }
}
