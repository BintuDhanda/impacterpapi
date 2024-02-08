using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class academy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    AcademyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8309), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8341), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8351), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8360), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8369), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8380), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8389), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8398), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8407), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8417), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8426), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8435), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8443), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8452), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8461), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8469), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8478), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8488), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8496), true, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8505), true, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Academies");

            migrationBuilder.DropColumn(
                name: "AcademyId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AcademyId",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "AcademyId",
                table: "CourseCategory");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(7992), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8028), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8037), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8044), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8053), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8065), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8111), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8121), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8128), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8138), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8146), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8154), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 13,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8161), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 14,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8169), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 15,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8177), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 16,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8185), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 17,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8192), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 18,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8202), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 19,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8210), null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 20,
                columns: new[] { "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8217), null, null });
        }
    }
}
