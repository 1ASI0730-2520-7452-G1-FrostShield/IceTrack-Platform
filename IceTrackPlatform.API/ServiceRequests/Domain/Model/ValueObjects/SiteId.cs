namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

public record SiteId(int Value)
{
    public SiteId() : this(0)
    {
    }
}
