using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Personeller_EmployeeID",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Dokumanlar");

            migrationBuilder.RenameIndex(
                name: "IX_Document_EmployeeID",
                table: "Dokumanlar",
                newName: "IX_Dokumanlar_EmployeeID");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Dokumanlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentPath",
                table: "Dokumanlar",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dokumanlar",
                table: "Dokumanlar",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Dokumanlar_DocumentPath",
                table: "Dokumanlar",
                column: "DocumentPath",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dokumanlar_Personeller_EmployeeID",
                table: "Dokumanlar",
                column: "EmployeeID",
                principalTable: "Personeller",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dokumanlar_Personeller_EmployeeID",
                table: "Dokumanlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dokumanlar",
                table: "Dokumanlar");

            migrationBuilder.DropIndex(
                name: "IX_Dokumanlar_DocumentPath",
                table: "Dokumanlar");

            migrationBuilder.RenameTable(
                name: "Dokumanlar",
                newName: "Document");

            migrationBuilder.RenameIndex(
                name: "IX_Dokumanlar_EmployeeID",
                table: "Document",
                newName: "IX_Document_EmployeeID");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Document",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentPath",
                table: "Document",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "DocumentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Personeller_EmployeeID",
                table: "Document",
                column: "EmployeeID",
                principalTable: "Personeller",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
