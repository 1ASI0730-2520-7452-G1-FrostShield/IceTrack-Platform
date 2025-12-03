using System.ComponentModel.DataAnnotations;

namespace IceTrackPlatform.API.Assets_Management.Interfaces.REST.Resources;

/// <summary>
///     Represents the resource to create a site source.
/// </summary>
public record CreateSiteResource(
    [Required] string Name,
    [Required] string Address,
    [Required] string ContactName,
    [Required] string Phone);