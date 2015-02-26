using CBA.DataAccess.Abstract;
using CBA.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBA.DataAccess
{
    public class EFDataContext : DbContext, IDatabaseContext
    {
        public EFDataContext()
            : base("Name=CommunalBillsAssistantContext")
        {
            //this.Configuration.LazyLoadingEnabled = false; 
        }

        public IDbSet<BillType> BillTypes { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<LocationBill> LocationBills { get; set; }
        public IDbSet<PaidBill> PaidBills { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity auditableEntity = entry.Entity as IAuditableEntity;

                if (auditableEntity != null)
                {
                    string userName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        auditableEntity.CreatedAt = now;
                        auditableEntity.CreatedBy = userName;
                    }
                    else 
                    {
                        base.Entry(auditableEntity).Property(e => e.CreatedAt).IsModified = false;
                        base.Entry(auditableEntity).Property(e => e.CreatedBy).IsModified = false;                        
                    }

                    auditableEntity.UpdatedAt = now;
                    auditableEntity.UpdatedBy = userName;
                }
            }

            return base.SaveChanges();
        }       
    }
}
