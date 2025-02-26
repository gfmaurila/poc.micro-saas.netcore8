using Common.External.Auth.Net8.Enumerado;
using Common.External.Auth.Net8.Extensions;
using Common.External.Auth.Net8.User;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text.Json;

#nullable disable

namespace API.External.Auth.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Notification = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", unicode: false, maxLength: 254, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleUserAuth = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            // Array de GUIDs fixos
            Guid[] guidArray = new Guid[]
            {
                new Guid("02759B98-F969-48F7-AD53-C02AFD90C844"),
                new Guid("68888282-EC69-44FA-8303-DD460C117F44"),
                new Guid("F0ACECE8-6C6B-41FF-B523-2364AE602DCC"),
                new Guid("C49642D8-8ED4-4589-9D3A-A4DE441422C4"),
                new Guid("8B0FF838-6445-47DC-8D13-8EC4B22CF9F5"),
                new Guid("A1C5CF35-964D-4D48-944D-B198F3F3649B"),
                new Guid("7FC337F9-93C8-4473-A05B-67D32C66290C"),
                new Guid("A7C54242-CA68-4C0D-8522-F2643A3483D4"),
                new Guid("0126410F-90B2-4CD1-9A6F-FFBD898298FC"),
                new Guid("C523CF8F-9230-4FA1-9B2A-378D16FD0822")
            };

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Gender", "DateOfBirth", "Email", "Password", "RoleUserAuth", "Notification", "Phone" },
                values: new object[]
                {
                    "9A749D84-5734-4FAA-95C2-CF2B209EBE89",
                    "AuthTest",
                    "AuthTest",
                    EGender.Male.ToString(),
                    new DateTime(1986, 03, 18),
                    "auth@auth.com.br",
                    Password.ComputeSha256Hash("Test123$"),
                    JsonSerializer.Serialize(new List<string>
                    {
                        ERoleUserAuth.ADMIN_AUTH.ToString(),
                        ERoleUserAuth.EMPLOYEE_AUTH.ToString(),
                        ERoleUserAuth.ADMIN_EXEMPLE.ToString(),
                        ERoleUserAuth.EMPLOYEE_EXEMPLE.ToString(),
                    }, (JsonSerializerOptions)null),
                    "WhatsApp",
                    "51985623999"
                }
            );

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Gender", "DateOfBirth", "Email", "Password", "RoleUserAuth", "Notification", "Phone" },
                values: new object[]
                {
                    "11ADD073-9B94-4FD3-8073-27443423E1D0",
                    "Guilherme",
                    "Figueiras Maurila",
                    EGender.Male.ToString(),
                    new DateTime(1986, 03, 18),
                    "gfmaurila@gmail.com",
                    Password.ComputeSha256Hash("@C23l10a1985"),
                    JsonSerializer.Serialize(new List<string>
                    {
                        ERoleUserAuth.ADMIN_AUTH.ToString(),
                        ERoleUserAuth.EMPLOYEE_AUTH.ToString(),
                        ERoleUserAuth.ADMIN_EXEMPLE.ToString(),
                        ERoleUserAuth.EMPLOYEE_EXEMPLE.ToString(),
                    }, (JsonSerializerOptions)null),
                    "WhatsApp",
                    "51985623312"
                }
            );

            int count = 0;

            Random random = new Random();

            string[] contactMethods = new[] { "WhatsApp", "SMS", "Email" };

            foreach (var guid in guidArray)
            {
                count++;

                // Seleciona um método de contato aleatório
                string randomContactMethod = contactMethods[random.Next(contactMethods.Length)];

                // Inserir dados falsos
                migrationBuilder.InsertData(
                    table: "User",
                    columns: new[] { "Id", "FirstName", "LastName", "Gender", "DateOfBirth", "Email", "Password", "RoleUserAuth", "Notification", "Phone" },
                    values: new object[]
                    {
                        guid,
                        $"NomeTeste-{count}",
                        $"SobreNomeTeste-{count}",
                        EGender.Male.ToString(),
                        new DateTime(1986, 03, 18),
                        $"emailteste-{count}@teste.com.br",
                        Password.ComputeSha256Hash($"@C{count}3l10a1985"),
                        JsonSerializer.Serialize(new List<string>
                        {
                            ERoleUserAuth.ADMIN_AUTH.ToString(),
                            ERoleUserAuth.EMPLOYEE_AUTH.ToString(),
                            ERoleUserAuth.ADMIN_EXEMPLE.ToString(),
                            ERoleUserAuth.EMPLOYEE_EXEMPLE.ToString(),
                        }, (JsonSerializerOptions)null),
                        randomContactMethod,
                        $"519{count}56{count}33{count}2"
                    }
                );
            }





            for (int i = 0; i < 10; i++)
            {

                // Seleciona um método de contato aleatório
                string randomContactMethod = contactMethods[random.Next(contactMethods.Length)];

                // Inserir dados falsos
                migrationBuilder.InsertData(
                    table: "User",
                    columns: new[] { "Id", "FirstName", "LastName", "Gender", "DateOfBirth", "Email", "Password", "RoleUserAuth", "Notification", "Phone" },
                    values: new object[]
                    {
                        Guid.NewGuid(),
                        $"NomeTesteFake-{i}",
                        $"SobreNomeTesteFake-{i}",
                        EGender.Male.ToString(),
                        new DateTime(1986, 03, 18),
                        $"emailtesteFake-{i}@testeFake.com.br",
                        Password.ComputeSha256Hash($"@C{i}3l10a1985"),
                        JsonSerializer.Serialize(new List<string>
                        {
                            ERoleUserAuth.ADMIN_AUTH.ToString(),
                            ERoleUserAuth.EMPLOYEE_AUTH.ToString(),
                            ERoleUserAuth.ADMIN_EXEMPLE.ToString(),
                            ERoleUserAuth.EMPLOYEE_EXEMPLE.ToString(),
                        }, (JsonSerializerOptions)null),
                        randomContactMethod,
                        $"519{i}56{i}33{i}2"
                    }
                );
            }

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
