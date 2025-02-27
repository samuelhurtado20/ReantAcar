using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models.Entities;
using Shared.Constants;
using WebAPi.Extensions;
using WebAPi.Interfaces.Interceptors;

namespace WebAPi.Data.Interceptors
{
    public class AuditableEntityInterceptor(TimeProvider dateTime) : SaveChangesInterceptor
    {
        private readonly TimeProvider _dateTime = dateTime;

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context is not null)
            {
                foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
                {
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entry.Entity.CreatedAt = _dateTime.GetUtcNow().DateTime;
                            entry.Entity.CreatedBy = entry.Entity.CreatedBy ?? Identifiers.SystemAdminUserId;
                        }
                        entry.Entity.UpdatedAt = _dateTime.GetUtcNow().DateTime;
                        entry.Entity.UpdatedBy = entry.Entity.UpdatedBy ?? Identifiers.SystemAdminUserId;
                    }
                }

                foreach (var entry in context.ChangeTracker.Entries<ISoftDelete>())
                {
                    if (entry.State == EntityState.Deleted)
                    {
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = _dateTime.GetUtcNow();
                    }
                }
            }
        }
    }
}