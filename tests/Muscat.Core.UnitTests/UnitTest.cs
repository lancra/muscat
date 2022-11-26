using System.Collections;
using System.Reflection;
using Muscat.Core.SharedKernel;

namespace Muscat.Core.UnitTests;

public abstract class UnitTest
{
    public TDomainEvent AssertDomainEventPublished<TDomainEvent>(Entity aggregate)
        where TDomainEvent : IDomainEvent
    {
        var domainEvent = GetAllDomainEvents(aggregate)
            .OfType<TDomainEvent>()
            .SingleOrDefault();

        Assert.NotNull(domainEvent);
        return domainEvent;
    }

    private IReadOnlyCollection<IDomainEvent> GetAllDomainEvents(Entity aggregate)
    {
        var domainEvents = new List<IDomainEvent>();

        if (aggregate.DomainEvents is not null)
        {
            domainEvents.AddRange(aggregate.DomainEvents);
        }

        var aggregateFields = aggregate.GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .ToArray();
        foreach (var field in aggregateFields)
        {
            var isEntity = typeof(Entity).IsAssignableFrom(field.FieldType);
            if (isEntity)
            {
                var entity = (Entity)field.GetValue(aggregate)!;
                domainEvents.AddRange(
                    GetAllDomainEvents(entity));
            }

            if (field.FieldType != typeof(string) &&
                typeof(IEnumerable).IsAssignableFrom(field.FieldType) &&
                field.GetValue(aggregate) is IEnumerable enumerableField)
            {
                foreach (var item in enumerableField)
                {
                    if (item is Entity entityItem)
                    {
                        domainEvents.AddRange(
                            GetAllDomainEvents(entityItem));
                    }
                }
            }
        }

        return domainEvents;
    }
}
