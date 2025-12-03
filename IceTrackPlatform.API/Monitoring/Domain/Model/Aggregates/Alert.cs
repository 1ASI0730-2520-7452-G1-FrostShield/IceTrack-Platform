using IceTrackPlatform.API.Monitoring.Domain.Model.Commands;
using IceTrackPlatform.API.Monitoring.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
public partial class Alert
{
    public int Id { get; }

    public int TenantId { get; private set; }

    public int EquipmentId { get; private set; }

    public int SiteId { get; private set; }

    public string Type { get; private set; }

    public EAlertSeverity Severity { get; private set; }
    
    public string Description { get; private set; }
    
    public EAlertStatus Status { get; private set; }
    
    public Alert(
        int tenantId,
        int equipmentId,
        int siteId,
        string type,
        EAlertSeverity severity,
        string description,
        EAlertStatus status)
    {
        TenantId = tenantId;
        EquipmentId = equipmentId;
        SiteId = siteId;
        Type = type;
        Severity = severity;
        Description = description;
        Status = status;
    }
    
    public Alert(CreateAlertCommand command)
    {
        TenantId = command.TenantId;
        EquipmentId = command.EquipmentId;
        SiteId = command.SiteId;
        Type = command.Type;
        Severity = command.Severity;
        Description = command.Description;
        Status = EAlertStatus.Active;
    }
    

    public void Acknowledge()
    {
        Status = EAlertStatus.Acknowledged;
    }

    public void Resolve()
    {
        Status = EAlertStatus.Resolved;
    }

    public void Close()
    {
        Status = EAlertStatus.Closed;
    }
}
