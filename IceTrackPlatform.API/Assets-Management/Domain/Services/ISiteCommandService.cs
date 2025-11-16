using IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;
using IceTrackPlatform.API.Assets_Management.Domain.Model.Commands;

namespace IceTrackPlatform.API.Assets_Management.Domain.Services;

public interface ISiteCommandService
{
    /// <summary>
    ///  Handle the create Site command
    /// </summary>
    Task<Site> Handle(CreateSiteCommand command);
}