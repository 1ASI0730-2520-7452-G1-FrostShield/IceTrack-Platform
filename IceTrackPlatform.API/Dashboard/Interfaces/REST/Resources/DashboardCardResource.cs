namespace IceTrackPlatform.API.Dashboard.Interfaces.REST.Resources;

/// <summary>
///     Resource representing a dashboard card.
/// </summary>
/// <param name="Id">
///     The card ID.
/// </param>
/// <param name="CardType">
///     The type of card.
/// </param>
/// <param name="Order">
///     The display order.
/// </param>
/// <param name="IsVisible">
///     Whether the card is visible.
/// </param>
public record DashboardCardResource(
    int Id,
    string CardType,
    int Order,
    bool IsVisible);