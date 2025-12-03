using IceTrackPlatform.API.Feedback.Domain.Model.Aggregates;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Feedback.Domain.Repositories;

public interface IReviewRepository : IBaseRepository<Review>
{
    Task<IEnumerable<Review>> FindByServiceRequestIdAsync(int serviceRequestId);
    new Task<IEnumerable<Review>> ListAsync();
}

