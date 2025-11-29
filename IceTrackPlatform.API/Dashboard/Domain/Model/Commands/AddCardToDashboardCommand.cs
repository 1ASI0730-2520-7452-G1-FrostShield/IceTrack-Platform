using IceTrackPlatform.API.Dashboard.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Dashboard.Domain.Model.Commands;

/// <summary>
///     Command to add a card to a dashboard.
/// </summary>
/// <param name="DashboardConfigId">
///     The ID of the dashboard configuration.
/// </param>
/// <param name="CardType">
///     The type of card to add.
/// </param>
/// <param name="Order">
///     The display order of the card.
/// </param>
/// <param name="IsVisible">
///     Whether the card is visible.
/// </param>
public record AddCardToDashboardCommand(
    int DashboardConfigId,
    CardType CardType,
    int Order,
    bool IsVisible = true);