using IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;
using IceTrackPlatform.API.Assets_Management.Domain.Model.Queries;

namespace IceTrackPlatform.API.Assets_Management.Domain.Services;

/// <summary>
///     Interface for Site Query Services
/// </summary>
/// <remarks>
///     This interface defines the contract for query services related to Site entities.
/// </remarks>
public interface ISiteQueryServices
{
    /// <summary>
    ///     Handle the GetSiteByIdQuery 
    /// </summary>
    /// <remarks>
    ///     This method handles the GetSiteByIdQuery to retrieve a
    ///     Site entity by its unique identifier.
    /// </remarks>
    /// <param name="query">The GetSiteByIdQuery query</param>
    /// <returns>
    ///     The Site if found; otherwise, null
    /// </returns>
    Task<Site?> Handle(GetSiteByIdQuery query);   
    
    /// <summary>
    ///     Handle the GetAllSitesQuery 
    /// </summary>
    Task<IEnumerable<Site>> Handle(GetAllSitesQuery query);
}