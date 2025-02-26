using Common.Core._08.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Core._08.Extensions;

/// <summary>
/// Provides extension methods for configuring base entity mappings in Entity Framework Core.
/// </summary>
public static class EntityTypeBuilderExtensions
{
    /// <summary>
    /// Configures the base entity mappings for a given entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to configure.</typeparam>
    /// <param name="builder">The <see cref="EntityTypeBuilder{TEntity}"/> used to configure the entity.</param>
    public static void ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseEntity
    {
        // Configures the primary key
        builder
            .HasKey(entity => entity.Id); // Primary Key

        // Configures the 'Id' property
        builder
            .Property(entity => entity.Id)
            .IsRequired() // NOT NULL
            .ValueGeneratedNever(); // The ID is generated when the class is instantiated

        // Ignores the 'DomainEvents' property to prevent creating a corresponding column in the table
        builder
            .Ignore(entity => entity.DomainEvents);
    }
}

