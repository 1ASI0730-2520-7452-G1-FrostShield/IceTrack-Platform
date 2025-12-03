using IceTrackPlatform.API.Reporting.Domain.Model.Aggregates;
using IceTrackPlatform.API.Reporting.Domain.Model.Commands;
using IceTrackPlatform.API.Reporting.Domain.Repositories;
using IceTrackPlatform.API.Reporting.Domain.Services;
using IceTrackPlatform.API.Shared.Domain.Repositories;

namespace IceTrackPlatform.API.Reporting.Application.Internal.CommandServices;

/// <summary>
/// This class handles commands related to Report entities.
/// </summary>
/// <param name="reportRepository"> The instance of ReportRepository </param>
/// <param name="unitOfWork"> The instance of UnitOfwork </param>
public class ReportCommandService(IReportRepository reportRepository,
                                  IUnitOfWork unitOfWork) 
    : IReportCommandService
{
    public async Task<Report?> Handle(CreateReportCommand command)
    {
        var existingReports = await reportRepository.FindByEquipmentIdAsync(command.EquipmentId);
        if (existingReports.Any(r => r.Type == command.Type && r.Title == command.Title))
            throw new Exception("A report with the same type and title already exists for this equipment.");

        var report = new Report(command);

        await reportRepository.AddAsync(report);
        await unitOfWork.CompleteAsync();

        return report;
    }
    
    public async Task<Report?> Handle(UpdateReportCommand command)
    {
        var report = await reportRepository.FindByIdAsync(command.Id);

        if (report == null)
            throw new Exception("Report not found.");
        
        report.UpdateReport(command.TenantId, command.EquipmentId, command.Title, command.Status,
            command.Summary, command.Content, command.Url);

        reportRepository.Update(report);
        await unitOfWork.CompleteAsync();

        return report;
    }
    
    public async Task<Report?> Handle(DeleteReportCommand command)
    {
        var report = await reportRepository.FindByIdAsync(command.Id);

        if (report == null)
            throw new Exception("Report not found.");

        reportRepository.Remove(report);
        await unitOfWork.CompleteAsync();

        return report;
    }
}