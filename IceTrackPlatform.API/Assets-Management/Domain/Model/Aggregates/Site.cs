using IceTrackPlatform.API.Assets_Management.Domain.Model.Commands;

namespace IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;

public partial class Site
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Address { get; private set; }

    protected Site()
    {
        Name = string.Empty;
        Address = string.Empty;
    }

    /// <summary>
    ///   Constructor for Site aggregate
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Address"></param>
    public Site(CreateSiteCommand command)
    {
        Name = command.Name;
        Address = command.Address;
    }
}