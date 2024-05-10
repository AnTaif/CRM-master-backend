using System.ComponentModel.DataAnnotations;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Domain.Common;

public class BaseEntity<T> : IEntity<T>
{
    [Key]
    public T Id { get; init; }
}