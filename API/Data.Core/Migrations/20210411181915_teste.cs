using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Core.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReportCreatorId",
                table: "MedicalReport",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportDate",
                table: "MedicalReport",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("319e2862-5c31-477a-9eeb-d84db67b2fc5"),
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 15, 19, 15, 129, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 15, 19, 15, 124, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 15, 19, 15, 128, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 15, 19, 15, 128, DateTimeKind.Local).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 11, 15, 19, 15, 128, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReport_ReportCreatorId",
                table: "MedicalReport",
                column: "ReportCreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReport_User_ReportCreatorId",
                table: "MedicalReport",
                column: "ReportCreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReport_User_ReportCreatorId",
                table: "MedicalReport");

            migrationBuilder.DropIndex(
                name: "IX_MedicalReport_ReportCreatorId",
                table: "MedicalReport");

            migrationBuilder.DropColumn(
                name: "ReportCreatorId",
                table: "MedicalReport");

            migrationBuilder.DropColumn(
                name: "ReportDate",
                table: "MedicalReport");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("319e2862-5c31-477a-9eeb-d84db67b2fc5"),
                column: "CreatedAt",
                value: new DateTime(2021, 4, 10, 18, 35, 11, 717, DateTimeKind.Local).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 10, 18, 35, 11, 715, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 10, 18, 35, 11, 717, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 10, 18, 35, 11, 717, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 10, 18, 35, 11, 717, DateTimeKind.Local).AddTicks(2225));
        }
    }
}
