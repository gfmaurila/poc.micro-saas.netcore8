using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.External.MKT.Database;


public static class InfrastructureExtensions
{
    //public static void ApplyMigrations(this IHost app)
    //{
    //    using (var scope = app.Services.CreateScope())
    //    {
    //        var services = scope.ServiceProvider;
    //        try
    //        {
    //            var context = services.GetRequiredService<ApplicationDbContext>();
    //            context.Database.Migrate();
    //            Console.WriteLine("Database migrations applied successfully.");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"An error occurred while applying migrations: {ex.Message}");
    //            throw;
    //        }
    //    }
    //}

    public static void ApplyMigrations(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();

        for (int i = 0; i < 10; i++) // Tenta conectar por até 50 segundos
        {
            try
            {
                context.Database.Migrate();
                Console.WriteLine("Database migrations applied successfully.");
                return;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Server is not ready yet ({ex.Message}). Retrying in 5 seconds...");
                Thread.Sleep(5000);
            }
        }

        throw new Exception("Unable to connect to SQL Server after 10 attempts.");
    }
}
