namespace IceTrackPlatform.API.Dashboard.Domain.Model.ValueObjects;

/// <summary>
///     Represents the type of dashboard card.
/// </summary>
public enum CardType
{
    MonitoredEquipment,
    OpenAlerts,
    ActiveOrders,
    AverageTemperature,
    TemperatureTrends,
    EquipmentStatus,
    RecentReports,
    SystemHealth
}