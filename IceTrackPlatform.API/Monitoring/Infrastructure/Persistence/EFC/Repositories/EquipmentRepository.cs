using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class EquipmentRepository(AppDbContext context)
    : BaseRepository<Equipment>(context), IEquipmentRepository
{
    public async Task<IEnumerable<Equipment>> FindByModelAsync(string model)
    {
        return await Context.Set<Equipment>()
            .Where(e => e.Model == model)
            .ToListAsync();
    }

    public async Task<Equipment?> FindByModelAndSerialAsync(string model, string serial)
    {
        return await Context.Set<Equipment>()
            .FirstOrDefaultAsync(e => e.Model == model && e.Serial == serial);
    }
}
