using Autofac;
using Autofac.Core;
using Autofac.Features.Variance;
using FluentValidation;
using MediatR;
using Muscat.Application;

namespace Muscat.Infrastructure.Configuration.Mediator;

internal class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).Assembly)
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        var mediatorOpenTypes = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(IRequestHandler<>),
            typeof(IValidator<>),
        };

        builder.RegisterSource(new ScopedContravariantRegistrationSource(mediatorOpenTypes));

        foreach (var type in mediatorOpenTypes)
        {
            builder.RegisterAssemblyTypes(ThisAssembly, typeof(ICommand<>).Assembly)
                .AsClosedTypesOf(type)
                .AsImplementedInterfaces()
                .FindConstructorsWith(new AllConstructorsFinder());
        }

        builder.Register<ServiceFactory>(
            context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return type => componentContext.Resolve(type);
            });
    }

    private class ScopedContravariantRegistrationSource : IRegistrationSource
    {
        private readonly IRegistrationSource _source = new ContravariantRegistrationSource();
        private readonly IReadOnlyCollection<Type> _types;

        public ScopedContravariantRegistrationSource(params Type[] types)
        {
            ArgumentNullException.ThrowIfNull(types);

            if (!types.All(t => t.IsGenericTypeDefinition))
            {
                throw new ArgumentException("Provided types should be generic type definitions", nameof(types));
            }

            _types = types;
        }

        public bool IsAdapterForIndividualComponents => _source.IsAdapterForIndividualComponents;

        public IEnumerable<IComponentRegistration> RegistrationsFor(
            Service service,
            Func<Service, IEnumerable<ServiceRegistration>> registrationAccessor)
        {
            var registrations = _source.RegistrationsFor(service, registrationAccessor);
            foreach (var registration in registrations)
            {
                if (registration.Target.Services.OfType<TypedService>()
                    .Select(typedService => typedService.ServiceType.GetGenericTypeDefinition())
                    .Any(_types.Contains))
                {
                    yield return registration;
                }
            }
        }
    }
}
