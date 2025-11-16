namespace IceTrackPlatform.API.Dashboard.Domain.Model.Commands;

/// <summary>
///     Command to delete a dashboard configuration.
/// </summary>
/// <param name="DashboardConfigId">
///     The ID of the dashboard configuration to delete.
/// </param>
public record DeleteDashboardConfigCommand(int DashboardConfigId);