using IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;
using IceTrackPlatform.API.Assets_Management.Domain.Model.Queries;
using IceTrackPlatform.API.Assets_Management.Domain.Repositories;
using IceTrackPlatform.API.Assets_Management.Domain.Services;

namespace IceTrackPlatform.API.Assets_Management.Application.Internal.QueryServices;

/// <summary>
///     Site Query Service
/// </summary>
public class SiteQueryService(ISiteRepository siteRepository)
    : ISiteQueryServices
{
    public async Task<IEnumerable<Site>> Handle(GetAllSitesByNameQuery query)
    {
        return await siteRepository.FindByNameAsync(query.Name);
    }

    public async Task<Site?> Handle(GetSiteByNameAndAddressQuery query)
    {
        return await siteRepository.FindByNameAndAddressAsync(query.Name, query.Address);
    }

    public async Task<Site?> Handle(GetSiteByIdQuery query)
    {
        return await siteRepository.FindByIdAsync(query.Id);
    }
}
