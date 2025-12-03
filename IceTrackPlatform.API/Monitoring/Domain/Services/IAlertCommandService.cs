using IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;
using IceTrackPlatform.API.Monitoring.Domain.Model.Commands;

namespace IceTrackPlatform.API.Monitoring.Domain.Services;

public interface IAlertCommandService
{
    /// <summary>
    /// Handle the create alert command
    /// </summary>
    /// <remarks>
    /// This method processes the CreateAlertCommand to create a new Alert entity.
    /// It performs necessary validations and persists the entity to the data store.
    /// If it does not exist, it creates a new Alert and returns it; otherwise, it returns null.
    /// </remarks>
    /// <param name="command"> The create alert command </param>
    /// <returns>
    /// A newly created Alert if successful; otherwise, null.
    /// </returns>
    Task<Alert?> Handle(CreateAlertCommand command);
    /// <summary>
    /// Handle the acknowledge alert command
    /// </summary>
    /// <param name="command">The acknowledge alert command</param>
    /// <returns>The acknowledged alert if found; otherwise, null.</returns>
    Task<Alert?> Handle(AcknowledgeAlertCommand command);
    
    Task<Alert?> Handle(DeleteAlertCommand command);
}