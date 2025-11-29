using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace IceTrackPlatform.API.Assets_Management.Domain.Model.Aggregates;

public partial class SiteAudit : IEntityWithCreatedUpdatedDate
{
    [Column("Name")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("Address")] public DateTimeOffset? UpdatedDate { get; set; }
}