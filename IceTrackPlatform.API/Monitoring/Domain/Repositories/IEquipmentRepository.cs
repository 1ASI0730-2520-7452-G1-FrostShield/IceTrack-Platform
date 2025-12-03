using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Monitoring.Domain.Repositories;

/// <summary>
///     The Equipment Repository interface
/// </summary>
public interface IEquipmentRepository : IBaseRepository<Equipment>
{
    /// <summary>
    ///     Find Equipment by Type Key
    /// </summary>
    /// <param name="type">The type Key</param>
    /// <returns>
    ///     An Enumerable of Equipment if found; otherwise, an empty Enumerable
    /// </returns>
    Task<IEnumerable<Equipment>> FindByTypeAsync(string type);
    
    /// <summary>
    ///     Find equipment by Manufacturer Key and Online
    /// </summary>
    /// <param name="manufacturer">The manufacturer key</param>
    /// <param name="online">The online key</param>
    /// <returns>
    ///     The equipment if found; otherwise, null
    /// </returns>
    Task<Equipment?> FindByManufacturerAndOnlineAsync(string manufacturer, bool online);
}