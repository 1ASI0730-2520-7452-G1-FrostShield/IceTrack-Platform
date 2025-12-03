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
    ///     Handle the GetAllEquipmentByTypeQuery
    /// </summary>
    /// <remarks>
    ///     This method handles the GetAllEquipmentByTypeQuery to retrieve all
    ///     Equipment entities associated with a specific News API key.
    /// </remarks>
    /// <param name="query">The GetAllEquipmentByTypeQuery query</param>
    /// <returns>An IEnumerable containing the Equipment objects</returns>
    Task<IEnumerable<Equipment>> Handle(GetAllEquipmentByTypeQuery query);
    
    /// <summary>
    ///     Handle the GetEquipmentByManufacturerAndOnlineQuery
    /// </summary>
    /// <remarks>
    ///     This method handles the GetEquipmentByManufacturerAndOnlineQuery to retrieve an
    ///     Equipment entity based on the provided Manufacturer and Online.
    /// </remarks>
    /// <param name="query">The GetEquipmentByManufacturerAndOnlineQuery query</param>
    /// <returns>The Equipment object if found, or null otherwise</returns>
    Task<Equipment?> Handle(GetEquipmentByManufacturerAndOnlineQuery query);
    
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
}