using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Muscat.Core.SharedKernel;

namespace Muscat.Infrastructure.Configuration.DataAccess;

public class StronglyTypedIdValueConverter<TStronglyTypedId> : ValueConverter<TStronglyTypedId, Guid>
    where TStronglyTypedId : StronglyTypedId
{
    public StronglyTypedIdValueConverter(ConverterMappingHints? mappingHints = null)
        : base(id => id.Value, value => Create(value), mappingHints)
    {
    }

    private static TStronglyTypedId Create(Guid id)
        => Activator.CreateInstance(typeof(TStronglyTypedId), id) as TStronglyTypedId
        ?? throw new InvalidOperationException($"Unable to create an instance of the {typeof(TStronglyTypedId)} class.");
}
