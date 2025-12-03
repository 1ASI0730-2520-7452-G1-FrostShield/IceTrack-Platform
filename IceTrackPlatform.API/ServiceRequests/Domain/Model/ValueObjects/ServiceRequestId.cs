namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

public record ServiceRequestId(int Value)
{
    public ServiceRequestId() : this(0)
    {
    }
}
