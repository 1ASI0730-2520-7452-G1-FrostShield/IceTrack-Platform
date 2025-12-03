using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class EquipmentRepository(AppDbContext context)
    : BaseRepository<Equipment>(context), IEquipmentRepository
{
    public async Task<IEnumerable<Equipment>> FindByTypeAsync(string type)
    {
        return await Context.Set<Equipment>().Where( f => f.Type == type).ToListAsync();
    }

    public async Task<Equipment?> FindByManufacturerAndOnlineAsync(string manufacturer, bool online)
    {
        return await Context.Set<Equipment>()
            .FirstOrDefaultAsync(f => f.Manufacturer == manufacturer && f.Online == online);
    }
}