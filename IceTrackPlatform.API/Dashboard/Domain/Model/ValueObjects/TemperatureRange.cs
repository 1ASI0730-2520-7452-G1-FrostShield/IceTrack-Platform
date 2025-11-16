namespace IceTrackPlatform.API.Dashboard.Domain.Model.ValueObjects;

/// <summary>
///     Represents the temperature monitoring time range.
/// </summary>
/// <param name="Value">
///     The range value (e.g., "24h", "7d", "30d").
/// </param>
/// <param name="Label">
///     The human-readable label for the range.
/// </param>
public record TemperatureRange(string Value, string Label)
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="TemperatureRange" /> record with default value.
    /// </summary>
    public TemperatureRange() : this("24h", "Last 24 Hours")
    {
    }

    /// <summary>
    ///     Predefined range: Last 24 hours.
    /// </summary>
    public static TemperatureRange Last24Hours => new("24h", "Last 24 Hours");

    /// <summary>
    ///     Predefined range: Last 7 days.
    /// </summary>
    public static TemperatureRange Last7Days => new("7d", "Last 7 Days");

    /// <summary>
    ///     Predefined range: Last 30 days.
    /// </summary>
    public static TemperatureRange Last30Days => new("30d", "Last 30 Days");
}