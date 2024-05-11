using MasterCRM.Application.Services.Websites.PublicWebsite;
using MasterCRM.Domain.Entities.Websites;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories;

public class StyleRepository(CrmDbContext context) : IStyleRepository
{
    private DbSet<Style> dbSet => context.Styles;

    public async Task AddAsync(Style style) => await dbSet.AddAsync(style);

    public async Task AddRangeAsync(IEnumerable<Style> styles) => await dbSet.AddRangeAsync(styles);
}