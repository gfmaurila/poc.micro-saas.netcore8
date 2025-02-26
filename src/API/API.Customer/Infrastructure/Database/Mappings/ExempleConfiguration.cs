using API.Customer.Feature.Domain.Exemple;
using Common.Core._08.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace API.Customer.Infrastructure.Database.Mappings;

/// <summary>
/// Configures the database mapping for the <see cref="ExempleEntity"/> entity.
/// Defines constraints, column types, and owned entities for EF Core.
/// </summary>
public class ExempleConfiguration : IEntityTypeConfiguration<ExempleEntity>
{
    /// <summary>
    /// Configures the entity properties, relationships, and constraints.
    /// </summary>
    /// <param name="builder">The entity type builder used for configuration.</param>
    public void Configure(EntityTypeBuilder<ExempleEntity> builder)
    {
        // Applies base entity configuration (e.g., ID, timestamps)
        builder.ConfigureBaseEntity();

        #region Property Configuration

        builder
            .Property(entity => entity.FirstName)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(100);

        builder
            .Property(entity => entity.LastName)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(100);

        builder
            .Property(entity => entity.Gender)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(6)
            .HasConversion<string>(); // Stores Enum as string

        builder
            .Property(entity => entity.Notification)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(10)
            .HasConversion<string>(); // Stores Enum as string

        #endregion

        #region Owned Entities (Complex Types)

        // Configures Phone as a complex type with a separate column
        builder.OwnsOne(entity => entity.Phone, ownedNav =>
        {
            ownedNav
                .Property(phone => phone.Phone)
                .IsRequired() // NOT NULL
                .IsUnicode(false) // VARCHAR
                .HasMaxLength(20)
                .HasColumnName(nameof(ExempleEntity.Phone));
        });

        // Configures Email as a complex type with a separate column
        builder.OwnsOne(entity => entity.Email, ownedNav =>
        {
            ownedNav
                .Property(email => email.Address)
                .IsRequired() // NOT NULL
                .IsUnicode(false) // VARCHAR
                .HasMaxLength(254)
                .HasColumnName(nameof(ExempleEntity.Email));
        });

        #endregion

        #region Role Property Configuration

        // Configures Role as a JSON serialized string in the database
        builder.Property(entity => entity.Role)
            .IsRequired()
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), // Converts List<string> to JSON
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)) // Converts JSON back to List<string>
            .IsUnicode(false)
            .HasMaxLength(2048);

        #endregion
    }
}
