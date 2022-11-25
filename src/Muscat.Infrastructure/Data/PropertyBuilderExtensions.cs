using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Muscat.Infrastructure.Data;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<T> IsCaseInsensitive<T>(this PropertyBuilder<T> builder)
        => builder.UseCollation("NOCASE");
}
