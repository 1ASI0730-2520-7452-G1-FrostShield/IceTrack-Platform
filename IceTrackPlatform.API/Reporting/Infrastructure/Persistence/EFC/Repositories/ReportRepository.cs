using IceTrackPlatform.API.Reporting.Domain.Model.Aggregates;
using IceTrackPlatform.API.Reporting.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.Reporting.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Report Repository Implementation
/// </summary>
/// <remarks>
/// This class implements the repository pattern for managing Report entities using Entity Framework Core.
/// It provides methods to perform CRUD operations and custom queries specific to Report.
/// </remarks>
/// <param name="context"></param>
public class ReportRepository(AppDbContext context)
: BaseRepository<Report>(context), IReportRepository
{
    public async Task<IEnumerable<Report>> FindByTenantIdAsync(int tenantId)
    {
        return await Context.Set<Report>().Where( r => r.TenantId == tenantId).ToListAsync();
    }

    public async Task<IEnumerable<Report>> FindByEquipmentIdAsync(int equipmentId)
    {
        return await Context.Set<Report>().Where( r => r.EquipmentId == equipmentId).ToListAsync();
    }
}