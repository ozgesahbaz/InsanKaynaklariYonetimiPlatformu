﻿// <auto-generated />
using System;
using InsanKaynaklariYonetimiPlatformu.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Migrations
{
    [DbContext(typeof(HRDataBaseContext))]
    [Migration("20220207175955_init1")]
    partial class init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeShift", b =>
                {
                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ShiftsShiftId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesEmployeeId", "ShiftsShiftId");

                    b.HasIndex("ShiftsShiftId");

                    b.ToTable("EmployeeShift");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Adminler");

                    b.HasData(
                        new
                        {
                            AdminId = 1,
                            FullName = "Red Team",
                            Password = "admin",
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("ManagerId")
                        .IsUnique();

                    b.ToTable("Yorumlar");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CompanyLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MailExtension")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CompanyId");

                    b.ToTable("Şirketler");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Debit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DebitName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DescofRejec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<bool?>("IsAproved")
                        .HasColumnType("bit");

                    b.Property<int?>("ManagerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("date");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Zimmetler");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Document", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EmployeeID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("DocumentID");

                    b.HasIndex("DocumentPath")
                        .IsUnique();

                    b.HasIndex("EmployeeID");

                    b.ToTable("Dokumanlar");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("date");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<decimal>("NetSalary")
                        .HasMaxLength(10)
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("image");

                    b.Property<decimal>("PremiumRate")
                        .HasMaxLength(5)
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.Property<decimal>("Salary")
                        .HasMaxLength(10)
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("ShiftID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ManagerId");

                    b.ToTable("Personeller");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Expenditure", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<decimal>("ExpenditureAmount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ExpenditureName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("ManagerID")
                        .HasColumnType("int");

                    b.Property<bool?>("isAproved")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Harcamalar");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.ExpenditureDocument", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ExpenditureId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("DocumentID");

                    b.HasIndex("DocumentPath")
                        .IsUnique();

                    b.HasIndex("ExpenditureId");

                    b.ToTable("Harcama Dökümanları");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManagerId");

                    b.HasIndex("AdminId");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Yöneticiler");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Membership", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("MembershipType")
                        .HasColumnType("int");

                    b.HasKey("MembershipId");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("ÜyelikTürleri");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("date");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionType")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<bool?>("isAproved")
                        .HasColumnType("bit");

                    b.HasKey("PermissionId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ManagerId");

                    b.ToTable("İzinler");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Respite", b =>
                {
                    b.Property<int>("RespiteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("RespiteFinishTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RespiteStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ShiftId")
                        .HasColumnType("int");

                    b.HasKey("RespiteID");

                    b.HasIndex("ShiftId");

                    b.ToTable("Molalar");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShiftFinishTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShiftStartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ShiftId");

                    b.ToTable("Vardiyalar");
                });

            modelBuilder.Entity("EmployeeShift", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Shift", null)
                        .WithMany()
                        .HasForeignKey("ShiftsShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Comment", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Manager", "Manager")
                        .WithOne("Comment")
                        .HasForeignKey("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Comment", "ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Debit", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Employee", "Employee")
                        .WithMany("Debits")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Manager", "Manager")
                        .WithMany("Debits")
                        .HasForeignKey("ManagerID");

                    b.Navigation("Employee");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Document", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Employee", "Employee")
                        .WithMany("Documents")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Employee", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Company", null)
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");

                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Manager", null)
                        .WithMany("Employees")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Expenditure", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Employee", "Employee")
                        .WithMany("Expenditures")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Manager", "Manager")
                        .WithMany("Expenditures")
                        .HasForeignKey("ManagerID");

                    b.Navigation("Employee");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.ExpenditureDocument", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Expenditure", "Expenditure")
                        .WithMany("ExpenditureDocuments")
                        .HasForeignKey("ExpenditureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expenditure");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Manager", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Admin", "Admin")
                        .WithMany("Managers")
                        .HasForeignKey("AdminId");

                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Company", null)
                        .WithOne("Manager")
                        .HasForeignKey("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Manager", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Membership", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Company", "Company")
                        .WithOne("Membership")
                        .HasForeignKey("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Membership", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Permission", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Employee", "Employee")
                        .WithMany("Permissions")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Manager", "Manager")
                        .WithMany("Permissions")
                        .HasForeignKey("ManagerId");

                    b.Navigation("Employee");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Respite", b =>
                {
                    b.HasOne("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Shift", "Shift")
                        .WithMany("Respites")
                        .HasForeignKey("ShiftId");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Admin", b =>
                {
                    b.Navigation("Managers");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Company", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Manager");

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Employee", b =>
                {
                    b.Navigation("Debits");

                    b.Navigation("Documents");

                    b.Navigation("Expenditures");

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Expenditure", b =>
                {
                    b.Navigation("ExpenditureDocuments");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Manager", b =>
                {
                    b.Navigation("Comment");

                    b.Navigation("Debits");

                    b.Navigation("Employees");

                    b.Navigation("Expenditures");

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("InsanKaynaklariYonetimiPlatformu.Entity.Entities.Shift", b =>
                {
                    b.Navigation("Respites");
                });
#pragma warning restore 612, 618
        }
    }
}