using System.ComponentModel.DataAnnotations;

namespace IceTrackPlatform.API.Monitoring.Interfaces.REST.Resources;

public record CreateEquipmentResource(
    [Required] string Model,
    [Required] string Type,
    [Required] string Serial,
    [Required] string Status);
