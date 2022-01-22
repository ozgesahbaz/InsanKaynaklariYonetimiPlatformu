using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isAproved",
                table: "İzinler",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Adminler",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "UserName",
                value: "admin@admin.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isAproved",
                table: "İzinler",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Adminler",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "UserName",
                value: "admin");
        }
    }
}
