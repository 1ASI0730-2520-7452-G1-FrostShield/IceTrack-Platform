using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace IceTrackPlatform.API.Dashboard.Domain.Model.Aggregates;

public partial class DashboardConfig : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }

    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}