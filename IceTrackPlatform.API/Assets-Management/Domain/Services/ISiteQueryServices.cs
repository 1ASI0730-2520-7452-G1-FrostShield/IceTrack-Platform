using IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;
using IceTrackPlatform.API.Assets_Management.Domain.Model.Queries;

namespace IceTrackPlatform.API.Assets_Management.Domain.Services;

/// <summary>
///     Interface for Site Query Services
/// </summary>
public interface ISiteQueryServices
{
    /// <summary>
    ///     Handle the GetAllSitesByNameQuery
    /// </summary>
    Task<IEnumerable<Site>> Handle(GetAllSitesByNameQuery query);
    
    /// <summary>
    ///     Handle the GetSiteByNameAndAddressQuery
    /// </summary>
    Task<Site?> Handle(GetSiteByNameAndAddressQuery query);
    
    /// <summary>
    ///     Handle the GetSiteByIdQuery 
    /// </summary>
    Task<Site?> Handle(GetSiteByIdQuery query);
}