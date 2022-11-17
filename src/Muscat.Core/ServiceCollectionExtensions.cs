using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Muscat.Core.Data;

namespace Muscat.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMuscatCore(this IServiceCollection services)
        => services;

    public static IServiceCollection AddMuscatData(this IServiceCollection services, Uri databasePath)
        => services
        .AddDbContext<MuscatDbContext>(dbContextOptions => dbContextOptions.UseSqlite(
            $"Data Source={databasePath}",
            sqliteOptions => sqliteOptions.MigrationsAssembly("Muscat.Core.Migrations")));
}
