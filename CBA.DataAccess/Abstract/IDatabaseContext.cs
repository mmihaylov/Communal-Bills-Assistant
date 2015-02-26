using CBA.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DataAccess.Abstract
{
    public interface IDatabaseContext
    {
        IDbSet<BillType> BillTypes { get; set; }
        IDbSet<Location> Locations { get; set; }
        IDbSet<LocationBill> LocationBills { get; set; }
        IDbSet<PaidBill> PaidBills { get; set; }

        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
