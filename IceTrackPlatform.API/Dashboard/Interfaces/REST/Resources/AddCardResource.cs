using System.ComponentModel.DataAnnotations;

namespace IceTrackPlatform.API.Dashboard.Interfaces.REST.Resources;

/// <summary>
///     Resource for adding a card to a dashboard.
/// </summary>
/// <param name="CardType">
///     The type of card to add.
/// </param>
/// <param name="Order">
///     The display order.
/// </param>
/// <param name="IsVisible">
///     Whether the card is visible.
/// </param>
public record AddCardResource(
    [Required] string CardType,
    [Required] int Order,
    bool IsVisible = true);