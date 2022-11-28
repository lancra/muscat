using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Muscat.Infrastructure.Configuration.DataAccess;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<T> IsCaseInsensitive<T>(this PropertyBuilder<T> builder)
        => builder.UseCollation("NOCASE");
}
