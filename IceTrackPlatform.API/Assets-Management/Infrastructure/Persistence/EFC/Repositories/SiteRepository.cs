using IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;
using IceTrackPlatform.API.Assets_Management.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.Assets_Management.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Site Repository Implementation
/// </summary>
/// <remarks>
///     This class implements the repository pattern for managing Site entities using Entity Framework Core.
///     It provides methods to perform CRUD operations and custom queries specific to Site.
/// </remarks>
/// <param name="context"></param>
public class SiteRepository(AppDbContext context)
    : BaseRepository<Site>(context), ISiteRepository
{
    public async Task<IEnumerable<Site>> FindByContactNameAsync(string contactName)
    {
        return await Context.Set<Site>().Where( f => f.ContactName == contactName).ToListAsync();
    }
}