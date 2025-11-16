namespace IceTrackPlatform.API.Assets_Management.Domain.Model.Commands;

/// <summary>
///     Command to create a Site Aggregate
/// </summary>
/// <param name="Name"></param>
/// <param name="Address"></param>
public record CreateSiteCommand(string Name, string Address);