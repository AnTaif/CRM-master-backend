using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class Stage : BaseEntity<Guid>
{
    public required string MasterId { get; init; }

    public required string Name { get; init; }

    public bool IsSystemStage { get; init; } = false;
}