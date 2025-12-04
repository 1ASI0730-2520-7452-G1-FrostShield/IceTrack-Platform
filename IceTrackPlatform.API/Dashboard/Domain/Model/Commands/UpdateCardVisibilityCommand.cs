namespace IceTrackPlatform.API.Dashboard.Domain.Model.Commands;

/// <summary>
///     Command to update a card's visibility.
/// </summary>
/// <param name="DashboardConfigId">
///     The ID of the dashboard configuration.
/// </param>
/// <param name="CardId">
///     The ID of the card to update.
/// </param>
/// <param name="IsVisible">
///     The new visibility state.
/// </param>
public record UpdateCardVisibilityCommand(
    int DashboardConfigId,
    int CardId,
    bool IsVisible);