using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_AspNetUsers_ApplicationUserId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_ReligionModel_ReligionId",
                table: "ApplicantModel");

            migrationBuilder.AddColumn<int>(
                name: "StudentModelID",
                table: "WorkingExperienceModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentModelID",
                table: "SMSModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentModelID",
                table: "ResultUploadModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentModelID",
                table: "RequirementModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentModelID",
                table: "ProgrammeModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentModelID",
                table: "DocumentUploadModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReligionId",
                table: "ApplicantModel",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "ApplicantModel",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ApplicantModel",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "StudentModelID",
                table: "ApplicantIssueModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentModelID",
                table: "AcademicExperieceModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationNumber = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PreviousName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<string>(type: "text", nullable: true),
                    MaritalStatus = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    AltPhone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PostGPRS = table.Column<string>(type: "text", nullable: false),
                    EmergencyContact = table.Column<string>(type: "text", nullable: false),
                    Hometown = table.Column<string>(type: "text", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: true),
                    HallId = table.Column<int>(type: "integer", nullable: false),
                    NationalIDType = table.Column<string>(type: "text", nullable: false),
                    NationalIDNo = table.Column<string>(type: "text", nullable: false),
                    RegionId = table.Column<int>(type: "integer", nullable: true),
                    NationalityId = table.Column<int>(type: "integer", nullable: false),
                    ResidentialStatus = table.Column<bool>(type: "boolean", nullable: true),
                    GuardianName = table.Column<string>(type: "text", nullable: false),
                    GuardianPhone = table.Column<string>(type: "text", nullable: false),
                    GuardianOccupation = table.Column<string>(type: "text", nullable: false),
                    GuardianRelationship = table.Column<string>(type: "text", nullable: false),
                    Disability = table.Column<bool>(type: "boolean", nullable: true),
                    DisabilityType = table.Column<string>(type: "text", nullable: true),
                    SourceOfFinance = table.Column<string>(type: "text", nullable: true),
                    ReligionId = table.Column<int>(type: "integer", nullable: true),
                    Denomination = table.Column<string>(type: "text", nullable: true),
                    Referrals = table.Column<string>(type: "text", nullable: true),
                    EntryMode = table.Column<string>(type: "text", nullable: false),
                    FirstQualification = table.Column<string>(type: "text", nullable: false),
                    SecondQualification = table.Column<string>(type: "text", nullable: false),
                    ProgrammeStudied = table.Column<string>(type: "text", nullable: false),
                    FormerSchool = table.Column<string>(type: "text", nullable: false),
                    FormerSchoolNewId = table.Column<int>(type: "integer", nullable: true),
                    ProgrammeAdmittedId = table.Column<int>(type: "integer", nullable: true),
                    LastYearInSchool = table.Column<int>(type: "integer", nullable: true),
                    Awaiting = table.Column<bool>(type: "boolean", nullable: true),
                    Grade = table.Column<int>(type: "integer", nullable: true),
                    YearOfAdmission = table.Column<string>(type: "text", nullable: false),
                    PreferedHall = table.Column<string>(type: "text", nullable: true),
                    Results = table.Column<string>(type: "text", nullable: true),
                    ExternalHostel = table.Column<string>(type: "text", nullable: true),
                    Elligible = table.Column<bool>(type: "boolean", nullable: true),
                    Admitted = table.Column<bool>(type: "boolean", nullable: true),
                    AdmittedBy = table.Column<int>(type: "integer", nullable: true),
                    DateAdmitted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AdmissionType = table.Column<string>(type: "text", nullable: true),
                    leveladmitted = table.Column<string>(type: "text", nullable: true),
                    SectionAdmitted = table.Column<string>(type: "text", nullable: true),
                    HallAdmitted = table.Column<int>(type: "integer", nullable: false),
                    RoomNo = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    SMSSent = table.Column<bool>(type: "boolean", nullable: true),
                    LetterPrinted = table.Column<bool>(type: "boolean", nullable: true),
                    FirstChoiceId = table.Column<int>(type: "integer", nullable: true),
                    SecondChoiceId = table.Column<int>(type: "integer", nullable: true),
                    ThirdChoiceId = table.Column<int>(type: "integer", nullable: true),
                    FeePaying = table.Column<bool>(type: "boolean", nullable: true),
                    ReportedInSchool = table.Column<bool>(type: "boolean", nullable: true),
                    FeesPaid = table.Column<decimal>(type: "numeric", nullable: true),
                    HallFeesPaid = table.Column<decimal>(type: "numeric", nullable: true),
                    Reported = table.Column<bool>(type: "boolean", nullable: true),
                    SponsorShip = table.Column<bool>(type: "boolean", nullable: true),
                    SponsorShipCompany = table.Column<string>(type: "text", nullable: true),
                    SponsorShipLocation = table.Column<string>(type: "text", nullable: true),
                    SponsorShipCompanyContact = table.Column<string>(type: "text", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentModel_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentModel_CountryModel_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "CountryModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentModel_DistrictModel_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "DistrictModel",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_StudentModel_FormerSchoolModel_FormerSchoolNewId",
                        column: x => x.FormerSchoolNewId,
                        principalTable: "FormerSchoolModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentModel_HallModel_HallId",
                        column: x => x.HallId,
                        principalTable: "HallModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentModel_RegionModel_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentModel_ReligionModel_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "ReligionModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingExperienceModel_StudentModelID",
                table: "WorkingExperienceModel",
                column: "StudentModelID");

            migrationBuilder.CreateIndex(
                name: "IX_SMSModel_StudentModelID",
                table: "SMSModel",
                column: "StudentModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModel_StudentModelID",
                table: "ResultUploadModel",
                column: "StudentModelID");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementModel_StudentModelID",
                table: "RequirementModel",
                column: "StudentModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeModel_StudentModelID",
                table: "ProgrammeModel",
                column: "StudentModelID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentUploadModel_StudentModelID",
                table: "DocumentUploadModel",
                column: "StudentModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantIssueModel_StudentModelID",
                table: "ApplicantIssueModel",
                column: "StudentModelID");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicExperieceModel_StudentModelID",
                table: "AcademicExperieceModel",
                column: "StudentModelID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_ApplicationUserId",
                table: "StudentModel",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_DistrictId",
                table: "StudentModel",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_FormerSchoolNewId",
                table: "StudentModel",
                column: "FormerSchoolNewId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_HallId",
                table: "StudentModel",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_NationalityId",
                table: "StudentModel",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_RegionId",
                table: "StudentModel",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_ReligionId",
                table: "StudentModel",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicExperieceModel_StudentModel_StudentModelID",
                table: "AcademicExperieceModel",
                column: "StudentModelID",
                principalTable: "StudentModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantIssueModel_StudentModel_StudentModelID",
                table: "ApplicantIssueModel",
                column: "StudentModelID",
                principalTable: "StudentModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_AspNetUsers_ApplicationUserId",
                table: "ApplicantModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_ReligionModel_ReligionId",
                table: "ApplicantModel",
                column: "ReligionId",
                principalTable: "ReligionModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentUploadModel_StudentModel_StudentModelID",
                table: "DocumentUploadModel",
                column: "StudentModelID",
                principalTable: "StudentModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeModel_StudentModel_StudentModelID",
                table: "ProgrammeModel",
                column: "StudentModelID",
                principalTable: "StudentModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementModel_StudentModel_StudentModelID",
                table: "RequirementModel",
                column: "StudentModelID",
                principalTable: "StudentModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultUploadModel_StudentModel_StudentModelID",
                table: "ResultUploadModel",
                column: "StudentModelID",
                principalTable: "StudentModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SMSModel_StudentModel_StudentModelID",
                table: "SMSModel",
                column: "StudentModelID",
                principalTable: "StudentModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperienceModel_StudentModel_StudentModelID",
                table: "WorkingExperienceModel",
                column: "StudentModelID",
                principalTable: "StudentModel",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicExperieceModel_StudentModel_StudentModelID",
                table: "AcademicExperieceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantIssueModel_StudentModel_StudentModelID",
                table: "ApplicantIssueModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_AspNetUsers_ApplicationUserId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_ReligionModel_ReligionId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentUploadModel_StudentModel_StudentModelID",
                table: "DocumentUploadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeModel_StudentModel_StudentModelID",
                table: "ProgrammeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementModel_StudentModel_StudentModelID",
                table: "RequirementModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultUploadModel_StudentModel_StudentModelID",
                table: "ResultUploadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SMSModel_StudentModel_StudentModelID",
                table: "SMSModel");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperienceModel_StudentModel_StudentModelID",
                table: "WorkingExperienceModel");

            migrationBuilder.DropTable(
                name: "StudentModel");

            migrationBuilder.DropIndex(
                name: "IX_WorkingExperienceModel_StudentModelID",
                table: "WorkingExperienceModel");

            migrationBuilder.DropIndex(
                name: "IX_SMSModel_StudentModelID",
                table: "SMSModel");

            migrationBuilder.DropIndex(
                name: "IX_ResultUploadModel_StudentModelID",
                table: "ResultUploadModel");

            migrationBuilder.DropIndex(
                name: "IX_RequirementModel_StudentModelID",
                table: "RequirementModel");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammeModel_StudentModelID",
                table: "ProgrammeModel");

            migrationBuilder.DropIndex(
                name: "IX_DocumentUploadModel_StudentModelID",
                table: "DocumentUploadModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantIssueModel_StudentModelID",
                table: "ApplicantIssueModel");

            migrationBuilder.DropIndex(
                name: "IX_AcademicExperieceModel_StudentModelID",
                table: "AcademicExperieceModel");

            migrationBuilder.DropColumn(
                name: "StudentModelID",
                table: "WorkingExperienceModel");

            migrationBuilder.DropColumn(
                name: "StudentModelID",
                table: "SMSModel");

            migrationBuilder.DropColumn(
                name: "StudentModelID",
                table: "ResultUploadModel");

            migrationBuilder.DropColumn(
                name: "StudentModelID",
                table: "RequirementModel");

            migrationBuilder.DropColumn(
                name: "StudentModelID",
                table: "ProgrammeModel");

            migrationBuilder.DropColumn(
                name: "StudentModelID",
                table: "DocumentUploadModel");

            migrationBuilder.DropColumn(
                name: "StudentModelID",
                table: "ApplicantIssueModel");

            migrationBuilder.DropColumn(
                name: "StudentModelID",
                table: "AcademicExperieceModel");

            migrationBuilder.AlterColumn<int>(
                name: "ReligionId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "ApplicantModel",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ApplicantModel",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_AspNetUsers_ApplicationUserId",
                table: "ApplicantModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_ReligionModel_ReligionId",
                table: "ApplicantModel",
                column: "ReligionId",
                principalTable: "ReligionModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
