using IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;
using IceTrackPlatform.API.Assets_Management.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.Assets_Management.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Site Repository Implementation
/// </summary>
public class SiteRepository(AppDbContext  context)
    : BaseRepository<Site>(context), ISiteRepository
{
    public async Task<IEnumerable<Site>> FindByNameAsync(string name)
    {
        return await Context.Set<Site>().Where( f => f.Name == name).ToListAsync();
    }

    public async Task<Site?> FindByNameAndAddressAsync(string name, string address)
    {
        return await Context.Set<Site>()
            .FirstOrDefaultAsync(f => f.Name == name && f.Address == address);
    }
}