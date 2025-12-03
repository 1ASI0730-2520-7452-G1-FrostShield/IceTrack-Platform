using IceTrackPlatform.API.Dashboard.Domain.Model.Aggregates;
using IceTrackPlatform.API.Dashboard.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.Dashboard.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Dashboard configuration repository implementation.
/// </summary>
/// <param name="context">
///     The database context.
/// </param>
public class DashboardConfigRepository(AppDbContext context)
    : BaseRepository<DashboardConfig>(context), IDashboardConfigRepository
{
    /// <inheritdoc />
    public async Task<DashboardConfig?> FindByUserIdAsync(int userId)
    {
        return await Context.Set<DashboardConfig>()
            .Include(dc => dc.Cards)
            .FirstOrDefaultAsync(dc => dc.UserId == userId);
    }

    /// <inheritdoc />
    public async Task<bool> ExistsByUserIdAsync(int userId)
    {
        return await Context.Set<DashboardConfig>()
            .AnyAsync(dc => dc.UserId == userId);
    }
}