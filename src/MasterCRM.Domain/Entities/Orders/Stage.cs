using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Orders;

public class Stage : BaseEntity<Guid>
{
    public required string MasterId { get; init; }

    public required string Name { get; set; }

    public StageType StageType { get; init; }
    
    public short Order { get; set; }

    public bool IsSystem => StageType != StageType.Default;

    public void Update(string? name, short? order)
    {
        if (name != null)
            Name = name;
        if (order != null)
            Order = (short)order;
    }
}

public enum StageType
{
    Default = 0,
    Start = 1,
    End = 2
}