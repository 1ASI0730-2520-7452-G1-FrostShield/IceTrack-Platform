using IceTrackPlatform.API.Feedback.Domain.Model.Aggregates;
using IceTrackPlatform.API.Feedback.Interfaces.REST.Resources;

namespace IceTrackPlatform.API.Feedback.Interfaces.REST.Transform;

public static class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(Review entity)
    {
        return new ReviewResource(
            entity.Id,
            entity.ServiceRequestId,
            entity.OwnerId,
            entity.TechnicianId,
            entity.Rating.Value,
            entity.Comment);
    }
}