namespace IceTrackPlatform.API.Dashboard.Domain.Model.Commands;

/// <summary>
///     Command to update an existing dashboard configuration.
/// </summary>
/// <param name="DashboardConfigId">
///     The ID of the dashboard configuration to update.
/// </param>
/// <param name="DefaultSiteId">
///     The new default site ID (optional).
/// </param>
/// <param name="DefaultTemperatureRangeValue">
///     The new default temperature range value.
/// </param>
public record UpdateDashboardConfigCommand(
    int DashboardConfigId,
    int? DefaultSiteId,
    string DefaultTemperatureRangeValue);