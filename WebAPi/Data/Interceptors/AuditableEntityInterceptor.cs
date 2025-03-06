using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models.Entities;
using Shared.Constants;
using Shared.Entities;
using System.Text;
using WebAPi.Extensions;
using WebAPi.Interfaces.Interceptors;

namespace WebAPi.Data.Interceptors
{
    public class AuditableEntityInterceptor(TimeProvider dateTime) : SaveChangesInterceptor
    {
        private readonly TimeProvider _dateTime = dateTime;

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var auditLogs = new List<AuditLog>();
            var addedEntities = new List<EntityEntry>();
            var userId = "0";

            UpdateEntities(eventData.Context);

            foreach (var entityEntry in eventData.Context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted))
            {
                var auditLog = new AuditLog
                {
                    UserId = userId,
                    EntityName = entityEntry.Entity.GetType().Name,
                    Action = entityEntry.State.ToString(),
                    Timestamp = DateTime.UtcNow,
                    Changes = GetChanges(entityEntry)
                };

                if (entityEntry.State == EntityState.Added)
                {
                    addedEntities.Add(entityEntry); // Save to update with actual ID after saving
                }

                auditLogs.Add(auditLog);
            }

            var resutl = base.SavingChanges(eventData, result);

            // Update added entities with actual IDs in audit logs
            foreach (var addedEntity in addedEntities)
            {
                var actualId = addedEntity.Property("Id").CurrentValue ?? "Unknown ID";
                var log = auditLogs.First(al => al.EntityName == addedEntity.Entity.GetType().Name && al.Action == EntityState.Added.ToString());
                log.Changes = $"Entity with ID '{actualId}' was added.\n" + log.Changes;
            }

            base.SavingChanges(eventData, result);

            return result;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var auditLogs = new List<AuditLog>();
            var addedEntities = new List<EntityEntry>();
            var userId = "0";

            UpdateEntities(eventData.Context);

            foreach (var entityEntry in eventData.Context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted))
            {
                var auditLog = new AuditLog
                {
                    UserId = userId,
                    EntityName = entityEntry.Entity.GetType().Name,
                    Action = entityEntry.State.ToString(),
                    Timestamp = DateTime.UtcNow,
                    Changes = GetChanges(entityEntry)
                };

                if (entityEntry.State == EntityState.Added)
                {
                    addedEntities.Add(entityEntry); // Save to update with actual ID after saving
                }

                auditLogs.Add(auditLog);
            }

            var resutl = base.SavingChangesAsync(eventData, result, cancellationToken);

            // Update added entities with actual IDs in audit logs
            foreach (var addedEntity in addedEntities)
            {
                var actualId = addedEntity.Property("Id").CurrentValue ?? "Unknown ID";
                var log = auditLogs.First(al => al.EntityName == addedEntity.Entity.GetType().Name && al.Action == EntityState.Added.ToString());
                log.Changes = $"Entity with ID '{actualId}' was added.\n" + log.Changes;
            }

            base.SavingChangesAsync(eventData, result, cancellationToken);

            return resutl;
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

        private static string GetChanges(EntityEntry entity)
        {
            var changes = new StringBuilder();

            // For added entities, log the initial values of all properties without ID
            if (entity.State == EntityState.Added)
            {
                foreach (var property in entity.Properties)
                {
                    if (property.Metadata.Name != "Id") // Exclude ID for added entities initially
                    {
                        var currentValue = property.CurrentValue;
                        changes.AppendLine($"{property.Metadata.Name}: '{currentValue}'");
                    }
                }
            }
            // For modified entities, log the entity ID and only properties that have changed
            else if (entity.State == EntityState.Modified)
            {
                var entityId = entity.Property("Id").CurrentValue ?? "Unknown ID";
                changes.AppendLine($"Entity with ID '{entityId}' was modified.");

                foreach (var property in entity.Properties)
                {
                    var originalValue = property.OriginalValue;
                    var currentValue = property.CurrentValue;

                    if (!Equals(originalValue, currentValue))
                    {
                        changes.AppendLine($"{property.Metadata.Name}: From '{originalValue}' to '{currentValue}'");
                    }
                }
            }
            // For deleted entities, log that the entity was deleted along with its ID
            else if (entity.State == EntityState.Deleted)
            {
                var entityId = entity.Property("Id").CurrentValue ?? "Unknown ID";
                changes.AppendLine($"Entity with ID '{entityId}' was deleted.");
            }

            return changes.ToString();
        }
    }
}