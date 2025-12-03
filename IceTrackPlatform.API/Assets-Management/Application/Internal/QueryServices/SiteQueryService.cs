using IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;
using IceTrackPlatform.API.Assets_Management.Domain.Model.Queries;
using IceTrackPlatform.API.Assets_Management.Domain.Repositories;
using IceTrackPlatform.API.Assets_Management.Domain.Services;

namespace IceTrackPlatform.API.Assets_Management.Application.Internal.QueryServices;

/// <summary>
///     Site Query Service
/// </summary>
/// <remarks>
///     This class handles queries related to favorite news sources.
///     It interacts with the ISiteQueryServices to retrieve data.
/// </remarks>
/// <param name="siteRepository"></param>
public class SiteQueryService(ISiteRepository siteRepository)
    : ISiteQueryServices
{
    public async Task<IEnumerable<Site>> Handle(GetAllSitesByContactNameQuery query)
    {
        return await siteRepository.FindByContactNameAsync(query.ContactName);
    }

    public async Task<Site?> Handle(GetSiteByIdQuery query)
    {
        return await siteRepository.FindByIdAsync(query.Id);
    }
}