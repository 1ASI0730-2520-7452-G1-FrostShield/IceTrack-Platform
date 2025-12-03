using IceTrackPlatform.API.Reporting.Domain.Model.Aggregates;
using IceTrackPlatform.API.Reporting.Domain.Model.Queries;
using IceTrackPlatform.API.Reporting.Domain.Repositories;
using IceTrackPlatform.API.Reporting.Domain.Services;

namespace IceTrackPlatform.API.Reporting.Application.Internal.QueryServices;

/// <summary>
/// Report Query Service
/// </summary>
/// <remarks>
/// This class handles queries related to reports.
/// It interacts with the IReportRepository to retrieve data.
/// </remarks>
/// <param name="reportRepository"></param>
public class ReportQueryService(IReportRepository reportRepository)
: IReportQueryServices
{
    public async Task<IEnumerable<Report>> Handle(GetAllReportsByTenantIdQuery query)
    {
        return await reportRepository.FindByTenantIdAsync(query.TenantId);
    }
    
    public async Task<IEnumerable<Report>> Handle(GetAllReportsByEquipmentIdQuery query)
    {
        return await reportRepository.FindByEquipmentIdAsync(query.EquipmentId);
    }

    public async Task<Report?> Handle(GetReportByIdQuery query)
    {
        return await reportRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<IEnumerable<Report>> Handle(GetAllReportsQuery query)
    {
        return await reportRepository.ListAsync();
    }
}