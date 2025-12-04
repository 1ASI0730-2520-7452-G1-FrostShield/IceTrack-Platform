namespace IceTrackPlatform.API.Dashboard.Domain.Model.Commands;

/// <summary>
///     Command to remove a card from a dashboard.
/// </summary>
/// <param name="DashboardConfigId">
///     The ID of the dashboard configuration.
/// </param>
/// <param name="CardId">
///     The ID of the card to remove.
/// </param>
public record RemoveCardFromDashboardCommand(
    int DashboardConfigId,
    int CardId);