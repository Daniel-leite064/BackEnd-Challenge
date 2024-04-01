using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEnd.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "challengedb");

            migrationBuilder.CreateTable(
                name: "Notification",
                schema: "challengedb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateNotification = table.Column<DateTime>(type: "date", nullable: false),
                    IdOrder = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCourier = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "challengedb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCourier = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    RideCost = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rental_Plan",
                schema: "challengedb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Plan = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CostPerDay = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                schema: "challengedb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMotorcycle = table.Column<Guid>(type: "uuid", nullable: true),
                    IdCourier = table.Column<Guid>(type: "uuid", nullable: true),
                    RentalPlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    IdRentalPlans = table.Column<Guid>(type: "uuid", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rental_Rental_Plan_RentalPlanId",
                        column: x => x.RentalPlanId,
                        principalSchema: "challengedb",
                        principalTable: "Rental_Plan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Couriers",
                schema: "challengedb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    DateBirth = table.Column<DateTime>(type: "date", nullable: false),
                    LicenseDriverNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LicenseDriverType = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    IdRental = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couriers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Couriers_Rental_IdRental",
                        column: x => x.IdRental,
                        principalSchema: "challengedb",
                        principalTable: "Rental",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Motorcycle",
                schema: "challengedb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LicensePlate = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    IdRental = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorcycle_Rental_IdRental",
                        column: x => x.IdRental,
                        principalSchema: "challengedb",
                        principalTable: "Rental",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_Cnpj",
                schema: "challengedb",
                table: "Couriers",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_IdRental",
                schema: "challengedb",
                table: "Couriers",
                column: "IdRental");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_LicenseDriverNumber",
                schema: "challengedb",
                table: "Couriers",
                column: "LicenseDriverNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycle_IdRental",
                schema: "challengedb",
                table: "Motorcycle",
                column: "IdRental");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycle_LicensePlate",
                schema: "challengedb",
                table: "Motorcycle",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rental_RentalPlanId",
                schema: "challengedb",
                table: "Rental",
                column: "RentalPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_Plan_Plan",
                schema: "challengedb",
                table: "Rental_Plan",
                column: "Plan",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Couriers",
                schema: "challengedb");

            migrationBuilder.DropTable(
                name: "Motorcycle",
                schema: "challengedb");

            migrationBuilder.DropTable(
                name: "Notification",
                schema: "challengedb");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "challengedb");

            migrationBuilder.DropTable(
                name: "Rental",
                schema: "challengedb");

            migrationBuilder.DropTable(
                name: "Rental_Plan",
                schema: "challengedb");
        }
    }
}
