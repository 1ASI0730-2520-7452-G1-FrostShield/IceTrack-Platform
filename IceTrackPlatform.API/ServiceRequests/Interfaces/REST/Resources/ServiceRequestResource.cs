using IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.ServiceRequests.Interfaces.REST.Resources;

public record ServiceRequestResource(
    int Id,
    int RequesterId,
    int SiteId,
    int EquipmentId,
    int AssignedTo,
    string Origin,
    EServiceRequestType Type, // Changed from string
    EServiceRequestPriority Priority, // Changed from string
    string Description,
    EServiceRequestStatus Status, // Changed from string
    DateTime? CompletedAt,
    DateTime? CanceledAt,
    int? TechnicianId);