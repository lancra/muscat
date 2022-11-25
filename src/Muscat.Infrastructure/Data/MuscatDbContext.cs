using Microsoft.EntityFrameworkCore;
using Muscat.Core.Links;

namespace Muscat.Infrastructure.Data;

public class MuscatDbContext : DbContext
{
    public MuscatDbContext(DbContextOptions<MuscatDbContext> options)
        : base(options)
    {
    }

    public DbSet<Link> Links { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
