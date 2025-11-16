using System.ComponentModel.DataAnnotations;

namespace IceTrackPlatform.API.Dashboard.Interfaces.REST.Resources;

/// <summary>
///     Resource for updating a dashboard configuration.
/// </summary>
/// <param name="DefaultSiteId">
///     The new default site ID.
/// </param>
/// <param name="DefaultTemperatureRangeValue">
///     The new default temperature range.
/// </param>
public record UpdateDashboardConfigResource(
    int? DefaultSiteId,
    [Required] string DefaultTemperatureRangeValue);