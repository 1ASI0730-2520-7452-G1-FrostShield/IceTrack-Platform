using IceTrackPlatform.API.Dashboard.Domain.Model.Commands;
using IceTrackPlatform.API.Dashboard.Domain.Model.Entities;
using IceTrackPlatform.API.Dashboard.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Dashboard.Domain.Model.Aggregates;

/// <summary>
///     Dashboard Configuration Aggregate Root.
/// </summary>
/// <remarks>
///     This class represents the dashboard configuration for a user.
///     It manages the dashboard cards and their settings.
/// </remarks>
public partial class DashboardConfig
{
    private readonly List<DashboardCard> _cards = [];

    /// <summary>
    ///     Initializes a new instance of the <see cref="DashboardConfig" /> class with default values.
    /// </summary>
    public DashboardConfig()
    {
        UserId = 0;
        DefaultTemperatureRange = new TemperatureRange();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DashboardConfig" /> class.
    /// </summary>
    /// <param name="userId">The ID of the user who owns this dashboard.</param>
    /// <param name="defaultSiteId">The default site ID (optional).</param>
    /// <param name="defaultTemperatureRangeValue">The default temperature range value.</param>
    public DashboardConfig(int userId, int? defaultSiteId, string defaultTemperatureRangeValue)
    {
        UserId = userId;
        DefaultSiteId = defaultSiteId;
        DefaultTemperatureRange = ParseTemperatureRange(defaultTemperatureRangeValue);
        InitializeDefaultCards();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DashboardConfig" /> class from a command.
    /// </summary>
    /// <param name="command">The create dashboard config command.</param>
    public DashboardConfig(CreateDashboardConfigCommand command)
    {
        UserId = command.UserId;
        DefaultSiteId = command.DefaultSiteId;
        DefaultTemperatureRange = ParseTemperatureRange(command.DefaultTemperatureRangeValue);
        InitializeDefaultCards();
    }

    /// <summary>
    ///     Gets the unique identifier of the dashboard configuration.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    ///     Gets the ID of the user who owns this dashboard.
    /// </summary>
    public int UserId { get; private set; }

    /// <summary>
    ///     Gets or sets the default site ID.
    /// </summary>
    public int? DefaultSiteId { get; private set; }

    /// <summary>
    ///     Gets the default temperature range.
    /// </summary>
    public TemperatureRange DefaultTemperatureRange { get; private set; }

    /// <summary>
    ///     Gets the collection of dashboard cards.
    /// </summary>
    public IReadOnlyCollection<DashboardCard> Cards => _cards.AsReadOnly();

    /// <summary>
    ///     Updates the dashboard configuration.
    /// </summary>
    /// <param name="command">The update command.</param>
    public void Update(UpdateDashboardConfigCommand command)
    {
        DefaultSiteId = command.DefaultSiteId;
        DefaultTemperatureRange = ParseTemperatureRange(command.DefaultTemperatureRangeValue);
    }

    /// <summary>
    ///     Adds a card to the dashboard.
    /// </summary>
    /// <param name="command">The add card command.</param>
    public void AddCard(AddCardToDashboardCommand command)
    {
        // Check if card type already exists
        if (_cards.Any(c => c.CardType == command.CardType))
            throw new InvalidOperationException($"Card of type {command.CardType} already exists.");

        var card = new DashboardCard(command.CardType, command.Order, command.IsVisible);
        _cards.Add(card);
    }

    /// <summary>
    ///     Removes a card from the dashboard.
    /// </summary>
    /// <param name="cardId">The ID of the card to remove.</param>
    public void RemoveCard(int cardId)
    {
        var card = _cards.FirstOrDefault(c => c.Id == cardId);
        if (card != null)
            _cards.Remove(card);
    }

    /// <summary>
    ///     Reorders the dashboard cards.
    /// </summary>
    /// <param name="command">The reorder command.</param>
    public void ReorderCards(ReorderCardsCommand command)
    {
        foreach (var (cardId, newOrder) in command.CardOrders)
        {
            var card = _cards.FirstOrDefault(c => c.Id == cardId);
            card?.UpdateOrder(newOrder);
        }
    }

    /// <summary>
    ///     Toggles the visibility of a card.
    /// </summary>
    /// <param name="cardId">The ID of the card.</param>
    /// <param name="isVisible">The new visibility state.</param>
    public void UpdateCardVisibility(int cardId, bool isVisible)
    {
        var card = _cards.FirstOrDefault(c => c.Id == cardId);
        card?.UpdateVisibility(isVisible);
    }

    /// <summary>
    ///     Initializes default dashboard cards.
    /// </summary>
    private void InitializeDefaultCards()
    {
        _cards.Add(new DashboardCard(CardType.MonitoredEquipment, 0));
        _cards.Add(new DashboardCard(CardType.OpenAlerts, 1));
        _cards.Add(new DashboardCard(CardType.AverageTemperature, 2));
        _cards.Add(new DashboardCard(CardType.RecentReports, 3));
    }

    /// <summary>
    ///     Parses a temperature range value string.
    /// </summary>
    /// <param name="value">The range value (e.g., "24h", "7d").</param>
    /// <returns>The corresponding TemperatureRange.</returns>
    private static TemperatureRange ParseTemperatureRange(string value)
    {
        return value switch
        {
            "24h" => TemperatureRange.Last24Hours,
            "7d" => TemperatureRange.Last7Days,
            "30d" => TemperatureRange.Last30Days,
            _ => TemperatureRange.Last24Hours
        };
    }
}