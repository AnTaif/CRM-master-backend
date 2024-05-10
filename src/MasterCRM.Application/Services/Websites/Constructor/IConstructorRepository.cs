using MasterCRM.Domain.Entities.Websites;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Application.Services.Websites.Constructor;

public interface IConstructorRepository
{
    public DbSet<Website> websites { get; }
    
    
}