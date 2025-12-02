namespace IceTrackPlatform.API.Feedback.Interfaces.REST.Resources;

public record CreateReviewResource(int ServiceRequestId, int OwnerId, int TechnicianId, int Rating, string Comment);
