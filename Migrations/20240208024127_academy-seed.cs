using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class academyseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Academies",
                columns: new[] { "AcademyId", "AcademyName", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "LastUpdatedAt", "LastUpdatedBy" },
                values: new object[,]
                {
                    { 1, "Impact Academy, Hisar", new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5424), null, true, false, null, null },
                    { 2, "Impact Academy, Chaudhariwas", new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5457), null, true, false, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5197));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5269));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5333));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 8, 11, 26, 641, DateTimeKind.Local).AddTicks(5372));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Academies",
                keyColumn: "AcademyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Academies",
                keyColumn: "AcademyId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8309));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8407));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8488));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 38, 54, 79, DateTimeKind.Local).AddTicks(8505));
        }
    }
}
