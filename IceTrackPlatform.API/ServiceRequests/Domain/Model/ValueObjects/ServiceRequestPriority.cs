namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

public enum EServiceRequestPriority
{
    High,
    Medium,
    Low
}

public record ServiceRequestPriority(EServiceRequestPriority Priority)
{
    public ServiceRequestPriority() : this(EServiceRequestPriority.Medium)
    {
    }
}
