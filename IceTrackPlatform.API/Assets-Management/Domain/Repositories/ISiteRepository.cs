using IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Assets_Management.Domain.Repositories;

public interface ISiteRepository : IBaseRepository<Site>
{
    /// <summary>
    ///     Find Site by News API Key
    /// </summary>
    /// <param name="contactName">The contact name Key</param>
    /// <returns>
    ///     Enumerable of Site if found; otherwise, an empty Enumerable
    /// </returns>
    Task<IEnumerable<Site>> FindByContactNameAsync(string contactName);
}