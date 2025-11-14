using IceTrackPlatform.API.Reporting.Domain.Model.Aggregates;
using IceTrackPlatform.API.Reporting.Domain.Model.Queries;

namespace IceTrackPlatform.API.Reporting.Domain.Services;

/// <summary>
/// Interface for Report Query Services
/// </summary>
/// <remarks>
/// This interface defines the contract for query services related to Report entities.
/// </remarks>
public interface IReportQueryServices
{
    /// <summary>
    /// Handle the GetAllReportsByTenantIdQuery
    /// </summary>
    /// <remarks>
    /// This method handles the GetAllReportsByTenantIdQuery to retrieve all
    /// Report entities associated with a specific Tenant ID.
    /// </remarks>
    /// <param name="query"> The GetAllReportsByTenantIdQuery query </param>
    /// <returns> An IEnumerable containing the Report objects </returns>
    Task<IEnumerable<Report>> Handle(GetAllReportsByTenantIdQuery query);
    
    /// <summary>
    /// Handle the GetAllReportsByEquipmentIdQuery
    /// </summary>
    /// <remarks>
    /// This method handles the GetAllReportsByEquipmentIdQuery to retrieve all
    /// Report entities associated with a specific Equipment ID.
    /// </remarks>
    /// <param name="query"> The GetAllReportsByEquipmentIdQuery query </param>
    /// <returns> An IEnumerable containing the Report objects </returns>
    Task<IEnumerable<Report>> Handle(GetAllReportsByEquipmentIdQuery query);
    
    /// <summary>
    /// Handle the GetReportByIdQuery
    /// </summary>
    /// <remarks>
    /// This method handles the GetReportByIdQuery to retrieve a
    /// Report entity by its unique identifier.
    /// </remarks>
    /// <param name="query"> The GetReportByIdQuery query </param>
    /// <returns> The Report if found; otherwise, null </returns>
    Task<Report?> Handle(GetReportByIdQuery query);
}