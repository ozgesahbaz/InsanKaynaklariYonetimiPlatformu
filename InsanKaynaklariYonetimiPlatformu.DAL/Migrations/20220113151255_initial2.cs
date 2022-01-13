using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İzinler_Personeller_EmployeeId",
                table: "İzinler");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "İzinler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_İzinler_Personeller_EmployeeId",
                table: "İzinler",
                column: "EmployeeId",
                principalTable: "Personeller",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İzinler_Personeller_EmployeeId",
                table: "İzinler");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "İzinler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_İzinler_Personeller_EmployeeId",
                table: "İzinler",
                column: "EmployeeId",
                principalTable: "Personeller",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
