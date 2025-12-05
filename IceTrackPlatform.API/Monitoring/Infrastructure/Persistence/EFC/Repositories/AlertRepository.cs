using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Alert Repository Implementation
/// </summary>
/// <remarks>
/// This class implements the repository pattern for managing Alert entities using Entity Framework Core.
/// It provides methods to perform CRUD operations and custom queries specific to Alert.
/// </remarks>
/// <param name="context"></param>
public class AlertRepository(AppDbContext context)
    : BaseRepository<Alert>(context), IAlertRepository
{
    public async Task<IEnumerable<Alert>> FindByTenantIdAsync(int tenantId)
    {
        return await Context.Set<Alert>()
            .Where(a => a.TenantId == tenantId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Alert>> FindByEquipmentIdAsync(int equipmentId)
    {
        return await Context.Set<Alert>()
            .Where(a => a.EquipmentId == equipmentId)
            .ToListAsync();
    }
}