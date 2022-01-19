using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class addedDebitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAproved",
                table: "Harcamalar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Zimmetler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartedDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsAproved = table.Column<bool>(type: "bit", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescofRejec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zimmetler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zimmetler_Personeller_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Personeller",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zimmetler_EmployeeID",
                table: "Zimmetler",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zimmetler");

            migrationBuilder.DropColumn(
                name: "isAproved",
                table: "Harcamalar");
        }
    }
}
