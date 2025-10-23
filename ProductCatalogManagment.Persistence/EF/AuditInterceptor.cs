using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProductCatalogManagment.Domain.Models;
using System.Text.Json;

namespace ProductCatalogManagment.Persistence.EF
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, InterceptionResult<int> result)
        {
            var context = eventData.Context;
            if (context == null) return result;
            LogChanges(context);
            return result;
        }
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            if (context == null) return result;
            LogChanges(context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        private void LogChanges(DbContext context)
        {
            var auditLogs = new List<AuditLog>();
            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                {
                    auditLogs.Add(new AuditLog
                    {
                        TableName = entry.Entity.GetType().Name,
                        Operation = entry.State.ToString(),
                        ModifiedBy = "SystemUser",
                        ModifiedAt = DateTime.Now,
                        NewValues = JsonSerializer.Serialize(entry.CurrentValues.ToObject()),
                    });
                }

                //if (entry.State == EntityState.Added)
                //{
                //    Console.WriteLine($"[Audit] INSERT: {entry.Entity.GetType().Name}");
                //}
                //else if (entry.State == EntityState.Modified)
                //{
                //    Console.WriteLine($"[Audit] UPDATE: {entry.Entity.GetType().Name}");
                //}
                //else if (entry.State == EntityState.Deleted)
                //{
                //    Console.WriteLine($"[Audit] DELETE: {entry.Entity.GetType().Name}");
                //}
            }
            if (auditLogs.Any())
            {
                context.Set<AuditLog>().AddRange(auditLogs);
            }
        }
    }
}
