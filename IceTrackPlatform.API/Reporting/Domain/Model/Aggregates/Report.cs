using IceTrackPlatform.API.Reporting.Domain.Model.Commands;
using IceTrackPlatform.API.Reporting.Domain.Model.ValueObjects;

namespace IceTrackPlatform.API.Reporting.Domain.Model.Aggregates;

public partial class Report
{
    public int Id { get; }
    
    public int TenantId { get; private set; }
    
    public EReportType Type { get; private set; }
    
    public int EquipmentId { get; private set; }
    
    public string Title { get; private set; }
    
    public EReportStatus Status { get; private set; }
    
    public string Summary { get; private set; }
    
    public string Content { get; private set; }
    
    public string Url { get; private set; }
    
    public Report(int tenantId, EReportType type, int equipmentId, string title,
        EReportStatus status,  string summary, string content, string url)
    {
        TenantId = tenantId;
        Type = type;
        EquipmentId = equipmentId;
        Title = title;
        Status = status;
        Summary = summary;
        Content = content;
        Url = url;
    }
    
    /// <summary>
    /// Creates a new Report from a CreateReportCommand
    /// </summary>
    /// <param name="command"> The CreateReportCommand </param>
    public Report(CreateReportCommand command)
    {
        TenantId = command.TenantId;
        Type = command.Type;
        EquipmentId = command.EquipmentId;
        Title = command.Title;
        Status = EReportStatus.InProgress;
        Summary = command.Summary;
        Content = command.Content;
        Url = command.Url;
    }
    
    /// <summary>
    /// Updates the information of a Report
    /// </summary>
    public void UpdateReport(int tenantId, int equipmentId, string title, EReportStatus status,
        string summary, string content, string url)
    {
        TenantId = tenantId;
        EquipmentId = equipmentId;
        Title = title;
        Status = status;
        Summary = summary;
        Content = content;
        Url = url;
    }
}