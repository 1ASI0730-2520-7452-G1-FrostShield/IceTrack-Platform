namespace IceTrackPlatform.API.Assets_Management.Domain.Model.Queries;

/// <summary>
///     Query to get all Site aggregates by ContactName
/// </summary>
/// <param name="ContactName">The ContactName to search</param>
public record GetAllSitesByContactNameQuery(string ContactName);