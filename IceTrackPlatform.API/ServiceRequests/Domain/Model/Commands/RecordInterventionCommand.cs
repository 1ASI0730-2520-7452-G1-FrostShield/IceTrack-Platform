namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.Commands;

public record RecordInterventionCommand(
    int ServiceRequestId,
    int TechnicianId,
    string Summary,
    DateTime StartTime,
    DateTime? EndTime,
    List<string> PhotoUrls);