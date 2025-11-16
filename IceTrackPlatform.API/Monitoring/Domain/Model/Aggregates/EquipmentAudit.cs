using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace IceTrackPlatform.API.Monitoring.Domain.Model.Aggregates;

public partial class Equipment : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] 
    public DateTimeOffset? CreatedDate { get; set; }

    [Column("UpdatedAt")] 
    public DateTimeOffset? UpdatedDate { get; set; }
}