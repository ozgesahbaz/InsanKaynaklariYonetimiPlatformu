using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    public partial class addeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminler",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminler", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Şirketler",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MailExtension = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyLogo = table.Column<byte[]>(type: "image", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Şirketler", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "ÜyelikTürleri",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipType = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ÜyelikTürleri", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK_ÜyelikTürleri_Şirketler_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Şirketler",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yöneticiler",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<byte[]>(type: "image", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yöneticiler", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Yöneticiler_Adminler_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Adminler",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yöneticiler_Şirketler_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Şirketler",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Photo = table.Column<byte[]>(type: "image", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Personeller_Şirketler_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Şirketler",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personeller_Yöneticiler_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Yöneticiler",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Yöneticiler_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Yöneticiler",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "İzinler",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermissionType = table.Column<int>(type: "int", nullable: false),
                    isAproved = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İzinler", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_İzinler_Personeller_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Personeller",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_İzinler_Yöneticiler_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Yöneticiler",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Adminler",
                columns: new[] { "AdminId", "FullName" },
                values: new object[] { 1, "Red Team" });

            migrationBuilder.CreateIndex(
                name: "IX_İzinler_EmployeeId",
                table: "İzinler",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_İzinler_ManagerId",
                table: "İzinler",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_CompanyId",
                table: "Personeller",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_Email",
                table: "Personeller",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_ManagerId",
                table: "Personeller",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ÜyelikTürleri_CompanyId",
                table: "ÜyelikTürleri",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_ManagerId",
                table: "Yorumlar",
                column: "ManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yöneticiler_AdminId",
                table: "Yöneticiler",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Yöneticiler_CompanyId",
                table: "Yöneticiler",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yöneticiler_Email",
                table: "Yöneticiler",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "İzinler");

            migrationBuilder.DropTable(
                name: "ÜyelikTürleri");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropTable(
                name: "Yöneticiler");

            migrationBuilder.DropTable(
                name: "Adminler");

            migrationBuilder.DropTable(
                name: "Şirketler");
        }
    }
}
