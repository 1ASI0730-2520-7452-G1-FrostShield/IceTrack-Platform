using System.Net.Mime;
using IceTrackPlatform.API.Monitoring.Domain.Model.Commands;
using IceTrackPlatform.API.Monitoring.Domain.Services;
using IceTrackPlatform.API.Monitoring.Interfaces.REST.Resources;
using IceTrackPlatform.API.Monitoring.Interfaces.REST.Transform;
using IceTrackPlatform.API.Monitoring.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
 
namespace IceTrackPlatform.API.Monitoring.Interfaces.REST;

/// <summary>
/// Alert REST API controller.
/// </summary>
/// <param name="alertCommandService"> The Alert Command Service </param>
/// <param name="alertQueryServices"> The Alert Query Service </param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Alert")]
public class AlertController(
    IAlertCommandService alertCommandService,
    IAlertQueryServices alertQueryServices)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Alert", 
                      Description = "Create a new Alert", 
                      OperationId = "CreateAlert")]
    [SwaggerResponse(201, "Created alert", typeof(AlertResource))]
    [SwaggerResponse(400, "The Alert was not created")]
    [SwaggerResponse(409, "The Alert already exists")]
    public async Task<IActionResult> CreateAlert(
        [FromBody] CreateAlertResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
        }

        var createAlertCommand = CreateAlertCommandFromResourceAssembler
            .ToCommandFromResource(resource);

        try
        {
            var result = await alertCommandService.Handle(createAlertCommand);
            if (result is null) return BadRequest();

            return CreatedAtAction(nameof(GetAlertById), 
                new { id = result.Id },
                AlertResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        catch (Exception e) when (e.Message.Contains("already exists"))
        {
            return Conflict("An alert with the same data already exists.");
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Gets all Alerts By Id",
                      Description = "Gets an Alert for a given identifier",
                      OperationId = "GetAlertsById")]
    [SwaggerResponse(200, "The Alert was found", typeof(AlertResource))]
    public async Task<IActionResult> GetAlertById(int id)
    {
        var query = new GetAlertByIdQuery(id);
        var result = await alertQueryServices.Handle(query);

        if (result is null) return NotFound();

        var resource = AlertResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all Alerts or by Tenant/Equipment",
        Description = "Gets all Alerts if no query parameter is specified. Can filter by tenantId or equipmentId.",
        OperationId = "GetAlerts")]
    [SwaggerResponse(200, "The alerts were found", typeof(IEnumerable<AlertResource>))]
    [SwaggerResponse(400, "Invalid query parameters")]
    public async Task<IActionResult> GetAlerts([FromQuery] int? tenantId = null, [FromQuery] int? equipmentId = null)
    {
        if (tenantId.HasValue)
        {
            var query = new GetAllAlertsByTenantIdQuery(tenantId.Value);
            var results = await alertQueryServices.Handle(query);
            var resources = results.Select(AlertResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(resources);
        }
        
        if (equipmentId.HasValue)
        {
            var query = new GetAllAlertsByEquipmentIdQuery(equipmentId.Value);
            var results = await alertQueryServices.Handle(query);
            var resources = results.Select(AlertResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(resources);
        }
        
        var getAllQuery = new GetAllAlertsQuery();
        var allAlerts = await alertQueryServices.Handle(getAllQuery);
        var allResources = allAlerts.Select(AlertResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(allResources);
    }
    
    [HttpPatch("{id}/acknowledge")]
    [SwaggerOperation(
        Summary = "Acknowledges an Alert",
        Description = "Marks an alert as acknowledged",
        OperationId = "AcknowledgeAlert")]
    [SwaggerResponse(200, "Alert acknowledged successfully", typeof(AlertResource))]
    [SwaggerResponse(404, "Alert not found")]
    [SwaggerResponse(500, "Internal server error")]
    public async Task<IActionResult> AcknowledgeAlert(int id)
    {
        try
        {
            var command = new AcknowledgeAlertCommand(id);
            var result = await alertCommandService.Handle(command);

            if (result is null)
                return NotFound($"Alert with id {id} was not found.");

            var resource = AlertResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Alert", Description = "Delete a Alert", OperationId = "DeleteAlert")]
    [SwaggerResponse(204, "Alert deleted")]
    [SwaggerResponse(404, "Alert not found")]
    public async Task<IActionResult> DeleteAlert(int id)
    {
        var deleteCommand = new DeleteAlertCommand(id);
        var result = await alertCommandService.Handle(deleteCommand);
        if (result is null) return NotFound();
        return NoContent();
    }
}
