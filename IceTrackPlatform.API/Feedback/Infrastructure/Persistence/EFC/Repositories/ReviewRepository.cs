using IceTrackPlatform.API.Feedback.Domain.Model.Aggregates;
using IceTrackPlatform.API.Feedback.Domain.Repositories;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using IceTrackPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IceTrackPlatform.API.Feedback.Infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository(AppDbContext context) : BaseRepository<Review>(context), IReviewRepository
{
    public async Task<IEnumerable<Review>> FindByServiceRequestIdAsync(int serviceRequestId)
    {
        return await Context.Set<Review>().Where(r => r.ServiceRequestId == serviceRequestId).ToListAsync();
    }

    public new async Task<IEnumerable<Review>> ListAsync()
    {
        return await Context.Set<Review>().ToListAsync();
    }
}