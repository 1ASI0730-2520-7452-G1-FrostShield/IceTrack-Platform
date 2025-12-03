namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

public enum EServiceRequestType
{
    Corrective,
    Preventive
}

public record ServiceRequestType(EServiceRequestType Type)
{
    public ServiceRequestType() : this(EServiceRequestType.Corrective)
    {
    }
}