using IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Assets_Management.Domain.Repositories;

/// <summary>
///     The Site Repository interface
/// </summary>
public interface ISiteRepository : IBaseRepository<Site>
{
    /// <summary>
    ///     Find Site by Name
    /// </summary>
    Task<IEnumerable<Site>> FindByNameAsync(string name);
    
    /// <summary>
    ///     Find Site by Name and Address
    /// </summary>
    Task<Site?> FindByNameAndAddressAsync(string name, string address);
}