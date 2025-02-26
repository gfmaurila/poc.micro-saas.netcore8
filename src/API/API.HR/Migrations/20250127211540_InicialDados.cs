﻿using Bogus;
using Common.Core._08.Domain.Enumerado;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.HR.Migrations
{
    /// <inheritdoc />
    public partial class InicialDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var faker = new Faker();

            // Obtemos todos os valores do enum ERole como uma lista
            var roles = Enum.GetValues(typeof(ERole))
                            .Cast<ERole>() // Converte para IEnumerable<ERole>
                            .OrderBy(_ => faker.Random.Double()) // Randomiza a ordem
                            .Take(2) // Seleciona 2 valores aleatórios
                            .Select(role => role.ToString()) // Converte para string
                            .ToArray();


            // Lista para armazenar os dados gerados
            var mockData = new List<object>();

            for (int i = 0; i < 100; i++)
            {
                mockData.Add(new
                {
                    Id = Guid.NewGuid(),
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Gender = faker.PickRandom<EGender>(), // Enum EGender
                    Notification = faker.PickRandom<ENotificationType>().ToString(), // Enum ENotificationType
                    Email = faker.Internet.Email(),
                    Phone = faker.Phone.PhoneNumber("+1##########"),
                    Role = string.Join(",", roles), // Combina múltiplas permissões em uma string,
                    Status = true
                });
            }

            // Inserção dos dados no banco de dados
            foreach (var data in mockData)
            {
                migrationBuilder.InsertData(
                    table: "Exemple",
                    columns: new[] { "Id", "FirstName", "LastName", "Gender", "Notification", "Email", "Phone", "Role", "Status" },
                    values: new object[]
                    {
            ((dynamic)data).Id,
            ((dynamic)data).FirstName,
            ((dynamic)data).LastName,
            ((dynamic)data).Gender.ToString(),
            ((dynamic)data).Notification,
            ((dynamic)data).Email,
            ((dynamic)data).Phone,
            ((dynamic)data).Role,
            ((dynamic)data).Status
                    }
                );
            }

            migrationBuilder.Sql("UPDATE [API_Exemple].[dbo].[Exemple] SET Role = '[\"ADMIN_AUTH\", \"EMPLOYEE_AUTH\"]' ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
