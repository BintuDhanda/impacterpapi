using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations
{
    /// <inheritdoc />
    public partial class stdetailoptional : Migration
    {
        /// <inheritdoc />
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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8138));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8161));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 20, 4, 45, 0, 917, DateTimeKind.Utc).AddTicks(8217));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3662));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3709));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RolesId",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 6, 12, 30, 500, DateTimeKind.Utc).AddTicks(3900));
        }
    }
}
