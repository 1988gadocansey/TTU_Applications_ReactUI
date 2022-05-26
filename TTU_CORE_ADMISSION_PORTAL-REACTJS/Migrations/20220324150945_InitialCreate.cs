using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FormNo = table.Column<string>(type: "text", nullable: false),
                    Started = table.Column<int>(type: "integer", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Sold = table.Column<int>(type: "integer", nullable: false),
                    SoldBy = table.Column<string>(type: "text", nullable: false),
                    Branch = table.Column<string>(type: "text", nullable: false),
                    Teller = table.Column<string>(type: "text", nullable: false),
                    TellerPhone = table.Column<string>(type: "text", nullable: false),
                    FormCompleted = table.Column<int>(type: "integer", nullable: false),
                    PictureUploaded = table.Column<int>(type: "integer", nullable: false),
                    Finalized = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: false),
                    ResultUploaded = table.Column<bool>(type: "boolean", nullable: false),
                    Admitted = table.Column<bool>(type: "boolean", nullable: false),
                    Pin = table.Column<string>(type: "text", nullable: false),
                    LastLogin = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<string>(type: "text", nullable: false),
                    OrientationStarts = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrientationEnds = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Matriculation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reporting = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FeesDeadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MedicalStarts = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MedicalEnds = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AdmissionsOfficer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DenominationModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenominationModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Faculty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "DistrictModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExamModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CutOffPoint = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormerSchoolModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormerSchoolModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormNoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    No = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormNoModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    Exam = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HallModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankAcc = table.Column<int>(type: "integer", nullable: false),
                    Fees = table.Column<double>(type: "double precision", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Use = table.Column<string>(type: "text", nullable: true),
                    Algorithm = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsX509Certificate = table.Column<bool>(type: "boolean", nullable: false),
                    DataProtected = table.Column<bool>(type: "boolean", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    LevelAdmitted = table.Column<string>(type: "text", nullable: false),
                    Runing = table.Column<bool>(type: "boolean", nullable: false),
                    ShowOnPortal = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Department = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReligionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligionModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SHSProgrammes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHSProgrammes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantModel",
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
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: false),
                    MaritalStatus = table.Column<string>(type: "text", nullable: false),
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
                    DisabilityType = table.Column<string>(type: "text", nullable: false),
                    SourceOfFinance = table.Column<string>(type: "text", nullable: false),
                    ReligionId = table.Column<int>(type: "integer", nullable: false),
                    Denomination = table.Column<string>(type: "text", nullable: true),
                    Referrals = table.Column<string>(type: "text", nullable: false),
                    EntryMode = table.Column<string>(type: "text", nullable: false),
                    FirstQualification = table.Column<string>(type: "text", nullable: false),
                    SecondQualification = table.Column<string>(type: "text", nullable: false),
                    ProgrammeStudied = table.Column<string>(type: "text", nullable: false),
                    FormerSchool = table.Column<string>(type: "text", nullable: false),
                    FormerSchoolNewId = table.Column<int>(type: "integer", nullable: true),
                    ProgrammeAdmittedId = table.Column<int>(type: "integer", nullable: true),
                    LastYearInSchool = table.Column<int>(type: "integer", nullable: false),
                    Awaiting = table.Column<bool>(type: "boolean", nullable: true),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    YearOfAdmission = table.Column<string>(type: "text", nullable: false),
                    PreferedHall = table.Column<string>(type: "text", nullable: false),
                    Results = table.Column<string>(type: "text", nullable: false),
                    ExternalHostel = table.Column<string>(type: "text", nullable: false),
                    Elligible = table.Column<bool>(type: "boolean", nullable: true),
                    Admitted = table.Column<bool>(type: "boolean", nullable: true),
                    AdmittedBy = table.Column<int>(type: "integer", nullable: false),
                    DateAdmitted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AdmissionType = table.Column<string>(type: "text", nullable: false),
                    leveladmitted = table.Column<string>(type: "text", nullable: false),
                    SectionAdmitted = table.Column<string>(type: "text", nullable: false),
                    HallAdmitted = table.Column<int>(type: "integer", nullable: false),
                    RoomNo = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    SMSSent = table.Column<bool>(type: "boolean", nullable: true),
                    LetterPrinted = table.Column<bool>(type: "boolean", nullable: true),
                    FirstChoiceId = table.Column<int>(type: "integer", nullable: false),
                    SecondChoiceId = table.Column<int>(type: "integer", nullable: false),
                    ThirdChoiceId = table.Column<int>(type: "integer", nullable: false),
                    FeePaying = table.Column<bool>(type: "boolean", nullable: true),
                    ReportedInSchool = table.Column<bool>(type: "boolean", nullable: true),
                    FeesPaid = table.Column<decimal>(type: "numeric", nullable: true),
                    HallFeesPaid = table.Column<decimal>(type: "numeric", nullable: true),
                    Reported = table.Column<bool>(type: "boolean", nullable: false),
                    SponsorShip = table.Column<bool>(type: "boolean", nullable: true),
                    SponsorShipCompany = table.Column<string>(type: "text", nullable: false),
                    SponsorShipLocation = table.Column<string>(type: "text", nullable: false),
                    SponsorShipCompanyContact = table.Column<string>(type: "text", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicantModel_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantModel_CountryModel_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "CountryModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantModel_DistrictModel_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "DistrictModel",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApplicantModel_FormerSchoolModel_FormerSchoolNewId",
                        column: x => x.FormerSchoolNewId,
                        principalTable: "FormerSchoolModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantModel_HallModel_HallId",
                        column: x => x.HallId,
                        principalTable: "HallModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantModel_RegionModel_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantModel_ReligionModel_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "ReligionModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicExperieceModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstitutionName = table.Column<string>(type: "text", nullable: false),
                    InstitutionAddress = table.Column<string>(type: "text", nullable: false),
                    ProgrammeStudied = table.Column<string>(type: "text", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Grade = table.Column<string>(type: "text", nullable: false),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicExperieceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicExperieceModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantIssueModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: false),
                    Results = table.Column<bool>(type: "boolean", nullable: false),
                    Picture = table.Column<bool>(type: "boolean", nullable: false),
                    Age = table.Column<bool>(type: "boolean", nullable: false),
                    FormCompletion = table.Column<bool>(type: "boolean", nullable: false),
                    Qualification = table.Column<bool>(type: "boolean", nullable: false),
                    IssuesOne = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantIssueModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantIssueModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantModelProgrammeModel",
                columns: table => new
                {
                    ApplicantID = table.Column<int>(type: "integer", nullable: false),
                    ProgrammesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantModelProgrammeModel", x => new { x.ApplicantID, x.ProgrammesId });
                    table.ForeignKey(
                        name: "FK_ApplicantModelProgrammeModel_ApplicantModel_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantModelProgrammeModel_ProgrammeModel_ProgrammesId",
                        column: x => x.ProgrammesId,
                        principalTable: "ProgrammeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentUploadModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Applicant = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentUploadModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentUploadModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RequirementModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Department = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: false),
                    Aprroved = table.Column<bool>(type: "boolean", nullable: false),
                    RuleOne = table.Column<string>(type: "text", nullable: false),
                    RuleTwo = table.Column<string>(type: "text", nullable: false),
                    RuleThree = table.Column<string>(type: "text", nullable: false),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ResultUploadModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Applicant = table.Column<int>(type: "integer", nullable: false),
                    ExamType = table.Column<string>(type: "text", nullable: false),
                    GradeOld = table.Column<int>(type: "integer", nullable: false),
                    GradeValueOld = table.Column<string>(type: "text", nullable: false),
                    IndexNo = table.Column<string>(type: "text", nullable: false),
                    Sitting = table.Column<string>(type: "text", nullable: false),
                    Month = table.Column<string>(type: "text", nullable: false),
                    Form = table.Column<int>(type: "integer", nullable: false),
                    Center = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: false),
                    OldSubject = table.Column<string>(type: "text", nullable: false),
                    InstitutionName = table.Column<string>(type: "text", nullable: false),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    GradeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultUploadModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultUploadModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultUploadModel_GradeModel_GradeId",
                        column: x => x.GradeId,
                        principalTable: "GradeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultUploadModel_SubjectModel_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMSModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: false),
                    SentBy = table.Column<int>(type: "integer", nullable: false),
                    Recipient = table.Column<int>(type: "integer", nullable: false),
                    DateSent = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SMSModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "WorkingExperienceModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CompanyPhone = table.Column<string>(type: "text", nullable: false),
                    CompanyAddress = table.Column<string>(type: "text", nullable: false),
                    CompanyPosition = table.Column<string>(type: "text", nullable: false),
                    CompanyFrom = table.Column<string>(type: "text", nullable: false),
                    CompanyTo = table.Column<string>(type: "text", nullable: false),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingExperienceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingExperienceModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicExperieceModel_ApplicantModelID",
                table: "AcademicExperieceModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantIssueModel_ApplicantModelID",
                table: "ApplicantIssueModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_ApplicationUserId",
                table: "ApplicantModel",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_DistrictId",
                table: "ApplicantModel",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_FormerSchoolNewId",
                table: "ApplicantModel",
                column: "FormerSchoolNewId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_HallId",
                table: "ApplicantModel",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_NationalityId",
                table: "ApplicantModel",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_RegionId",
                table: "ApplicantModel",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_ReligionId",
                table: "ApplicantModel",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModelProgrammeModel_ProgrammesId",
                table: "ApplicantModelProgrammeModel",
                column: "ProgrammesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentUploadModel_ApplicantModelID",
                table: "DocumentUploadModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                table: "Keys",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_RequirementModel_ApplicantModelID",
                table: "RequirementModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModel_ApplicantModelID",
                table: "ResultUploadModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModel_GradeId",
                table: "ResultUploadModel",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModel_SubjectId",
                table: "ResultUploadModel",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SMSModel_ApplicantModelID",
                table: "SMSModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingExperienceModel_ApplicantModelID",
                table: "WorkingExperienceModel",
                column: "ApplicantModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicExperieceModel");

            migrationBuilder.DropTable(
                name: "ApplicantIssueModel");

            migrationBuilder.DropTable(
                name: "ApplicantModelProgrammeModel");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankModel");

            migrationBuilder.DropTable(
                name: "ConfigurationModel");

            migrationBuilder.DropTable(
                name: "DenominationModel");

            migrationBuilder.DropTable(
                name: "DepartmentModel");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "DocumentUploadModel");

            migrationBuilder.DropTable(
                name: "ExamModel");

            migrationBuilder.DropTable(
                name: "FacultyModel");

            migrationBuilder.DropTable(
                name: "FormNoModel");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "RequirementModel");

            migrationBuilder.DropTable(
                name: "ResultUploadModel");

            migrationBuilder.DropTable(
                name: "SchoolModel");

            migrationBuilder.DropTable(
                name: "SHSProgrammes");

            migrationBuilder.DropTable(
                name: "SMSModel");

            migrationBuilder.DropTable(
                name: "WorkingExperienceModel");

            migrationBuilder.DropTable(
                name: "ProgrammeModel");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GradeModel");

            migrationBuilder.DropTable(
                name: "SubjectModel");

            migrationBuilder.DropTable(
                name: "ApplicantModel");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CountryModel");

            migrationBuilder.DropTable(
                name: "DistrictModel");

            migrationBuilder.DropTable(
                name: "FormerSchoolModel");

            migrationBuilder.DropTable(
                name: "HallModel");

            migrationBuilder.DropTable(
                name: "RegionModel");

            migrationBuilder.DropTable(
                name: "ReligionModel");
        }
    }
}
