using API.Person.Domain;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace API.Person.Infrastructure.Database.Mappings;


public class DocumentConfiguration : IEntityTypeConfiguration<DocumentEntity>
{
    public void Configure(EntityTypeBuilder<DocumentEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(d => d.Type)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(50);

        builder.Property(d => d.Number)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(50);

        builder.HasOne(d => d.Person)
            .WithMany(p => p.Documents)
            .HasForeignKey(d => d.PersonId);
    }
}
