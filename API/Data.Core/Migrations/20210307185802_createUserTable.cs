using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Core.Migrations
{
    public partial class createUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Crm = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UserType = table.Column<string>(nullable: false),
                    Titulation = table.Column<string>(maxLength: 50, nullable: true),
                    ResidenceYear = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 7, 15, 58, 1, 859, DateTimeKind.Local).AddTicks(2106), "Resident", null },
                    { 2, new DateTime(2021, 3, 7, 15, 58, 1, 860, DateTimeKind.Local).AddTicks(462), "Doctor", null },
                    { 3, new DateTime(2021, 3, 7, 15, 58, 1, 860, DateTimeKind.Local).AddTicks(579), "Professor", null },
                    { 4, new DateTime(2021, 3, 7, 15, 58, 1, 860, DateTimeKind.Local).AddTicks(583), "Administrator", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Crm", "Name", "Password", "RoleId", "UpdatedAt", "UserType" },
                values: new object[] { new Guid("319e2862-5c31-477a-9eeb-d84db67b2fc5"), new DateTime(2021, 3, 7, 15, 58, 1, 860, DateTimeKind.Local).AddTicks(5031), "999999", "administrador", "6CA13D52CA70C883E0F0BB101E425A89E8624DE51DB2D2392593AF6A84118090", 4, null, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Crm",
                table: "User",
                column: "Crm",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
