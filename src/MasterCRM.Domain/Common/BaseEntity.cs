using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Domain.Common;

public class BaseEntity<T> : IEntity<T>
{
    public T Id { get; init; }
}