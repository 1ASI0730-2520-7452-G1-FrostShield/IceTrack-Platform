using IceTrackPlatform.API.Feedback.Domain.Model.Aggregates;
using IceTrackPlatform.API.Feedback.Domain.Model.Queries;
using IceTrackPlatform.API.Feedback.Domain.Repositories;
using IceTrackPlatform.API.Feedback.Domain.Services;

namespace IceTrackPlatform.API.Feedback.Application.Internal.QueryServices;

public class ReviewQueryService(IReviewRepository reviewRepository) : IReviewQueryService
{
    public async Task<Review?> Handle(GetReviewByIdQuery query)
    {
        return await reviewRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Review>> Handle(GetReviewsByServiceRequestIdQuery query)
    {
        return await reviewRepository.FindByServiceRequestIdAsync(query.ServiceRequestId);
    }

    public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query)
    {
        return await reviewRepository.ListAsync();
    }
}

