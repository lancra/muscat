using Microsoft.EntityFrameworkCore;

namespace Muscat.Core.Data;

public class MuscatDbContext : DbContext
{
    public MuscatDbContext(DbContextOptions<MuscatDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
