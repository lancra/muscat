using Microsoft.EntityFrameworkCore;
using Muscat.Core.Domains;

namespace Muscat.Infrastructure;

public class MuscatDbContext : DbContext
{
    public MuscatDbContext(DbContextOptions<MuscatDbContext> options)
        : base(options)
    {
    }

    public DbSet<Domain> Domains { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
