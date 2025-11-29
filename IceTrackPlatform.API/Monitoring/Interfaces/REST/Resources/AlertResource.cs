using IceTrackPlatform.API.Monitoring.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Monitoring.Interfaces.REST.Resources;

/// <summary>
/// Represents the resource for an Alert.
/// </summary>
public record AlertResource(
    int Id,
    int TenantId,
    int EquipmentId,
    int SiteId,
    string Type,
    EAlertSeverity Severity,
    string Description,
    EAlertStatus Status
);
