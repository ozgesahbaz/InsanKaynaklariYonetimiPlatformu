using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class addedshifttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirtDay",
                table: "Personeller",
                newName: "BirthDay");

            migrationBuilder.AddColumn<int>(
                name: "ShiftID",
                table: "Personeller",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Adminler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Adminler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vardiyalar",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vardiyalar", x => x.ShiftId);
                });

            migrationBuilder.UpdateData(
                table: "Adminler",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "Password", "UserName" },
                values: new object[] { "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_ShiftID",
                table: "Personeller",
                column: "ShiftID");

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Vardiyalar_ShiftID",
                table: "Personeller",
                column: "ShiftID",
                principalTable: "Vardiyalar",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Vardiyalar_ShiftID",
                table: "Personeller");

            migrationBuilder.DropTable(
                name: "Vardiyalar");

            migrationBuilder.DropIndex(
                name: "IX_Personeller_ShiftID",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "ShiftID",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Adminler");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Adminler");

            migrationBuilder.RenameColumn(
                name: "BirthDay",
                table: "Personeller",
                newName: "BirtDay");
        }
    }
}
