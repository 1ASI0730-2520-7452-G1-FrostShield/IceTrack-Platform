using IceTrackPlatform.API.Reporting.Domain.Model.Aggregates;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Reporting.Domain.Repositories;

public interface IReportRepository : IBaseRepository<Report>
{
    /// <summary>
    /// Find Reports by Tenant ID
    /// </summary>
    /// <param name="tenantId"> The identifier of a Tenant </param>
    /// <returns>
    /// An Enumerable of Report if found; otherwise, an empty Enumerable
    /// </returns>
    Task<IEnumerable<Report>> FindByTenantIdAsync(int tenantId);
    
    /// <summary>
    /// Find Reports by Equipment ID
    /// </summary>
    /// <param name="equipmentId"> The identifier of an Equipment </param>
    /// <returns>
    /// An Enumerable of Report if found; otherwise, an empty Enumerable
    /// </returns>
    Task<IEnumerable<Report>> FindByEquipmentIdAsync(int equipmentId);
}