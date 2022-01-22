using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class changeEmployedShiftbond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShiftID",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShiftID",
                table: "Personeller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
