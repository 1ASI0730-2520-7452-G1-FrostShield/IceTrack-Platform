using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Queries;

namespace IceTrackPlatform.API.Monitoring.Domain.Services;

/// <summary>
///     Interface for Equipment Query Services
/// </summary>
/// <remarks>
///     This interface defines the contract for query services related to Equipment entities.
/// </remarks>
public interface IEquipmentQueryServices
{
    /// <summary>
    ///     Handle the GetEquipmentByIdQuery 
    /// </summary>
    /// <remarks>
    ///     This method handles the GetEquipmentByIdQuery to retrieve an
    ///     Equipment entity by its unique identifier.
    /// </remarks>
    /// <param name="query">The GetEquipmentByIdQuery query</param>
    /// <returns>
    ///     The Equipment if found; otherwise, null
    /// </returns>
    Task<Equipment?> Handle(GetEquipmentByIdQuery query);
    
    /// <summary>
    ///     Handle the GetAllEquipmentQuery 
    /// </summary>
    Task<IEnumerable<Equipment?>> Handle(GetAllEquipmentQuery query);
}