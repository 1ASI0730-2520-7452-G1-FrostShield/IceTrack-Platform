using System.ComponentModel.DataAnnotations;

namespace IceTrackPlatform.API.Reporting.Interfaces.REST.Resources;

/// <summary>
/// Represents the resource to create a reports source.
/// </summary>
/// <param name="TenantId"> The identifier of the Tenant </param>
/// <param name="Type"> The type of the report </param>
/// <param name="EquipmentId"> The identifier of the Equipment </param>
/// <param name="Title"> The title of the report </param>
/// <param name="Summary"> The summary of the report </param>
/// <param name="Content"> The content of the report </param>
/// <param name="Url"> The url of the report </param>
public record CreateReportResource(
    [Required] int TenantId,
    [Required] string Type,
    [Required] int EquipmentId,
    [Required] string Title,
    [Required] string Summary,
    [Required] string Content,
    [Required] string Url);