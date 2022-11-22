using Microsoft.EntityFrameworkCore;
using Muscat.Core.Artists;

namespace Muscat.Infrastructure.Data;

public class MuscatDbContext : DbContext
{
    public MuscatDbContext(DbContextOptions<MuscatDbContext> options)
        : base(options)
    {
    }

    public DbSet<Artist> Artists { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
