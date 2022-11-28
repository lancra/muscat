using Autofac;
using Muscat.Infrastructure.Configuration.DataAccess;

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
    }
}
