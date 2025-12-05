namespace IceTrackPlatform.API.Monitoring.Domain.Model.Queries;

/// <summary>
/// Query to get all Alert aggregates by the ID of a Tenant
/// </summary>
/// <param name="TenantId"> The Tenant ID to search </param>
public record GetAllAlertsByTenantIdQuery(int TenantId);