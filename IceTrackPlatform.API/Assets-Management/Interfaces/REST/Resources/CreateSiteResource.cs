using System.ComponentModel.DataAnnotations;

namespace IceTrackPlatform.API.Assets_Management.Interfaces.REST.Resources;

/// <summary>
///     Represents the resource to create a site.
/// </summary>
public record CreateSiteResource(
    [Required] string Name,
    [Required] string Address);