namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

public record AssignedTo(int Value)
{
    public AssignedTo() : this(0)
    {
    }
}