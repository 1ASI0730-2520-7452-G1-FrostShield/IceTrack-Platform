using System.ComponentModel.DataAnnotations;

namespace IceTrackPlatform.API.Reporting.Interfaces.REST.Resources;

/// <summary>
/// Represents the resource to update a report.
/// </summary>
/// <param name="TenantId"> The identifier of the Tenant </param>
/// <param name="EquipmentId"> The identifier of the Equipment </param>
/// <param name="Title"> The title of the report </param>
/// <param name="Status"> The status of the report </param>
/// <param name="Summary"> The summary of the report </param>
/// <param name="Content"> The content of the report </param>
/// <param name="Url"> The url of the report </param>
public record UpdateReportResource(
    [Required] int TenantId,
    [Required] int EquipmentId,
    [Required] string Title,
    [Required] string Status,
    [Required] string Summary,
    [Required] string Content,
    [Required] string Url);