using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infra.Context
{
    public partial class UnKnownDbContext
    {
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.Entity.IsDeleted = true;
                        entry.Entity.UpdateDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.IsDeleted = false;
                        entry.Entity.UpdateDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.IsDeleted = false;
                        entry.Entity.CreationDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
