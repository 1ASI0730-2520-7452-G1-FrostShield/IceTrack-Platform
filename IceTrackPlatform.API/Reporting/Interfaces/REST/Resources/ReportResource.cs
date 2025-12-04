namespace IceTrackPlatform.API.Reporting.Interfaces.REST.Resources;

/// <summary>
/// Represents the resource for a report.
/// </summary>
public record ReportResource(int Id, int TenantId, string Type, int EquipmentId, 
    string Title, string Status, string Summary, string Content, string Url,
    DateTimeOffset? GeneratedAt);