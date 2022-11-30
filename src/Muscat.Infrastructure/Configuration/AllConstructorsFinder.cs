using System.Collections.Concurrent;
using System.Reflection;
using Autofac.Core.Activators.Reflection;

namespace Muscat.Infrastructure.Configuration;

internal class AllConstructorsFinder : IConstructorFinder
{
    private static readonly ConcurrentDictionary<Type, ConstructorInfo[]> _cache = new();

    public ConstructorInfo[] FindConstructors(Type targetType)
    {
        var constructors = _cache.GetOrAdd(
            targetType,
            type => type.GetTypeInfo()
                .DeclaredConstructors
                .ToArray());

        return constructors.Length > 0 ? constructors : throw new NoConstructorsFoundException(targetType);
    }
}
