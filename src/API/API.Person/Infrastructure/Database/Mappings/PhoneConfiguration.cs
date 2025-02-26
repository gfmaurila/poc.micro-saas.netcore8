using API.Person.Domain;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace API.Person.Infrastructure.Database.Mappings;



public class PhoneConfiguration : IEntityTypeConfiguration<PhoneEntity>
{
    public void Configure(EntityTypeBuilder<PhoneEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(p => p.Type)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(15);

        builder.Property(p => p.Number)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(20);

        builder.HasOne(p => p.Person)
            .WithMany(p => p.Phones)
            .HasForeignKey(p => p.PersonId);
    }
}
