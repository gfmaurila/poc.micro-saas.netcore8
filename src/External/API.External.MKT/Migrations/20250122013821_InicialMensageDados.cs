using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.External.MKT.Migrations
{
    public partial class InicialMensageDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 100; i++)
            {
                migrationBuilder.Sql($@"
                    INSERT INTO Messages (Title, Content, CreatedAt)
                    VALUES 
                    ('Message Title {i}', 'This is the content for message {i}.', GETDATE());
                ");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove os 100 registros adicionados
            for (int i = 1; i <= 100; i++)
            {
                migrationBuilder.Sql($@"
                    DELETE FROM Messages WHERE Title = 'Message Title {i}';
                ");
            }
        }
    }
}
