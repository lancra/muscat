using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muscat.Core.Links;
using Muscat.Infrastructure.Configuration.DataAccess;

namespace Muscat.Infrastructure.Domain.Links;

public class LinkEntityTypeConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("Links");
        builder.HasKey(link => link.Id);
        builder.HasAlternateKey("_name");

        builder.Property(link => link.Id)
            .HasColumnOrder(0);

        builder.Property<Uri>("_domain")
            .HasColumnName("Domain")
            .HasColumnOrder(1)
            .IsCaseInsensitive();

        builder.Property<string>("_name")
            .HasColumnName("Name")
            .HasColumnOrder(2)
            .IsCaseInsensitive();

        builder.Property<DateTime>("_createdDate")
            .HasColumnName("CreatedDate")
            .HasColumnOrder(3);

        builder.Property<DateTime>("_modifiedDate")
            .HasColumnName("ModifiedDate")
            .HasColumnOrder(4);
    }
}
