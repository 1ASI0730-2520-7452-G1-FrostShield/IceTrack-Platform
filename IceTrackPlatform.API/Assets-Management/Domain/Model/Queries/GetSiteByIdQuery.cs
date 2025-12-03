namespace IceTrackPlatform.API.Assets_Management.Domain.Model.Queries;

/// <summary>
///     Query to get a Site aggregate by Id
/// </summary>
/// <param name="Id">The Source Id to search</param>
public record GetSiteByIdQuery(int Id);