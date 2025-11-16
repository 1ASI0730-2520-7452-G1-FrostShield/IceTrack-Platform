namespace IceTrackPlatform.API.Monitoring.Domain.Model.Commands;

public record CreateEquipmentCommand(string Model, string Type, string Serial, string Status);
