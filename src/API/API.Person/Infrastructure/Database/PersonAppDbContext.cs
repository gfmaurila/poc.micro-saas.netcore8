using API.Person.Domain;
using API.Person.Feature.Domain.Exemple;
using API.Person.Infrastructure.Database.Mappings;
using Microsoft.EntityFrameworkCore;

namespace API.Person.Infrastructure.Database;

/// <summary>
/// Represents the database context for the Exemple application.
/// Provides access to database entities and configurations.
/// </summary>
public class PersonAppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PersonAppDbContext"/> class.
    /// Default constructor required for design-time tools.
    /// </summary>
    public PersonAppDbContext()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonAppDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The database context options.</param>
    public PersonAppDbContext(DbContextOptions<PersonAppDbContext> options) : base(options)
    { }

    /// <summary>
    /// Gets or sets the database set for Exemple entities.
    /// </summary>
    public virtual DbSet<ExempleEntity> Exemple { get; set; }

    public DbSet<PersonEntity> Person { get; set; }
    public DbSet<IndividualPersonEntity> IndividualPerson { get; set; }
    public DbSet<LegalEntity> LegalPerson { get; set; }
    public DbSet<DocumentEntity> Document { get; set; }
    public DbSet<AddressEntity> Address { get; set; }
    public DbSet<PhoneEntity> Phone { get; set; }
    public DbSet<EmailEntity> Email { get; set; }

    /// <summary>
    /// Configures the entity models and applies configurations when the database schema is created.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entity models.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExempleConfiguration());

        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new IndividualPersonConfiguration());
        modelBuilder.ApplyConfiguration(new LegalEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new PhoneConfiguration());
        modelBuilder.ApplyConfiguration(new EmailConfiguration());


        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Configures the database options, including logging settings.
    /// </summary>
    /// <param name="optionsBuilder">The options builder used to configure the database context.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        base.OnConfiguring(optionsBuilder);
    }

    /// <summary>
    /// Logger factory for debugging database queries.
    /// </summary>
    public static readonly LoggerFactory _loggerFactory = new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });
}
