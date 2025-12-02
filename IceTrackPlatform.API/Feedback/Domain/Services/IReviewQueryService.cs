using IceTrackPlatform.API.Feedback.Domain.Model.Aggregates;
using IceTrackPlatform.API.Feedback.Domain.Model.Queries;

namespace IceTrackPlatform.API.Feedback.Domain.Services;

public interface IReviewQueryService
{
    Task<Review?> Handle(GetReviewByIdQuery query);
    Task<IEnumerable<Review>> Handle(GetReviewsByServiceRequestIdQuery query);
    Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query);
}
