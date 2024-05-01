using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class Stage : BaseEntity<Guid>
{
    public required string MasterId { get; init; }

    public required string Name { get; init; }

    public StageType StageType { get; init; }
}

public enum StageType
{
    Default = 0,
    Start = 1,
    End = 2
}