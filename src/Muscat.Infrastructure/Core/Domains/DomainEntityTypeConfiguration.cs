using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muscat.Core.Domains;
using Muscat.Infrastructure.Configuration.DataAccess;

namespace Muscat.Infrastructure.Core.Domains;

public class DomainEntityTypeConfiguration : IEntityTypeConfiguration<Domain>
{
    public void Configure(EntityTypeBuilder<Domain> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("Domains");
        builder.HasKey(domain => domain.Id);
        builder.HasAlternateKey("_name");

        builder.Property(domain => domain.Id)
            .HasColumnOrder(0);

        builder.Property<Uri>("_uri")
            .HasColumnName("Uri")
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
