namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

public record RequesterId(int Value)
{
    public RequesterId() : this(0)
    {
    }
}
