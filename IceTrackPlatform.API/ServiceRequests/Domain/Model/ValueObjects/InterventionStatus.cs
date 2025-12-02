namespace IceTrackPlatform.API.ServiceRequests.Domain.Model.ValueObjects;

public enum EInterventionStatus
{
    Pending,
    Completed
}

public record InterventionStatus(EInterventionStatus Status)
{
    public InterventionStatus() : this(EInterventionStatus.Pending)
    {
    }
}