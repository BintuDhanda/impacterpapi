using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class rolepermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStatic",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolesId", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "IsStatic", "LastUpdatedAt", "LastUpdatedBy", "RoleName" },
                values: new object[,]
                {
                    { 6, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8600), null, null, null, true, null, null, "UserScreen" },
                    { 7, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8636), null, null, null, true, null, null, "RolesScreen" },
                    { 8, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8648), null, null, null, true, null, null, "StudentDetailsScreen" },
                    { 9, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8657), null, null, null, true, null, null, "QualificationScreen" },
                    { 10, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8666), null, null, null, true, null, null, "CountryScreen" },
                    { 11, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8677), null, null, null, true, null, null, "CourseCategoryScreen" },
                    { 12, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8686), null, null, null, true, null, null, "AddressTypeScreen" },
                    { 13, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8694), null, null, null, true, null, null, "EnterAccountScreen" },
                    { 14, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8702), null, null, null, true, null, null, "StudentBatchFeesScreen" },
                    { 15, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8712), null, null, null, true, null, null, "StudentTokenFeesScreen" },
                    { 16, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8720), null, null, null, true, null, null, "AttendanceScreen" },
                    { 17, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8728), null, null, null, true, null, null, "NewsScreen" },
                    { 18, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8736), null, null, null, true, null, null, "SendNotificationScreen" },
                    { 19, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8776), null, null, null, true, null, null, "IdentityTypeScreen" },
                    { 20, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8788), null, null, null, true, null, null, "SliderScreen" },
                    { 21, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8796), null, null, null, true, null, null, "Hostels" },
                    { 22, new DateTime(2024, 1, 15, 11, 34, 24, 970, DateTimeKind.Utc).AddTicks(8804), null, null, null, true, null, null, "StudentHostelRoomBads" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 22);

            migrationBuilder.DropColumn(
                name: "IsStatic",
                table: "Roles");
        }
    }
}
