using IceTrackPlatform.API.Dashboard.Domain.Model.Aggregates;
using IceTrackPlatform.API.Dashboard.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.Dashboard.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Model builder extensions for Dashboard context.
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Applies the Dashboard context configuration to the model builder.
    /// </summary>
    /// <param name="builder">
    ///     The model builder.
    /// </param>
    public static void ApplyDashboardConfiguration(this ModelBuilder builder)
    {
        // DashboardConfig entity configuration
        builder.Entity<DashboardConfig>().HasKey(dc => dc.Id);
        builder.Entity<DashboardConfig>().Property(dc => dc.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<DashboardConfig>().Property(dc => dc.UserId).IsRequired();
        builder.Entity<DashboardConfig>().Property(dc => dc.DefaultSiteId);

        // TemperatureRange Value Object (Owned Entity)
        builder.Entity<DashboardConfig>().OwnsOne(dc => dc.DefaultTemperatureRange,
            tr =>
            {
                tr.WithOwner().HasForeignKey("Id");
                tr.Property(t => t.Value).HasColumnName("DefaultTemperatureRangeValue").IsRequired();
                tr.Property(t => t.Label).HasColumnName("DefaultTemperatureRangeLabel").IsRequired();
            });

        // Unique constraint: one dashboard config per user
        builder.Entity<DashboardConfig>().HasIndex(dc => dc.UserId).IsUnique();

        // DashboardCard entity configuration
        builder.Entity<DashboardCard>().HasKey(dc => dc.Id);
        builder.Entity<DashboardCard>().Property(dc => dc.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<DashboardCard>().Property(dc => dc.DashboardConfigId).IsRequired();
        builder.Entity<DashboardCard>().Property(dc => dc.CardType).HasConversion<string>().IsRequired();
        builder.Entity<DashboardCard>().Property(dc => dc.Order).IsRequired();
        builder.Entity<DashboardCard>().Property(dc => dc.IsVisible).IsRequired();

        // Relationship: DashboardConfig -> DashboardCards (1:N)
        builder.Entity<DashboardConfig>()
            .HasMany(dc => dc.Cards)
            .WithOne()
            .HasForeignKey(c => c.DashboardConfigId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}