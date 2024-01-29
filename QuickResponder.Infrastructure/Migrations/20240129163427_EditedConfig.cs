using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickResponder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditedConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    BloodType = table.Column<int>(type: "INTEGER", nullable: false),
                    Religion = table.Column<string>(type: "TEXT", nullable: false),
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 320, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "Responders",
                columns: table => new
                {
                    ResponderID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 320, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responders", x => x.ResponderID);
                });

            migrationBuilder.CreateTable(
                name: "Allergy",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PatientID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Allergy_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "MedicalCondition",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PatientID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCondition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicalCondition_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "MedicalDevice",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Class = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PatientID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDevice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicalDevice_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MedicationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Dosage = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeBetweenDosages = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prescription_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccine",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    VaccineTakenAt = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PatientID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vaccine_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatientID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ResponderID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Incident_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Responders_ResponderID",
                        column: x => x.ResponderID,
                        principalTable: "Responders",
                        principalColumn: "ResponderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_PatientID",
                table: "Allergy",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_PatientID",
                table: "Incident",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_ResponderID",
                table: "Incident",
                column: "ResponderID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCondition_PatientID",
                table: "MedicalCondition",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDevice_PatientID",
                table: "MedicalDevice",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_MedicationId",
                table: "Prescription",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccine_PatientID",
                table: "Vaccine",
                column: "PatientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "MedicalCondition");

            migrationBuilder.DropTable(
                name: "MedicalDevice");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.DropTable(
                name: "Responders");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
