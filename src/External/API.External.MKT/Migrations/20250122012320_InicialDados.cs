using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.External.MKT.Migrations
{
    public partial class InicialDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inicializar o PasswordHasher
            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Gerar hashes de senha
            var adminPasswordHash = passwordHasher.HashPassword(null, "@G18u03i1987"); // Senha do admin
            var userPasswordHash = passwordHasher.HashPassword(null, "@G18u03i1987");  // Senha do user

            // Inserir Roles (Perfis)
            migrationBuilder.Sql(@"
                INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
                VALUES 
                ('1', 'Admin', 'ADMIN', NEWID()),
                ('2', 'User', 'USER', NEWID());
            ");

            // Inserir Usuários com hashes de senha
            migrationBuilder.Sql($@"
                INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
                VALUES
                ('1', 'admin', 'ADMIN', 'admin@example.com', 'ADMIN@EXAMPLE.COM', 1, '{adminPasswordHash}', NEWID(), NEWID(), 0, 0, 1, 0),
                ('2', 'user1', 'USER1', 'user1@example.com', 'USER1@EXAMPLE.COM', 1, '{userPasswordHash}', NEWID(), NEWID(), 0, 0, 1, 0);
            ");

            // Relacionar Usuários com Roles
            migrationBuilder.Sql(@"
                INSERT INTO AspNetUserRoles (UserId, RoleId)
                VALUES 
                ('1', '1'), -- Admin User com Role Admin
                ('2', '2'); -- User1 com Role User
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover relacionamentos entre usuários e roles
            migrationBuilder.Sql("DELETE FROM AspNetUserRoles WHERE UserId IN ('1', '2');");

            // Remover usuários
            migrationBuilder.Sql("DELETE FROM AspNetUsers WHERE Id IN ('1', '2');");

            // Remover roles
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Id IN ('1', '2');");
        }
    }
}
