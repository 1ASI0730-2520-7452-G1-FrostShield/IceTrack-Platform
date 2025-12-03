using IceTrackPlatform.API.ServiceRequests.Domain.Model.Aggregates;
using IceTrackPlatform.API.ServiceRequests.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.ServiceRequests.Infrastructure.Persistence.EFC.Repositories;

public class InterventionRepository(AppDbContext context) : BaseRepository<Intervention>(context), IInterventionRepository
{
    public async Task<IEnumerable<Intervention>> FindByServiceRequestIdAsync(int serviceRequestId)
    {
        return await Context.Set<Intervention>().Where(i => i.ServiceRequestId.Value == serviceRequestId).ToListAsync(); // Changed from .Id to .Value
    }

    public new async Task<IEnumerable<Intervention>> ListAsync()
    {
        return await Context.Set<Intervention>().ToListAsync();
    }
}