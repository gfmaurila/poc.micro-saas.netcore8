using API.Person.Domain;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace API.Person.Infrastructure.Database.Mappings;


public class EmailConfiguration : IEntityTypeConfiguration<EmailEntity>
{
    public void Configure(EntityTypeBuilder<EmailEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(e => e.Address)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(254);

        builder.HasOne(e => e.Person)
            .WithMany(p => p.Emails)
            .HasForeignKey(e => e.PersonId);
    }
}