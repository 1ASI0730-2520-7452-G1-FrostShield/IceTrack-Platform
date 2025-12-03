namespace IceTrackPlatform.API.Technicians.Domain.Model.ValueObjects;

public record ProviderId(int Value)
{
    public ProviderId() : this(0)
    {
    }
}

