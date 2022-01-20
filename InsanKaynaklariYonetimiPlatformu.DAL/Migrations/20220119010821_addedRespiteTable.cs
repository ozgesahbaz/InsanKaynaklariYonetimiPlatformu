using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class addedRespiteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShiftTimeSlot",
                table: "Vardiyalar",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Molalar",
                columns: table => new
                {
                    RespiteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespiteTimeSlot = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Molalar", x => x.RespiteID);
                    table.ForeignKey(
                        name: "FK_Molalar_Vardiyalar_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Vardiyalar",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Molalar_ShiftId",
                table: "Molalar",
                column: "ShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Molalar");

            migrationBuilder.DropColumn(
                name: "ShiftTimeSlot",
                table: "Vardiyalar");
        }
    }
}
