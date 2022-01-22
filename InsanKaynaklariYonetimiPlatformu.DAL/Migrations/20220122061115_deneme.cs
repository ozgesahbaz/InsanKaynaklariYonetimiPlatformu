using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zimmetler_Personeller_EmployeeID",
                table: "Zimmetler");

            migrationBuilder.DropColumn(
                name: "ShiftName",
                table: "Vardiyalar");

            migrationBuilder.DropColumn(
                name: "ShiftTimeSlot",
                table: "Vardiyalar");

            migrationBuilder.DropColumn(
                name: "RespiteTimeSlot",
                table: "Molalar");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Zimmetler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ManagerID",
                table: "Zimmetler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShiftFinishTime",
                table: "Vardiyalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ShiftStartTime",
                table: "Vardiyalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "deneme",
                table: "Vardiyalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RespiteFinishTime",
                table: "Molalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RespiteStartTime",
                table: "Molalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Zimmetler_ManagerID",
                table: "Zimmetler",
                column: "ManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zimmetler_Personeller_EmployeeID",
                table: "Zimmetler",
                column: "EmployeeID",
                principalTable: "Personeller",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zimmetler_Yöneticiler_ManagerID",
                table: "Zimmetler",
                column: "ManagerID",
                principalTable: "Yöneticiler",
                principalColumn: "ManagerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zimmetler_Personeller_EmployeeID",
                table: "Zimmetler");

            migrationBuilder.DropForeignKey(
                name: "FK_Zimmetler_Yöneticiler_ManagerID",
                table: "Zimmetler");

            migrationBuilder.DropIndex(
                name: "IX_Zimmetler_ManagerID",
                table: "Zimmetler");

            migrationBuilder.DropColumn(
                name: "ManagerID",
                table: "Zimmetler");

            migrationBuilder.DropColumn(
                name: "ShiftFinishTime",
                table: "Vardiyalar");

            migrationBuilder.DropColumn(
                name: "ShiftStartTime",
                table: "Vardiyalar");

            migrationBuilder.DropColumn(
                name: "deneme",
                table: "Vardiyalar");

            migrationBuilder.DropColumn(
                name: "RespiteFinishTime",
                table: "Molalar");

            migrationBuilder.DropColumn(
                name: "RespiteStartTime",
                table: "Molalar");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Zimmetler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShiftName",
                table: "Vardiyalar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShiftTimeSlot",
                table: "Vardiyalar",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RespiteTimeSlot",
                table: "Molalar",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Zimmetler_Personeller_EmployeeID",
                table: "Zimmetler",
                column: "EmployeeID",
                principalTable: "Personeller",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
