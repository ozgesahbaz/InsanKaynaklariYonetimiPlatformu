using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class deneme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deneme",
                table: "Vardiyalar");

            migrationBuilder.AddColumn<int>(
                name: "deneme",
                table: "Molalar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deneme",
                table: "Molalar");

            migrationBuilder.AddColumn<int>(
                name: "deneme",
                table: "Vardiyalar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
