using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEnd.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "challengedb",
                table: "Motorcycle",
                keyColumn: "Id",
                keyValue: new Guid("328c241a-8d0b-44ba-828d-1a242e47c434"));

            migrationBuilder.DeleteData(
                schema: "challengedb",
                table: "Motorcycle",
                keyColumn: "Id",
                keyValue: new Guid("43ff68cc-79cc-4bd0-b191-5528741098f9"));

            migrationBuilder.DeleteData(
                schema: "challengedb",
                table: "Motorcycle",
                keyColumn: "Id",
                keyValue: new Guid("ca0c47f2-a0e0-42c8-8eb9-800fb834832f"));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "challengedb",
                table: "Motorcycle",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "challengedb",
                table: "Couriers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "challengedb",
                table: "Motorcycle",
                columns: new[] { "Id", "IdRental", "LicensePlate", "Model", "Status", "Year" },
                values: new object[,]
                {
                    { new Guid("48851998-0452-45ab-b394-75aa4f27f35d"), null, "KKH-9067", "Forza 350", true, 2022 },
                    { new Guid("c30c3216-1ced-45fc-8faf-b4303d81ac80"), null, "MNF-3564", "CB 500F", true, 2015 },
                    { new Guid("c4e4612c-e118-4a8c-a1ad-792a1a01065e"), null, "JTY-1906", "CB 300F Twister", true, 2022 }
                });

            migrationBuilder.InsertData(
                schema: "challengedb",
                table: "Rental_Plan",
                columns: new[] { "Id", "CostPerDay", "Description", "Plan" },
                values: new object[,]
                {
                    { new Guid("83c363dc-3a02-44bd-b9f6-b081258dac72"), 22m, "30 days", 3 },
                    { new Guid("ac843545-072b-43a1-86b5-0bd92a4d43a9"), 30m, "7 days", 1 },
                    { new Guid("bfd1ecee-951f-4caa-83ff-4388f4faa811"), 28m, "15 days", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "challengedb",
                table: "Motorcycle",
                keyColumn: "Id",
                keyValue: new Guid("48851998-0452-45ab-b394-75aa4f27f35d"));

            migrationBuilder.DeleteData(
                schema: "challengedb",
                table: "Motorcycle",
                keyColumn: "Id",
                keyValue: new Guid("c30c3216-1ced-45fc-8faf-b4303d81ac80"));

            migrationBuilder.DeleteData(
                schema: "challengedb",
                table: "Motorcycle",
                keyColumn: "Id",
                keyValue: new Guid("c4e4612c-e118-4a8c-a1ad-792a1a01065e"));

            migrationBuilder.DeleteData(
                schema: "challengedb",
                table: "Rental_Plan",
                keyColumn: "Id",
                keyValue: new Guid("83c363dc-3a02-44bd-b9f6-b081258dac72"));

            migrationBuilder.DeleteData(
                schema: "challengedb",
                table: "Rental_Plan",
                keyColumn: "Id",
                keyValue: new Guid("ac843545-072b-43a1-86b5-0bd92a4d43a9"));

            migrationBuilder.DeleteData(
                schema: "challengedb",
                table: "Rental_Plan",
                keyColumn: "Id",
                keyValue: new Guid("bfd1ecee-951f-4caa-83ff-4388f4faa811"));

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "challengedb",
                table: "Motorcycle");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "challengedb",
                table: "Couriers");

            migrationBuilder.InsertData(
                schema: "challengedb",
                table: "Motorcycle",
                columns: new[] { "Id", "IdRental", "LicensePlate", "Model", "Year" },
                values: new object[,]
                {
                    { new Guid("328c241a-8d0b-44ba-828d-1a242e47c434"), null, "JTY-1906", "CB 300F Twister", 2022 },
                    { new Guid("43ff68cc-79cc-4bd0-b191-5528741098f9"), null, "MNF-3564", "CB 500F", 2015 },
                    { new Guid("ca0c47f2-a0e0-42c8-8eb9-800fb834832f"), null, "KKH-9067", "Forza 350", 2022 }
                });
        }
    }
}
