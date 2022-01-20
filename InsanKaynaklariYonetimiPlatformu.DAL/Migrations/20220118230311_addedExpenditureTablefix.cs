using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class addedExpenditureTablefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_Personeller_EmployeeID",
                table: "Expenditures");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_Yöneticiler_ManagerID",
                table: "Expenditures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenditures",
                table: "Expenditures");

            migrationBuilder.RenameTable(
                name: "Expenditures",
                newName: "Harcamalar");

            migrationBuilder.RenameIndex(
                name: "IX_Expenditures_ManagerID",
                table: "Harcamalar",
                newName: "IX_Harcamalar_ManagerID");

            migrationBuilder.RenameIndex(
                name: "IX_Expenditures_EmployeeID",
                table: "Harcamalar",
                newName: "IX_Harcamalar_EmployeeID");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenditureName",
                table: "Harcamalar",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExpenditureAmount",
                table: "Harcamalar",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Harcamalar",
                table: "Harcamalar",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Harcamalar_Personeller_EmployeeID",
                table: "Harcamalar",
                column: "EmployeeID",
                principalTable: "Personeller",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Harcamalar_Yöneticiler_ManagerID",
                table: "Harcamalar",
                column: "ManagerID",
                principalTable: "Yöneticiler",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Harcamalar_Personeller_EmployeeID",
                table: "Harcamalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Harcamalar_Yöneticiler_ManagerID",
                table: "Harcamalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Harcamalar",
                table: "Harcamalar");

            migrationBuilder.RenameTable(
                name: "Harcamalar",
                newName: "Expenditures");

            migrationBuilder.RenameIndex(
                name: "IX_Harcamalar_ManagerID",
                table: "Expenditures",
                newName: "IX_Expenditures_ManagerID");

            migrationBuilder.RenameIndex(
                name: "IX_Harcamalar_EmployeeID",
                table: "Expenditures",
                newName: "IX_Expenditures_EmployeeID");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenditureName",
                table: "Expenditures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExpenditureAmount",
                table: "Expenditures",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenditures",
                table: "Expenditures",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_Personeller_EmployeeID",
                table: "Expenditures",
                column: "EmployeeID",
                principalTable: "Personeller",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_Yöneticiler_ManagerID",
                table: "Expenditures",
                column: "ManagerID",
                principalTable: "Yöneticiler",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
