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
    [SwaggerOperation(Summary = "Gets all Alerts by TenantId and EquipmentId",
        Description = "Gets all Alerts by TenantId and EquipmentId",
        OperationId = "GetAllAlertsByTenantIdAndEquipmentId")]
    [SwaggerResponse(200, "The Alert was found", typeof(AlertResource))]
    public async Task<IActionResult> GetAlertsFromQuery(
        [FromQuery] int? tenantId = null,
        [FromQuery] int? equipmentId = null)
    {
        if (tenantId.HasValue)
            return await GetAllAlertsByTenantIdQuery(tenantId.Value);

        if (equipmentId.HasValue)
            return await GetAllAlertsByEquipmentIdQuery(equipmentId.Value);

        return BadRequest("Please specify either tenantId or equipmentId as query parameter.");
    }

    private async Task<IActionResult> GetAllAlertsByTenantIdQuery(int tenantId)
    {
        var query = new GetAllAlertsByTenantIdQuery(tenantId);
        var results = await alertQueryServices.Handle(query);

        var resources = results
            .Select(AlertResourceFromEntityAssembler.ToResourceFromEntity)
            .ToList();

        return Ok(resources);
    }

    private async Task<IActionResult> GetAllAlertsByEquipmentIdQuery(int equipmentId)
    {
        var query = new GetAllAlertsByEquipmentIdQuery(equipmentId);
        var results = await alertQueryServices.Handle(query);

        var resources = results
            .Select(AlertResourceFromEntityAssembler.ToResourceFromEntity)
            .ToList();

        return Ok(resources);
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
}
