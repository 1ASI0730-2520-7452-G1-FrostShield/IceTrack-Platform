using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Monitoring.Domain.Repositories;

public interface IEquipmentRepository : IBaseRepository<Equipment>
{
    /// <summary>
    ///     Find equipment by Model
    /// </summary>
    Task<IEnumerable<Equipment>> FindByModelAsync(string model);

    /// <summary>
    ///     Find equipment by Model and Serial
    /// </summary>
    Task<Equipment?> FindByModelAndSerialAsync(string model, string serial);
}
