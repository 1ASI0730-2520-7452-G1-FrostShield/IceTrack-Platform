namespace IceTrackPlatform.API.Monitoring.Interfaces.REST.Resources;

public record EquipmentResource(
    int Id,
    string Model,
    string Type,
    string Serial,
    string Status);
