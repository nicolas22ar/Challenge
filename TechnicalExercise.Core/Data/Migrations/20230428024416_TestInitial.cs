using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechnicalExercise.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Value = table.Column<string>(type: "varchar(6)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Color = table.Column<string>(type: "varchar(50)", nullable: false),
                    Type = table.Column<string>(type: "varchar(10)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Plates_PlateId",
                        column: x => x.PlateId,
                        principalTable: "Plates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plates",
                columns: new[] { "Id", "Date", "Value" },
                values: new object[,]
                {
                    { new Guid("424afb80-5e12-4d4c-bb39-2d95e1bec5a4"), new DateTime(2023, 4, 30, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767), "IEK659" },
                    { new Guid("47e1940b-1ede-4f17-af18-4c01547c718a"), new DateTime(2023, 4, 27, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767), "LSK658" },
                    { new Guid("a27df079-c351-4fb8-b5e4-9802d6030ea8"), new DateTime(2023, 5, 1, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767), "KSI654" },
                    { new Guid("b4040714-aff6-4e9a-98b2-e769f69e74a7"), new DateTime(2023, 4, 29, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767), "USJ726" },
                    { new Guid("f8d2692d-3f0f-4d9a-9576-31aa1bf21db8"), new DateTime(2023, 4, 28, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767), "KSI695" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Color", "CreationDate", "PlateId", "Type" },
                values: new object[] { new Guid("0bd43b70-3ba3-41b5-a40c-80b0190fb5be"), "RED", new DateTime(2023, 4, 27, 23, 44, 16, 864, DateTimeKind.Local).AddTicks(4767), new Guid("47e1940b-1ede-4f17-af18-4c01547c718a"), "CAR" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Id",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PlateId",
                table: "Vehicles",
                column: "PlateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Plates");
        }
    }
}
