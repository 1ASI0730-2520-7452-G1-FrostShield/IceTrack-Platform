namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

public enum EServiceRequestStatus
{
    Pending,
    Accepted,
    InProgress,
    Completed,
    Canceled,
    Rejected
}

public record ServiceRequestStatus(EServiceRequestStatus Status)
{
    public ServiceRequestStatus() : this(EServiceRequestStatus.Pending)
    {
    }
}