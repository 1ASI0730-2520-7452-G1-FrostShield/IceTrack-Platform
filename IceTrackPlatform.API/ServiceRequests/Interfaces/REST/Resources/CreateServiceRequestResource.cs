using IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.ServiceRequests.Interfaces.REST.Resources;

public record CreateServiceRequestResource(
    int RequesterId,
    int SiteId,
    int EquipmentId,
    int AssignedTo,
    string Origin,
    string Type,
    string Priority,
    string Description);