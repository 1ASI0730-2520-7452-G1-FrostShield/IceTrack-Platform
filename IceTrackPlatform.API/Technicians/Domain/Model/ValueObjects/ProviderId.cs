namespace IceTrackPlatform.API.Technicians.Domain.Model.ValueObjects;

public record ProviderId(int Id)
{
    public ProviderId() : this(0)
    {
    }
}
