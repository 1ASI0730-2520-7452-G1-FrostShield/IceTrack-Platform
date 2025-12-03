using System.ComponentModel.DataAnnotations;

namespace IceTrackPlatform.API.Dashboard.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating a dashboard configuration.
/// </summary>
/// <param name="UserId">
///     The ID of the user.
/// </param>
/// <param name="DefaultSiteId">
///     The default site ID (optional).
/// </param>
/// <param name="DefaultTemperatureRangeValue">
///     The default temperature range (e.g., "24h", "7d").
/// </param>
public record CreateDashboardConfigResource(
    [Required] int UserId,
    int? DefaultSiteId,
    [Required] string DefaultTemperatureRangeValue);