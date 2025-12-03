using IceTrackPlatform.API.Reporting.Domain.Model.Aggregates;
using IceTrackPlatform.API.Reporting.Domain.Model.Commands;

namespace IceTrackPlatform.API.Reporting.Domain.Services;

public interface IReportCommandService
{
    /// <summary>
    /// Handle the create report command
    /// </summary>
    /// <remarks>
    /// This method processes the CreateReportCommand to create a new Report entity.
    /// It performs necessary validations and persists the entity to the data store.
    /// If it does not exist, it creates a new Report and returns it; otherwise, it returns null.
    /// </remarks>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<Report?> Handle(CreateReportCommand command);
    
    /// <summary>
    /// Handle the update report command
    /// </summary>
    /// <remarks>
    /// This method processes the UpdateReportCommand to update an existing Report entity.
    /// </remarks>
    Task<Report?> Handle(UpdateReportCommand command);
    
    /// <summary>
    /// Handle the delete report command
    /// </summary>
    /// <remarks>
    /// This method processes the DeleteReportCommand to delete an existing Report entity.
    /// </remarks>
    Task<Report?> Handle(DeleteReportCommand command);
}