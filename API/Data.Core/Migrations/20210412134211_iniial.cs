using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Core.Migrations
{
    public partial class iniial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalEquipament",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    AcquisitionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalEquipament", x => x.Id);
                });

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
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Cpf = table.Column<string>(fixedLength: true, maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    AddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Login = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UserType = table.Column<string>(nullable: false),
                    Crm = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "MedicalConsultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DoctorId = table.Column<Guid>(nullable: false),
                    ConsultationDate = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalConsultation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalConsultation_User_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalConsultation_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExam",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ExamDate = table.Column<DateTime>(nullable: false),
                    ExamStatus = table.Column<int>(nullable: false),
                    ExamResult = table.Column<string>(maxLength: 500, nullable: true),
                    DoctorPerfomedExamId = table.Column<Guid>(nullable: true),
                    MedicalConsultationId = table.Column<Guid>(nullable: false),
                    MedicalEquipamentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalExam_User_DoctorPerfomedExamId",
                        column: x => x.DoctorPerfomedExamId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalExam_MedicalConsultation_MedicalConsultationId",
                        column: x => x.MedicalConsultationId,
                        principalTable: "MedicalConsultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalExam_MedicalEquipament_MedicalEquipamentId",
                        column: x => x.MedicalEquipamentId,
                        principalTable: "MedicalEquipament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    MedicalConsultationId = table.Column<Guid>(nullable: false),
                    Report = table.Column<string>(maxLength: 500, nullable: false),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    ReportCreatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalReport_MedicalConsultation_MedicalConsultationId",
                        column: x => x.MedicalConsultationId,
                        principalTable: "MedicalConsultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalReport_User_ReportCreatorId",
                        column: x => x.ReportCreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 12, 10, 42, 10, 863, DateTimeKind.Local).AddTicks(6379), "Resident", null },
                    { 2, new DateTime(2021, 4, 12, 10, 42, 10, 864, DateTimeKind.Local).AddTicks(8839), "Doctor", null },
                    { 3, new DateTime(2021, 4, 12, 10, 42, 10, 864, DateTimeKind.Local).AddTicks(8917), "Professor", null },
                    { 4, new DateTime(2021, 4, 12, 10, 42, 10, 864, DateTimeKind.Local).AddTicks(8920), "Administrator", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Login", "Name", "Password", "RoleId", "UpdatedAt", "UserType" },
                values: new object[] { new Guid("319e2862-5c31-477a-9eeb-d84db67b2fc5"), new DateTime(2021, 4, 12, 10, 42, 10, 865, DateTimeKind.Local).AddTicks(3123), "999999", "administrador", "6CA13D52CA70C883E0F0BB101E425A89E8624DE51DB2D2392593AF6A84118090", 4, null, "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultation_DoctorId",
                table: "MedicalConsultation",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultation_PatientId",
                table: "MedicalConsultation",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExam_DoctorPerfomedExamId",
                table: "MedicalExam",
                column: "DoctorPerfomedExamId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExam_MedicalConsultationId",
                table: "MedicalExam",
                column: "MedicalConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExam_MedicalEquipamentId",
                table: "MedicalExam",
                column: "MedicalEquipamentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReport_MedicalConsultationId",
                table: "MedicalReport",
                column: "MedicalConsultationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReport_ReportCreatorId",
                table: "MedicalReport",
                column: "ReportCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AddressId",
                table: "Patient",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Login",
                table: "User",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalExam");

            migrationBuilder.DropTable(
                name: "MedicalReport");

            migrationBuilder.DropTable(
                name: "MedicalEquipament");

            migrationBuilder.DropTable(
                name: "MedicalConsultation");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
