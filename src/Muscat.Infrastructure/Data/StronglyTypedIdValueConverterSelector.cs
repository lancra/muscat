using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Muscat.Core.SharedKernel;

namespace Muscat.Infrastructure.Data;

/// <summary>
/// A registry of <see cref="StronglyTypedIdValueConverter{TStronglyTypedId}" /> instances that can be used to find the preferred
/// converter to use to convert to and from a given model type to a type that the database provider supports.
/// </summary>
/// <remarks>
/// See https://andrewlock.net/strongly-typed-ids-in-ef-core-using-strongly-typed-entity-ids-to-avoid-primitive-obsession-part-4 for
/// more information.
/// </remarks>
public class StronglyTypedIdValueConverterSelector : ValueConverterSelector
{
    private readonly ConcurrentDictionary<(Type ModelClrType, Type ProviderClrType), ValueConverterInfo> _converters = new();

    public StronglyTypedIdValueConverterSelector(ValueConverterSelectorDependencies dependencies)
        : base(dependencies)
    {
    }

    public override IEnumerable<ValueConverterInfo> Select(Type modelClrType, Type? providerClrType = null)
    {
        var baseConverters = base.Select(modelClrType, providerClrType);
        foreach (var converter in baseConverters)
        {
            yield return converter;
        }

        var underlyingModelType = UnwrapNullableType(modelClrType);
        var underlyingProviderType = providerClrType is not null ? UnwrapNullableType(providerClrType) : null;
        if (underlyingProviderType is null || underlyingProviderType == typeof(Guid))
        {
            var isStronglyTypedId = typeof(StronglyTypedId).IsAssignableFrom(underlyingModelType);
            if (isStronglyTypedId)
            {
                var converterType = typeof(StronglyTypedIdValueConverter<>).MakeGenericType(underlyingModelType);
                yield return _converters.GetOrAdd(
                    (underlyingModelType, typeof(Guid)),
                    _ => new ValueConverterInfo(
                        modelClrType,
                        typeof(Guid),
                        valueConverterInfo => (ValueConverter)Activator
                        .CreateInstance(converterType, valueConverterInfo.MappingHints)!));
            }
        }
    }

    private static Type UnwrapNullableType(Type type) => Nullable.GetUnderlyingType(type) ?? type;
}
