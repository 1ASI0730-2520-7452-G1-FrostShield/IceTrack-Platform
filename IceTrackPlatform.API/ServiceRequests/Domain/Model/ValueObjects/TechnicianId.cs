namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

public record TechnicianId(int Value)
{
    public TechnicianId() : this(0)
    {
    }
}