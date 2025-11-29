using IceTrackPlatform.API.IAM.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IceTrackPlatform.API.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIamConfiguration(this ModelBuilder builder)
    {
        // IAM Context

        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        builder.Entity<User>()
            .Property(u => u.Role)
            .IsRequired()
            .HasConversion<string>(); 
    }
}