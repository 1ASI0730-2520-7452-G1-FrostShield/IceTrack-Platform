using System.ComponentModel.DataAnnotations;

namespace IceTrackPlatform.API.Dashboard.Interfaces.REST.Resources;

/// <summary>
///     Resource for updating card visibility.
/// </summary>
/// <param name="IsVisible">
///     Whether the card should be visible.
/// </param>
public record UpdateCardVisibilityResource(
    [Required] bool IsVisible);