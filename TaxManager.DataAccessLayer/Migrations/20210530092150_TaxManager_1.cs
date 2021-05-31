using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxManager.DataAccessLayer.Migrations
{
    public partial class TaxManager_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TaxManager");

            migrationBuilder.CreateTable(
                name: "MunicipalityTax",
                schema: "TaxManager",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    MunicipalityName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipalityTax", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MunicipalityTax",
                schema: "TaxManager");
        }
    }
}
