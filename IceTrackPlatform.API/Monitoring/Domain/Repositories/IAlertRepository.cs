using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Monitoring.Domain.Repositories;

public interface IAlertRepository : IBaseRepository<Alert>
{
    /// <summary>
    /// Find Alerts by Tenant ID
    /// </summary>
    /// <param name="tenantId"> The identifier of a Tenant </param>
    /// <returns>
    /// An Enum of Alert if found; otherwise, an empty Enumerable
    /// </returns>
    Task<IEnumerable<Alert>> FindByTenantIdAsync(int tenantId);

    /// <summary>
    /// Find Alerts by Equipment ID
    /// </summary>
    /// <param name="equipmentId"> The identifier of an Equipment </param>
    /// <returns>
    /// An Enum of Alert if found; otherwise, an empty Enumerable
    /// </returns>
    Task<IEnumerable<Alert>> FindByEquipmentIdAsync(int equipmentId);
}