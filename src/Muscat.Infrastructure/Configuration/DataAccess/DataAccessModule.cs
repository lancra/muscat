using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Muscat.Infrastructure.Configuration.DataAccess;

internal class DataAccessModule : Module
{
    private readonly Uri _databaseConnectionUri;

    public DataAccessModule(Uri databaseConnectionUri)
    {
        _databaseConnectionUri = databaseConnectionUri;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder
            .Register(context => new MuscatDbContext(
                new DbContextOptionsBuilder<MuscatDbContext>()
                    .UseSqlite(
                        $"Data Source={_databaseConnectionUri}",
                        sqliteOptions => sqliteOptions.MigrationsAssembly("Muscat.Infrastructure.Migrations"))
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                    .Options))
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}
