using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations
{
    public partial class dbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MotherName",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BodyRemark",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AcademyId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcademyId",
                table: "Hostels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcademyId",
                table: "CourseCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Academies",
                columns: table => new
                {
                    AcademyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academies", x => x.AcademyId);
                });

            migrationBuilder.InsertData(
                table: "Academies",
                columns: new[] { "AcademyId", "AcademyName", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "LastUpdatedAt", "LastUpdatedBy" },
                values: new object[,]
                {
                    { 1, "Impact Academy, Hisar", new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5920), null, true, false, null, null },
                    { 2, "Impact Academy, Chaudhariwas", new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5939), null, true, false, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5431), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5492), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5508), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5521), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5533), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5551), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5564), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5576), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5588), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5601), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5615), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5629), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5640), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5652), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5664), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5676), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5752), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5768), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5780), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5792), true, false });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "RoleID", "UserID" },
                values: new object[,]
                {
                    { 1, null, null, true, false, 1, 1 },
                    { 2, null, null, true, false, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UsersId", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "IsEmailConfirmed", "IsMobileConfirmed", "LastUpdatedAt", "LastUpdatedBy", "UserEmail", "UserMobile", "UserPassword" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5823), null, true, false, true, true, null, null, "bn2mehlan510@gmail.com", "9416669174", "Admin@123" },
                    { 2, new DateTime(2024, 12, 3, 11, 38, 33, 847, DateTimeKind.Local).AddTicks(5852), null, true, false, true, true, null, null, "admin@admin.com", "9991339400", "Admin@123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Academies");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AcademyId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AcademyId",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "AcademyId",
                table: "CourseCategory");

            migrationBuilder.AlterColumn<string>(
                name: "MotherName",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BodyRemark",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3533), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3587), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3662), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3678), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3691), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3709), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3723), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3737), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3750), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3767), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3780), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3793), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3805), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3819), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3831), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3844), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3858), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3874), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3887), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3900), null, null });
        }
    }
}
