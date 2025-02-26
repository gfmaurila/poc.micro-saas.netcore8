using API.Person.Domain;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace API.Person.Infrastructure.Database.Mappings;


public class PersonConfiguration : IEntityTypeConfiguration<PersonEntity>
{
    public void Configure(EntityTypeBuilder<PersonEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(p => p.Type)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(1);
    }
}

