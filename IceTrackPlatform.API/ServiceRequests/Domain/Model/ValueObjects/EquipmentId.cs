namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

public record EquipmentId(int Value)
{
    public EquipmentId() : this(0)
    {
    }
}
