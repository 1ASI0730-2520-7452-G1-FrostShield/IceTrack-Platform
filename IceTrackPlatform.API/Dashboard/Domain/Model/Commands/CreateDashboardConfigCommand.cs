using IceTrackPlatform.API.Dashboard.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Dashboard.Domain.Model.Commands;

/// <summary>
///     Command to create a new dashboard configuration.
/// </summary>
/// <param name="UserId">
///     The ID of the user who owns this dashboard.
/// </param>
/// <param name="DefaultSiteId">
///     The default site ID (optional).
/// </param>
/// <param name="DefaultTemperatureRangeValue">
///     The default temperature range value (e.g., "24h").
/// </param>
public record CreateDashboardConfigCommand(
    int UserId,
    int? DefaultSiteId,
    string DefaultTemperatureRangeValue);