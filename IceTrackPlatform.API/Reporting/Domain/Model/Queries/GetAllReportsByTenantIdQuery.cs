namespace IceTrackPlatform.API.Reporting.Domain.Model.Queries;

/// <summary>
/// Query to get a Report aggregate by the ID of a Tenant
/// </summary>
/// <param name="TenantId"> The Tenant ID to search </param>
public record GetAllReportsByTenantIdQuery(int TenantId);