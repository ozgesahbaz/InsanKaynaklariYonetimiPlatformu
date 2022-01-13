using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "İzinler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_İzinler_ManagerId",
                table: "İzinler",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_İzinler_Yöneticiler_ManagerId",
                table: "İzinler",
                column: "ManagerId",
                principalTable: "Yöneticiler",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_İzinler_Yöneticiler_ManagerId",
                table: "İzinler");

            migrationBuilder.DropIndex(
                name: "IX_İzinler_ManagerId",
                table: "İzinler");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "İzinler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
