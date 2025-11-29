namespace IceTrackPlatform.API.Assets_Management.Domain.Model.Queries;

/// <summary>
///     Query to get a Site aggregate by Name and Address
/// </summary>
public record GetSiteByNameAndAddressQuery(string Name, string Address);