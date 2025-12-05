using IceTrackPlatform.API.Assets_Management.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IceTrackPlatform.API.Dashboard.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IceTrackPlatform.API.Feedback.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IceTrackPlatform.API.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IceTrackPlatform.API.Reporting.Domain.Model.Aggregates;
using IceTrackPlatform.API.ServiceRequests.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using IceTrackPlatform.API.Technicians.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

/// <summary>
///     Application database context for the Learning Center Platform
/// </summary>
/// <param name="options">
///     The options for the database context
/// </param>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   /// <summary>
   ///     On configuring the database context
   /// </summary>
   /// <remarks>
   ///     This method is used to configure the database context.
   ///     It also adds the created and updated date interceptor to the database context.
   /// </remarks>
   /// <param name="builder">
   ///     The option builder for the database context
   /// </param>
   /// 
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

   /// <summary>
   ///     On creating the database model
   /// </summary>
   /// <remarks>
   ///     This method is used to create the database model for the application.
   /// </remarks>
   /// <param name="builder">
   ///     The model builder for the database context
   /// </param>
   ///
   
   protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
         //Render config
         foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var dateProperties = entityType.GetProperties()
                .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?));

            foreach (var property in dateProperties)
            {
                property.SetColumnType("datetime");
            }
        }
        // IAM Context
        builder.ApplyIamConfiguration();
      
         foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
        var dateProperties = entityType.GetProperties()
            .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?));

        foreach (var property in dateProperties)
        {
            property.SetColumnType("datetime");
        }
    }
        // DASHBOARD Context
        builder.ApplyDashboardConfiguration();

        // Create all entities configurations
        
        builder.Entity<Report>().HasKey(r => r.Id);
        builder.Entity<Report>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Report>().Property(r => r.TenantId).IsRequired();
        builder.Entity<Report>().Property(r => r.Type).HasConversion<string>();
        builder.Entity<Report>().Property(r => r.EquipmentId).IsRequired();
        builder.Entity<Report>().Property(r => r.Status).HasConversion<string>().IsRequired();

        // Assets Management Context
        builder.ApplyAssetsManagementConfiguration();
        
        // Monitoring Context
        builder.ApplyMonitoringConfiguration();
      
        // ServiceRequests Context
        builder.ApplyServiceRequestsConfiguration();

        // Technicians Context
        builder.ApplyTechniciansConfiguration();
        
        // Feedback Context
        builder.ApplyFeedbackConfiguration();
      
        // General Naming Convention for the database objects
        builder.UseSnakeCaseNamingConvention();
    }
}
