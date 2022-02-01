using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
<<<<<<< HEAD:InsanKaynaklariYonetimiPlatformu.DAL/Migrations/20220131204324_init.cs
    public partial class init : Migration
=======
    public partial class initial : Migration
>>>>>>> f1c91758b666bb329ae03ba535ba77f965242743:InsanKaynaklariYonetimiPlatformu.DAL/Migrations/20220131193411_initial.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminler",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Şirketler", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Vardiyalar",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftFinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vardiyalar", x => x.ShiftId);
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
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Molalar",
                columns: table => new
                {
                    RespiteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespiteStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RespiteFinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    BirthDay = table.Column<DateTime>(type: "date", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", maxLength: 10, precision: 8, scale: 2, nullable: false),
                    PremiumRate = table.Column<decimal>(type: "decimal(3,2)", maxLength: 5, precision: 3, scale: 2, nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(8,2)", maxLength: 10, precision: 8, scale: 2, nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    ShiftID = table.Column<int>(type: "int", nullable: false),
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
                name: "Dokumanlar",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentPath = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumanlar", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Dokumanlar_Personeller_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Personeller",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShift",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ShiftsShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShift", x => new { x.EmployeesEmployeeId, x.ShiftsShiftId });
                    table.ForeignKey(
                        name: "FK_EmployeeShift_Personeller_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Personeller",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeShift_Vardiyalar_ShiftsShiftId",
                        column: x => x.ShiftsShiftId,
                        principalTable: "Vardiyalar",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harcamalar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenditureName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ExpenditureAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    ManagerID = table.Column<int>(type: "int", nullable: true),
                    isAproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harcamalar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Harcamalar_Personeller_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Personeller",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Harcamalar_Yöneticiler_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Yöneticiler",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "İzinler",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "date", nullable: false),
                    PermissionType = table.Column<int>(type: "int", nullable: false),
                    isAproved = table.Column<bool>(type: "bit", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Zimmetler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartedDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsAproved = table.Column<bool>(type: "bit", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescofRejec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    ManagerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zimmetler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zimmetler_Personeller_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Personeller",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zimmetler_Yöneticiler_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Yöneticiler",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Harcama Dökümanları",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentPath = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenditureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harcama Dökümanları", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Harcama Dökümanları_Harcamalar_ExpenditureId",
                        column: x => x.ExpenditureId,
                        principalTable: "Harcamalar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adminler",
                columns: new[] { "AdminId", "FullName", "Password", "UserName" },
                values: new object[] { 1, "Red Team", "admin", "admin@admin.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Dokumanlar_DocumentPath",
                table: "Dokumanlar",
                column: "DocumentPath",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dokumanlar_EmployeeID",
                table: "Dokumanlar",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_ShiftsShiftId",
                table: "EmployeeShift",
                column: "ShiftsShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Harcama Dökümanları_DocumentPath",
                table: "Harcama Dökümanları",
                column: "DocumentPath",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Harcama Dökümanları_ExpenditureId",
                table: "Harcama Dökümanları",
                column: "ExpenditureId");

            migrationBuilder.CreateIndex(
                name: "IX_Harcamalar_EmployeeID",
                table: "Harcamalar",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Harcamalar_ManagerID",
                table: "Harcamalar",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_İzinler_EmployeeId",
                table: "İzinler",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_İzinler_ManagerId",
                table: "İzinler",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Molalar_ShiftId",
                table: "Molalar",
                column: "ShiftId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Zimmetler_EmployeeID",
                table: "Zimmetler",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Zimmetler_ManagerID",
                table: "Zimmetler",
                column: "ManagerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokumanlar");

            migrationBuilder.DropTable(
                name: "EmployeeShift");

            migrationBuilder.DropTable(
                name: "Harcama Dökümanları");

            migrationBuilder.DropTable(
                name: "İzinler");

            migrationBuilder.DropTable(
                name: "Molalar");

            migrationBuilder.DropTable(
                name: "ÜyelikTürleri");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Zimmetler");

            migrationBuilder.DropTable(
                name: "Harcamalar");

            migrationBuilder.DropTable(
                name: "Vardiyalar");

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
