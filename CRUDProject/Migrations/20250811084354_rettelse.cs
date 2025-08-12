using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDProject.Migrations
{
    /// <inheritdoc />
    public partial class rettelse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medarbejder");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Løn = table.Column<long>(type: "bigint", nullable: false),
                    PersonNummer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Afdeling = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.CreateTable(
                name: "Medarbejder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Afdeling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Løn = table.Column<long>(type: "bigint", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonNummer = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medarbejder", x => x.Id);
                });
        }
    }
}
