using IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;
using IceTrackPlatform.API.Assets_Management.Domain.Model.Commands;
using IceTrackPlatform.API.Assets_Management.Domain.Repositories;
using IceTrackPlatform.API.Assets_Management.Domain.Services;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Assets_Management.Application.Internal.CommandServices;

/// <summary>
/// This class handles commands related to Site entities.
/// </summary>
public class SiteCommandService(ISiteRepository siteRepository,
                                    IUnitOfWork unitOfWork)
    : ISiteCommandService
{
    public async Task<Site?> Handle(CreateSiteCommand command)
    {
        var site =
            await siteRepository.FindByNameAndAddressAsync(command.Name, command.Address);
        if (site != null)
            throw new Exception("Site already exists.");
        site = new Site(command);
        try
        {
            await siteRepository.AddAsync(site);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            return null;
        }
        return site;
    }
}
