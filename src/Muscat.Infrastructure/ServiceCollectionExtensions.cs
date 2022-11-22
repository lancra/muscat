using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Muscat.Infrastructure.Data;

namespace Muscat.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMuscatInfrastructure(this IServiceCollection services, Uri databasePath)
        => services
        .AddDbContext<MuscatDbContext>(dbContextOptions => dbContextOptions
            .UseSqlite(
                $"Data Source={databasePath}",
                sqliteOptions => sqliteOptions.MigrationsAssembly("Muscat.Infrastructure.Migrations"))
            .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>());
}
