using API.Person.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace API.Person.Infrastructure.Database.Mappings;



public class IndividualPersonConfiguration : IEntityTypeConfiguration<IndividualPersonEntity>
{
    public void Configure(EntityTypeBuilder<IndividualPersonEntity> builder)
    {
        builder.HasBaseType<PersonEntity>();

        builder.Property(ip => ip.CPF)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(14);

        builder.Property(ip => ip.BirthDate)
            .IsRequired();
    }
}
