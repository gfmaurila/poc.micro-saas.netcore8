using API.Person.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace API.Person.Infrastructure.Database.Mappings;



public class LegalEntityConfiguration : IEntityTypeConfiguration<LegalEntity>
{
    public void Configure(EntityTypeBuilder<LegalEntity> builder)
    {
        builder.HasBaseType<PersonEntity>();

        builder.Property(le => le.CNPJ)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(18);
    }
}

