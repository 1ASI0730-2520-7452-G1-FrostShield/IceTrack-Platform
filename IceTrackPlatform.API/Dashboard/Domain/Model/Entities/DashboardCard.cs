using IceTrackPlatform.API.Dashboard.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Dashboard.Domain.Model.Entities;

/// <summary>
///     Represents a dashboard card entity.
/// </summary>
public class DashboardCard
{
    /// <summary>
    ///     Gets the unique identifier of the dashboard card.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    ///     Gets the ID of the dashboard configuration this card belongs to.
    /// </summary>
    public int DashboardConfigId { get; private set; }

    /// <summary>
    ///     Gets or sets the type of card.
    /// </summary>
    public CardType CardType { get; private set; }

    /// <summary>
    ///     Gets or sets the display order of the card.
    /// </summary>
    public int Order { get; private set; }

    /// <summary>
    ///     Gets or sets whether the card is visible.
    /// </summary>
    public bool IsVisible { get; private set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DashboardCard" /> class with default values.
    /// </summary>
    protected DashboardCard()
    {
        CardType = ValueObjects.CardType.MonitoredEquipment;
        IsVisible = true;
        Order = 0;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DashboardCard" /> class.
    /// </summary>
    /// <param name="cardType">The type of the card.</param>
    /// <param name="order">The display order.</param>
    /// <param name="isVisible">Whether the card is visible.</param>
    public DashboardCard(CardType cardType, int order, bool isVisible = true)
    {
        CardType = cardType;
        Order = order;
        IsVisible = isVisible;
    }

    /// <summary>
    ///     Updates the card's visibility.
    /// </summary>
    /// <param name="isVisible">The new visibility state.</param>
    public void UpdateVisibility(bool isVisible)
    {
        IsVisible = isVisible;
    }

    /// <summary>
    ///     Updates the card's order.
    /// </summary>
    /// <param name="order">The new order value.</param>
    public void UpdateOrder(int order)
    {
        if (order < 0)
            throw new ArgumentException("Order must be non-negative.", nameof(order));

        Order = order;
    }
}