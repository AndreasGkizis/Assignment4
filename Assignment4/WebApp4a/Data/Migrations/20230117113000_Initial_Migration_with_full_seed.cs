using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp4a.Migrations
{
    public partial class Initial_Migration_with_full_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassingMark = table.Column<int>(type: "int", nullable: true),
                    MaxMark = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryOfResidence = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Difficulty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NativeLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoIdTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoIdTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxMarks = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoIdIssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    PhotoIdTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_Candidates_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidates_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidates_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidates_PhotoIdTypes_PhotoIdTypeId",
                        column: x => x.PhotoIdTypeId,
                        principalTable: "PhotoIdTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificateTopic",
                columns: table => new
                {
                    CertificatesId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateTopic", x => new { x.CertificatesId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_CertificateTopic_Certificates_CertificatesId",
                        column: x => x.CertificatesId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificateTopic_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_DifficultyLevels_DifficultyLevelId",
                        column: x => x.DifficultyLevelId,
                        principalTable: "DifficultyLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "AppUserId");
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<bool>(type: "bit", nullable: true),
                    MaxScore = table.Column<int>(type: "int", nullable: true),
                    PercentScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CandidateScore = table.Column<int>(type: "int", nullable: true),
                    AssessmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateExams_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    ExamsId = table.Column<int>(type: "int", nullable: false),
                    QuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => new { x.ExamsId, x.QuestionsId });
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Exams_ExamsId",
                        column: x => x.ExamsId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correct = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateExamAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrectOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChosenOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    CandidateExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateExamAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateExamAnswers_CandidateExams_CandidateExamId",
                        column: x => x.CandidateExamId,
                        principalTable: "CandidateExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", 0, "144e0919-b3fc-44c6-9a36-4e437a171e28", "admin2@gmail.com", false, false, null, null, null, null, "1234567890", false, "9463a244-3b2a-4603-9932-68777898625d", false, "Admin2" },
                    { "9407b6e2-f46e-4a79-a725-dfb1e15e2915", 0, "9ac9997b-c048-4c5b-bce2-fef08e7655f9", "admin0@gmail.com", false, false, null, null, null, null, "1234567890", false, "bbe4f88d-5144-454d-aa12-6b96f4582700", false, "Admin0" },
                    { "be69a4bd-fb90-41dd-b65b-4ff8b619b767", 0, "6fab076b-ab92-40c0-bfe6-67ff7f499140", "admin1@gmail.com", false, false, null, null, null, null, "1234567890", false, "d04a9955-3d6b-4c73-b1b1-8c995c18f208", false, "Admin1" },
                    { "f60a904a-aba6-4635-892d-f38919b09896", 0, "99990011-954f-49a6-9a80-a2e8c2a823b3", "admin3@gmail.com", false, false, null, null, null, null, "1234567890", false, "1ae79543-1bae-4f59-b0ce-eebbdcd337c2", false, "Admin3" }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "Active", "Category", "Description", "MaxMark", "PassingMark", "Title" },
                values: new object[,]
                {
                    { 1, true, "payment", "reinvent invoice compressing De-engineered viral invoice Walks Rhode Island Refined Director", null, 0, "Brunei Darussalam Rustic Berkshire" },
                    { 2, false, "neural", "invoice asymmetric District Denar Toys, Games & Movies Curve bandwidth empower Handmade Steel Bike Wooden", null, 0, "invoice open-source Human" },
                    { 3, true, "Frozen", "Berkshire Kyat Taiwan Centralized Division Generic Wooden Ball Accountability Viaduct panel Credit Card Account", null, 0, "Facilitator Home open architecture" },
                    { 4, false, "Awesome Wooden Chair", "synthesizing calculate killer synthesizing initiative Response Lesotho Loti magenta Avon Planner", null, 0, "Personal Loan Account Cayman Islands Central" },
                    { 5, true, "frictionless", "Lead Paradigm copying Home Loan Account Path Practical Metal Chicken killer Interactions Group Avon", null, 0, "optimizing functionalities Assurance" },
                    { 6, false, "Vanuatu", "copying back up optimizing withdrawal user-centric architectures Strategist Granite dot-com synthesizing", null, 0, "Route primary withdrawal" },
                    { 7, false, "Human", "multi-byte hack attitude quantifying Handcrafted Plastic Towels Home Loan Account Generic viral Ergonomic Cotton Gloves Synergized", null, 0, "ivory payment Kids" },
                    { 8, true, "customized", "Barbados Dollar synthesizing quantifying Clothing, Grocery & Games Virgin Islands, U.S. clicks-and-mortar Wooden database CSS hybrid", null, 0, "Iowa Crescent deposit" },
                    { 9, true, "COM", "withdrawal Central Synchronised Pitcairn Islands Fantastic Metal Pizza Fantastic Frozen Towels index Gorgeous Fresh Cheese Central Montana", null, 0, "e-services frame Mountains" },
                    { 10, false, "Union", "Minnesota Tonga productivity Oklahoma multi-byte Money Market Account Gibraltar EXE overriding Handcrafted Fresh Hat", null, 0, "withdrawal holistic Auto Loan Account" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryOfResidence" },
                values: new object[,]
                {
                    { 1, "Yemen" },
                    { 2, "Mexico" },
                    { 3, "United Arab Emirates" },
                    { 4, "Liechtenstein" },
                    { 5, "Bahrain" },
                    { 6, "Costa Rica" },
                    { 7, "Norfolk Island" },
                    { 8, "Monaco" },
                    { 9, "Yemen" },
                    { 10, "Ethiopia" }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "Id", "Difficulty" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderType" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "NativeLanguage" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Greek" },
                    { 3, "Russian" },
                    { 4, "Chinese" }
                });

            migrationBuilder.InsertData(
                table: "PhotoIdTypes",
                columns: new[] { "Id", "IdType" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "MaxMarks", "Name" },
                values: new object[] { 1, 26, "Sports & Music firewall input" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "MaxMarks", "Name" },
                values: new object[,]
                {
                    { 2, 25, "withdrawal synergize Movies & Clothing" },
                    { 3, 29, "Human Philippine Peso Lead" },
                    { 4, 37, "Lead back-end Agent" },
                    { 5, 31, "capacity Parkways real-time" },
                    { 6, 37, "Brunei Darussalam Associate Corporate" },
                    { 7, 31, "Rupiah Island Small Cotton Car" },
                    { 8, 39, "deploy bluetooth connecting" },
                    { 9, 31, "Money Market Account connect Gorgeous" },
                    { 10, 35, "transmit International scale" }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "AppUserId", "CandidateNumber", "DateOfBirth", "Email", "FirstName", "GenderId", "Landline", "LanguageId", "LastName", "MiddleName", "Mobile", "PhotoIdIssueDate", "PhotoIdNumber", "PhotoIdTypeId" },
                values: new object[,]
                {
                    { "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "153060623", new DateTime(1956, 1, 7, 8, 31, 16, 17, DateTimeKind.Local).AddTicks(7272), "Kory27@gmail.com", "Dakota", 4, "(210) 799-5764 x6282", 1, "Wilkinson", "Bridie", "1-783-633-4424", new DateTime(2022, 9, 15, 20, 18, 7, 299, DateTimeKind.Local).AddTicks(9987), "f1lklm", 3 },
                    { "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "420088571", new DateTime(1991, 11, 6, 6, 54, 38, 415, DateTimeKind.Local).AddTicks(2505), "Otho_Pfannerstill31@gmail.com", "Josianne", 2, "645.786.1631 x0930", 2, "Pfeffer", "Yolanda", "351-303-5993 x592", new DateTime(2022, 2, 26, 8, 40, 0, 932, DateTimeKind.Local).AddTicks(8144), "bfqee8", 4 },
                    { "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "136721276", new DateTime(1988, 7, 21, 6, 9, 36, 290, DateTimeKind.Local).AddTicks(1972), "Dedrick_Lynch@hotmail.com", "Adeline", 4, "615.524.9751 x3792", 2, "Dietrich", "Aiyana", "(750) 481-1897", new DateTime(2018, 1, 10, 19, 1, 42, 714, DateTimeKind.Local).AddTicks(8638), "cb4osy", 5 }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CertificateId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DifficultyLevelId", "Text", "TopicId" },
                values: new object[,]
                {
                    { 1, 3, "<h1>this is question</h1>", 1 },
                    { 2, 3, "<h3>this is question</h3>", 3 },
                    { 3, 1, "<h1>this is question</h1>", 8 },
                    { 4, 4, "<h1>this is question</h1>", 5 },
                    { 5, 3, "<h1>this is question</h1>", 1 },
                    { 6, 2, "<h3>this is question</h3>", 2 },
                    { 7, 4, "<h2>this is question</h2>", 2 },
                    { 8, 4, "<h3>this is question</h3>", 2 },
                    { 9, 3, "<h1>this is question</h1>", 5 },
                    { 10, 4, "<h1>this is question</h1>", 6 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address1", "Address2", "CandidateId", "City", "CountryId", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "831 Heller Place", "9688 Stark Place", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "New Demond", 1, "95510-8057", "Vermont" },
                    { 2, "5075 Karl Curve", "19598 Madge Mission", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "Ritchieborough", 2, "48284", "Louisiana" },
                    { 3, "6314 Jenifer Plains", "18120 Leannon Club", "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "East Jeff", 3, "70911", "Vermont" },
                    { 4, "7589 Dejon Heights", "459 Skiles Crossroad", "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "East Cristalview", 4, "14236-9757", "Louisiana" },
                    { 5, "51359 Chet Trail", "34678 Jess Hill", "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "Valentinafurt", 5, "17049-9241", "Oregon" },
                    { 6, "308 Ferry Ridges", "9991 Fay Walk", "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "Port Nelson", 6, "36477", "Alaska" },
                    { 7, "708 Zieme Village", "8821 Toby Land", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "Heathville", 7, "47627", "Tennessee" },
                    { 8, "9589 Bryana Stream", "1449 Laney Underpass", "be69a4bd-fb90-41dd-b65b-4ff8b619b767", "South Ursula", 8, "10949-0483", "Hawaii" },
                    { 9, "44989 Hodkiewicz Brook", "37608 Harber Stream", "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", "Lake Nina", 9, "30846", "Virginia" },
                    { 10, "5974 Chandler Parkway", "3757 Margie Brook", "9407b6e2-f46e-4a79-a725-dfb1e15e2915", "East Delaneybury", 10, "08208-7354", "Mississippi" }
                });

            migrationBuilder.InsertData(
                table: "CandidateExams",
                columns: new[] { "Id", "AssessmentCode", "CandidateId", "CandidateScore", "ExamDate", "ExamId", "MaxScore", "PercentScore", "ReportDate", "Result" },
                values: new object[,]
                {
                    { 1, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2021, 1, 25, 12, 42, 38, 707, DateTimeKind.Local).AddTicks(8065), 2, null, null, new DateTime(2023, 1, 8, 4, 31, 49, 126, DateTimeKind.Unspecified).AddTicks(9922), null },
                    { 2, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2022, 2, 5, 2, 18, 54, 93, DateTimeKind.Local).AddTicks(6021), 2, null, null, new DateTime(2022, 9, 22, 18, 32, 24, 718, DateTimeKind.Unspecified).AddTicks(4307), null },
                    { 3, null, "be69a4bd-fb90-41dd-b65b-4ff8b619b767", null, new DateTime(2023, 1, 6, 13, 19, 51, 135, DateTimeKind.Local).AddTicks(6121), 1, null, null, new DateTime(2022, 8, 20, 8, 51, 47, 299, DateTimeKind.Unspecified).AddTicks(4650), null },
                    { 4, null, "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", null, new DateTime(2021, 4, 15, 2, 4, 40, 110, DateTimeKind.Local).AddTicks(7910), 2, null, null, new DateTime(2022, 9, 7, 19, 43, 30, 269, DateTimeKind.Unspecified).AddTicks(6838), null },
                    { 5, null, "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", null, new DateTime(2021, 12, 31, 15, 2, 11, 209, DateTimeKind.Local).AddTicks(2150), 7, null, null, new DateTime(2022, 9, 2, 23, 7, 55, 831, DateTimeKind.Unspecified).AddTicks(5880), null },
                    { 6, null, "9407b6e2-f46e-4a79-a725-dfb1e15e2915", null, new DateTime(2022, 11, 9, 22, 17, 11, 713, DateTimeKind.Local).AddTicks(7661), 1, null, null, new DateTime(2022, 8, 5, 2, 59, 37, 888, DateTimeKind.Unspecified).AddTicks(5686), null },
                    { 7, null, "9407b6e2-f46e-4a79-a725-dfb1e15e2915", null, new DateTime(2021, 12, 20, 18, 52, 2, 381, DateTimeKind.Local).AddTicks(5348), 5, null, null, new DateTime(2022, 12, 19, 7, 44, 53, 285, DateTimeKind.Unspecified).AddTicks(9640), null },
                    { 8, null, "8ca319b2-762d-45e3-8b26-edd6b1f4ba75", null, new DateTime(2022, 1, 18, 1, 0, 26, 392, DateTimeKind.Local).AddTicks(1707), 3, null, null, new DateTime(2022, 8, 20, 9, 2, 50, 913, DateTimeKind.Unspecified).AddTicks(6451), null },
                    { 9, null, "9407b6e2-f46e-4a79-a725-dfb1e15e2915", null, new DateTime(2022, 12, 5, 18, 28, 38, 99, DateTimeKind.Local).AddTicks(724), 1, null, null, new DateTime(2022, 7, 10, 7, 1, 28, 938, DateTimeKind.Unspecified).AddTicks(3649), null },
                    { 10, null, "9407b6e2-f46e-4a79-a725-dfb1e15e2915", null, new DateTime(2021, 4, 21, 8, 33, 12, 947, DateTimeKind.Local).AddTicks(675), 6, null, null, new DateTime(2022, 12, 31, 19, 38, 24, 321, DateTimeKind.Unspecified).AddTicks(676), null }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Correct", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, true, 1, "<h2>this is an option2</h2>" },
                    { 2, false, 1, "<h1>this is an option1</h1>" },
                    { 3, false, 1, "<h2>this is an option2</h2>" },
                    { 4, false, 1, "<h1>this is an option4</h1>" },
                    { 5, true, 2, "<h1>this is an option4</h1>" },
                    { 6, false, 2, "<h2>this is an option2</h2>" },
                    { 7, false, 2, "<h1>this is an option4</h1>" },
                    { 8, false, 2, "<h1>this is an option1</h1>" },
                    { 9, true, 3, "<h3>this is an option3</h3>" },
                    { 10, false, 3, "<h1>this is an option4</h1>" },
                    { 11, false, 3, "<h3>this is an option3</h3>" },
                    { 12, false, 3, "<h1>this is an option4</h1>" },
                    { 13, true, 4, "<h2>this is an option2</h2>" },
                    { 14, false, 4, "<h1>this is an option4</h1>" },
                    { 15, false, 4, "<h1>this is an option1</h1>" },
                    { 16, false, 4, "<h1>this is an option4</h1>" },
                    { 17, true, 5, "<h3>this is an option3</h3>" },
                    { 18, false, 5, "<h2>this is an option2</h2>" },
                    { 19, false, 5, "<h3>this is an option3</h3>" },
                    { 20, false, 5, "<h2>this is an option2</h2>" },
                    { 21, true, 6, "<h1>this is an option4</h1>" },
                    { 22, false, 6, "<h1>this is an option4</h1>" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Correct", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 23, false, 6, "<h2>this is an option2</h2>" },
                    { 24, false, 6, "<h3>this is an option3</h3>" },
                    { 25, true, 7, "<h2>this is an option2</h2>" },
                    { 26, false, 7, "<h1>this is an option4</h1>" },
                    { 27, false, 7, "<h1>this is an option4</h1>" },
                    { 28, false, 7, "<h1>this is an option1</h1>" },
                    { 29, true, 8, "<h1>this is an option4</h1>" },
                    { 30, false, 8, "<h1>this is an option4</h1>" },
                    { 31, false, 8, "<h1>this is an option4</h1>" },
                    { 32, false, 8, "<h2>this is an option2</h2>" },
                    { 33, true, 9, "<h1>this is an option1</h1>" },
                    { 34, false, 9, "<h1>this is an option4</h1>" },
                    { 35, false, 9, "<h3>this is an option3</h3>" },
                    { 36, false, 9, "<h2>this is an option2</h2>" },
                    { 37, true, 10, "<h1>this is an option4</h1>" },
                    { 38, false, 10, "<h1>this is an option4</h1>" },
                    { 39, false, 10, "<h2>this is an option2</h2>" },
                    { 40, false, 10, "<h3>this is an option3</h3>" }
                });

            migrationBuilder.InsertData(
                table: "CandidateExamAnswers",
                columns: new[] { "Id", "CandidateExamId", "ChosenOption", "CorrectOption", "IsCorrect" },
                values: new object[,]
                {
                    { 1, 2, "<h2>this is an option2</h2>", "<h1>this is an option4</h1>", false },
                    { 2, 1, "<h1>this is an option4</h1>", "<h2>this is an option2</h2>", false },
                    { 3, 5, "<h1>this is an option4</h1>", "<h2>this is an option2</h2>", false },
                    { 4, 6, "<h1>this is an option4</h1>", "<h2>this is an option2</h2>", false },
                    { 5, 4, "<h1>this is an option4</h1>", "<h1>this is an option4</h1>", false },
                    { 6, 1, "<h1>this is an option4</h1>", "<h1>this is an option1</h1>", false },
                    { 7, 7, "<h3>this is an option3</h3>", "<h2>this is an option2</h2>", false },
                    { 8, 4, "<h1>this is an option4</h1>", "<h1>this is an option4</h1>", false },
                    { 9, 6, "<h1>this is an option4</h1>", "<h1>this is an option4</h1>", false },
                    { 10, 7, "<h2>this is an option2</h2>", "<h1>this is an option4</h1>", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CandidateId",
                table: "Addresses",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExamAnswers_CandidateExamId",
                table: "CandidateExamAnswers",
                column: "CandidateExamId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_CandidateId",
                table: "CandidateExams",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExams_ExamId",
                table: "CandidateExams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_GenderId",
                table: "Candidates",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_LanguageId",
                table: "Candidates",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_PhotoIdTypeId",
                table: "Candidates",
                column: "PhotoIdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateTopic_TopicsId",
                table: "CertificateTopic",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_QuestionsId",
                table: "ExamQuestion",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CertificateId",
                table: "Exams",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DifficultyLevelId",
                table: "Questions",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicId",
                table: "Questions",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

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
                name: "CandidateExamAnswers");

            migrationBuilder.DropTable(
                name: "CertificateTopic");

            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CandidateExams");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "DifficultyLevels");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PhotoIdTypes");

            migrationBuilder.DropTable(
                name: "Certificates");
        }
    }
}
