using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Queries;

namespace IceTrackPlatform.API.Monitoring.Domain.Services;

/// <summary>
/// Interface for Alert Query Services
/// </summary>
/// <remarks>
/// This interface defines the contract for query services related to Alert entities.
/// </remarks>
public interface IAlertQueryServices
{
    /// <summary>
    /// Handle the GetAllAlertsByTenantIdQuery
    /// </summary>
    /// <remarks>
    /// This method handles the GetAllAlertsByTenantIdQuery to retrieve all
    /// Alert entities associated with a specific Tenant ID.
    /// </remarks>
    /// <param name="query"> The GetAllAlertsByTenantIdQuery query </param>
    /// <returns> An IEnumerable containing the Alert objects </returns>
    Task<IEnumerable<Alert>> Handle(GetAllAlertsByTenantIdQuery query);
    
    /// <summary>
    /// Handle the GetAllAlertsByEquipmentIdQuery
    /// </summary>
    /// <remarks>
    /// This method handles the GetAllAlertsByEquipmentIdQuery to retrieve all
    /// Alert entities associated with a specific Equipment ID.
    /// </remarks>
    /// <param name="query"> The GetAllAlertsByEquipmentIdQuery query </param>
    /// <returns> An IEnumerable containing the Alert objects </returns>
    Task<IEnumerable<Alert>> Handle(GetAllAlertsByEquipmentIdQuery query);
    
    /// <summary>
    /// Handle the GetAlertByIdQuery
    /// </summary>
    /// <remarks>
    /// This method handles the GetAlertByIdQuery to retrieve an
    /// Alert entity by its unique identifier.
    /// </remarks>
    /// <param name="query"> The GetAlertByIdQuery query </param>
    /// <returns> The Alert if found; otherwise, null </returns>
    Task<Alert?> Handle(GetAlertByIdQuery query);
    /// <summary>
    /// Handle the GetAllAlertsQuery
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<IEnumerable<Alert>> Handle(GetAllAlertsQuery query);
}