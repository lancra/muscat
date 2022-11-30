using Autofac;
using Muscat.Infrastructure.Configuration.DataAccess;
using Muscat.Infrastructure.Configuration.Mediator;
using Muscat.Infrastructure.Configuration.Processing;

namespace Muscat.Infrastructure;

public class MuscatModule : Module
{
    private readonly Uri _databaseConnectionUri;

    public MuscatModule(Uri databaseConnectionUri)
    {
        _databaseConnectionUri = databaseConnectionUri;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new DataAccessModule(_databaseConnectionUri));
        builder.RegisterModule(new MediatorModule());
        builder.RegisterModule(new ProcessingModule());
    }
}
