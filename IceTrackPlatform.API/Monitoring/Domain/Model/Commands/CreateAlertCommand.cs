using IceTrackPlatform.API.Monitoring.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Monitoring.Domain.Model.Commands;

/// <summary>
/// Command used to create a new Alert entity.
/// </summary>
/// <param name="TenantId">Identifier of the tenant that owns the alert.</param>
/// <param name="EquipmentId">Identifier of the equipment where the alert originated.</param>
/// <param name="SiteId">Identifier of the site associated with the alert.</param>
/// <param name="Type">The type or category of the alert.</param>
/// <param name="Severity">The severity level of the alert.</param>
/// <param name="Title">Short descriptive title of the alert.</param>
/// <param name="Description">Detailed explanation of the alert.</param>
/// <param name="Date">Date and time when the alert occurred.</param>
/// <param name="Status">Current status of the alert.</param>
public record CreateAlertCommand(
    int TenantId,
    int EquipmentId,
    int SiteId,
    string Type,
    EAlertSeverity Severity,
    string Description,
    DateTime Date,
    EAlertStatus Status
);