using API.Person.Domain;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace API.Person.Infrastructure.Database.Mappings;

public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(a => a.Type)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(20);

        builder.Property(a => a.Street)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(a => a.ZipCode)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(10);

        builder.HasOne(a => a.Person)
            .WithMany(p => p.Addresses)
            .HasForeignKey(a => a.PersonId);
    }
}

