namespace IceTrackPlatform.API.Dashboard.Domain.Model.Commands;

/// <summary>
///     Command to reorder dashboard cards.
/// </summary>
/// <param name="DashboardConfigId">
///     The ID of the dashboard configuration.
/// </param>
/// <param name="CardOrders">
///     Dictionary mapping card IDs to their new order values.
/// </param>
public record ReorderCardsCommand(
    int DashboardConfigId,
    Dictionary<int, int> CardOrders);