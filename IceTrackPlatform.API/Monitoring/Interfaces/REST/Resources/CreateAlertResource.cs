using System.ComponentModel.DataAnnotations;
using IceTrackPlatform.API.Monitoring.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Monitoring.Interfaces.REST.Resources;

/// <summary>
/// Represents the resource to create an Alert.
/// </summary>
public record CreateAlertResource(
    [Required] int TenantId,
    [Required] int EquipmentId,
    [Required] int SiteId,
    [Required] string Type,
    [Required] EAlertSeverity Severity,
    [Required] string Description,
    [Required] EAlertStatus Status
);