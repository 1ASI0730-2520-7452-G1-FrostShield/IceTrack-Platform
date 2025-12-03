namespace IceTrackPlatform.API.ServiceRequests.Interfaces.REST.Resources;

public record RecordInterventionResource(
    int ServiceRequestId,
    int TechnicianId,
    string Summary,
    DateTime StartTime,
    DateTime? EndTime,
    List<string> PhotoUrls);