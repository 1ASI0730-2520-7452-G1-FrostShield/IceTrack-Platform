namespace IceTrackPlatform.API.Monitoring.Domain.Model.Queries;

/// <summary>
///     Query to get a Equipment aggregate by Manufacturer and Online
/// </summary>
/// <param name="Manufacturer">The Manufacturer to search</param>
/// <param name="Online">The Online to search</param>
public record GetEquipmentByManufacturerAndOnlineQuery(string Manufacturer, bool Online);