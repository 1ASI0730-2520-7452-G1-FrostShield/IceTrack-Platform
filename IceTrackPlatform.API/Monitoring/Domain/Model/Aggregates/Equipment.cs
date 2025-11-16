using IceTrackPlatform.API.Monitoring.Domain.Model.Commands;

namespace IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;

public partial class Equipment
{
    public int Id { get; }

    public string Model { get; private set; }
    public string Type { get; private set; }
    public string Serial { get; private set; }
    public string Status { get; private set; }
    
    protected Equipment()
    {
        Model = string.Empty;
        Type = string.Empty;
        Serial = string.Empty;
        Status = string.Empty;
    }

    /// <summary>
    ///  Constructor for Equipment aggregate
    /// </summary>
    public Equipment(CreateEquipmentCommand command)
    {
        Model = command.Model;
        Type = command.Type;
        Serial = command.Serial;
        Status = command.Status;
    }
}
