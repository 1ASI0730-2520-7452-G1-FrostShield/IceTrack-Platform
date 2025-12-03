using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyMonitoringConfiguration(this ModelBuilder builder)
    {
        // Assets Management Context
        builder.Entity<Equipment>().HasKey(e => e.Id);
        builder.Entity<Equipment>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Equipment>().Property(e => e.EquipmentId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Equipment>().Property(e => e.Model).IsRequired();
        builder.Entity<Equipment>().Property(e => e.Type).IsRequired();
        builder.Entity<Equipment>().Property(e => e.Serial).IsRequired();
        builder.Entity<Equipment>().Property(e => e.Status).IsRequired();
        builder.Entity<Equipment>().Property(e => e.Installed).IsRequired();
        builder.Entity<Equipment>().Property(e => e.LastSeen).IsRequired();
        builder.Entity<Equipment>().Property(e => e.SetPoint).IsRequired();
        builder.Entity<Equipment>().Property(e => e.Name).IsRequired();
        builder.Entity<Equipment>().Property(e => e.Manufacturer).IsRequired();
        builder.Entity<Equipment>().Property(e => e.Online).IsRequired();
    }
}