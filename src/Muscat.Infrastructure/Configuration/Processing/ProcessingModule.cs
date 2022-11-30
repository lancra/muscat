using Autofac;
using Muscat.Application;

namespace Muscat.Infrastructure.Configuration.Processing;

internal class ProcessingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DomainEventsDispatcher>()
            .As<IDomainEventsDispatcher>()
            .InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterGenericDecorator(typeof(UnitOfWorkCommandHandlerDecorator<,>), typeof(ICommandHandler<,>));
        builder.RegisterGenericDecorator(typeof(ValidationCommandHandlerDecorator<,>), typeof(ICommandHandler<,>));
    }
}
