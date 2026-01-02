using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillIT_Models.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "achievement",
                columns: table => new
                {
                    achievementID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievement", x => x.achievementID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "catalog",
                columns: table => new
                {
                    catalogID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image_url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image_thumbnail_url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descriptions = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    link = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalog", x => x.catalogID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "certificate",
                columns: table => new
                {
                    certificateID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<int>(type: "int", nullable: false),
                    date_issued = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    date_expired = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificate", x => x.certificateID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    countryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    iso2 = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phoneCode = table.Column<int>(type: "int", nullable: false),
                    currency_symbol = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    capital = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    region = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    subregion = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    iso3 = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.countryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "email",
                columns: table => new
                {
                    emailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_primary = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    can_mail_to = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    is_verified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email", x => x.emailId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    roleID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.roleID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sentmails",
                columns: table => new
                {
                    mailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    email_body = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_sent = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    email_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sentmails", x => x.mailId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "skill",
                columns: table => new
                {
                    skillID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.skillID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "social",
                columns: table => new
                {
                    socialID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    link = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social", x => x.socialID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dob = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gender = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    profile_image = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    languageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    countryId = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language", x => x.languageId);
                    table.ForeignKey(
                        name: "FK_language_country_countryId",
                        column: x => x.countryId,
                        principalTable: "country",
                        principalColumn: "countryId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "phone",
                columns: table => new
                {
                    phoneId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    countryId = table.Column<long>(type: "bigint", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    is_primary = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    can_notify = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_verified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone", x => x.phoneId);
                    table.ForeignKey(
                        name: "FK_phone_country_countryId",
                        column: x => x.countryId,
                        principalTable: "country",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    accountID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userID = table.Column<long>(type: "bigint", nullable: false),
                    roleID = table.Column<long>(type: "bigint", nullable: false),
                    accountType = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    last_login = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    last_logout = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    login_info = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    login_attemp = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.accountID);
                    table.ForeignKey(
                        name: "FK_account_role_roleID",
                        column: x => x.roleID,
                        principalTable: "role",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_account_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "engagement",
                columns: table => new
                {
                    engagementID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userID = table.Column<long>(type: "bigint", nullable: false),
                    catalogID = table.Column<long>(type: "bigint", nullable: false),
                    engagedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    completed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engagement", x => x.engagementID);
                    table.ForeignKey(
                        name: "FK_engagement_catalog_catalogID",
                        column: x => x.catalogID,
                        principalTable: "catalog",
                        principalColumn: "catalogID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_engagement_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    feedbackId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    subject = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    included_images = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    read_by = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_read = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tag_ids = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    topic_ids = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    subject_ids = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category_ids = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    response = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback", x => x.feedbackId);
                    table.ForeignKey(
                        name: "FK_feedback_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "otp",
                columns: table => new
                {
                    otpID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<int>(type: "int", nullable: false),
                    expiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    guid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_otp", x => x.otpID);
                    table.ForeignKey(
                        name: "FK_otp_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    projectID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    owner = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    soureLink = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    link = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    skillSet = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.projectID);
                    table.ForeignKey(
                        name: "FK_project_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "testimonial",
                columns: table => new
                {
                    testimonialId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    is_approved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testimonial", x => x.testimonialId);
                    table.ForeignKey(
                        name: "FK_testimonial_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_email",
                columns: table => new
                {
                    user_emailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    emailId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_email", x => x.user_emailId);
                    table.ForeignKey(
                        name: "FK_user_email_email_emailId",
                        column: x => x.emailId,
                        principalTable: "email",
                        principalColumn: "emailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_email_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_skill",
                columns: table => new
                {
                    user_skillID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    skillID = table.Column<long>(type: "bigint", nullable: false),
                    userID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_skill", x => x.user_skillID);
                    table.ForeignKey(
                        name: "FK_user_skill_skill_skillID",
                        column: x => x.skillID,
                        principalTable: "skill",
                        principalColumn: "skillID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_skill_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_social",
                columns: table => new
                {
                    user_socialID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    socialID = table.Column<long>(type: "bigint", nullable: false),
                    userID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_social", x => x.user_socialID);
                    table.ForeignKey(
                        name: "FK_user_social_social_socialID",
                        column: x => x.socialID,
                        principalTable: "social",
                        principalColumn: "socialID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_social_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_phone",
                columns: table => new
                {
                    user_phoneId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    phoneId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_phone", x => x.user_phoneId);
                    table.ForeignKey(
                        name: "FK_user_phone_phone_phoneId",
                        column: x => x.phoneId,
                        principalTable: "phone",
                        principalColumn: "phoneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_phone_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "creator",
                columns: table => new
                {
                    authorID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    accountID = table.Column<long>(type: "bigint", nullable: false),
                    roleID = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creator", x => x.authorID);
                    table.ForeignKey(
                        name: "FK_creator_account_accountID",
                        column: x => x.accountID,
                        principalTable: "account",
                        principalColumn: "accountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_creator_role_roleID",
                        column: x => x.roleID,
                        principalTable: "role",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    notificationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    notification_guid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    accountId = table.Column<long>(type: "bigint", nullable: false),
                    caption = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    details = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    actions = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    icon = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    marked_as_read = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    date_read = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.notificationId);
                    table.ForeignKey(
                        name: "FK_notification_account_accountId",
                        column: x => x.accountId,
                        principalTable: "account",
                        principalColumn: "accountID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    courseID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    guid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    date_publish = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    is_published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_open = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    authorID = table.Column<long>(type: "bigint", nullable: true),
                    level = table.Column<int>(type: "int", nullable: false),
                    cover_image = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.courseID);
                    table.ForeignKey(
                        name: "FK_course_creator_authorID",
                        column: x => x.authorID,
                        principalTable: "creator",
                        principalColumn: "authorID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    questionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    authorID = table.Column<long>(type: "bigint", nullable: true),
                    text = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.questionID);
                    table.ForeignKey(
                        name: "FK_question_creator_authorID",
                        column: x => x.authorID,
                        principalTable: "creator",
                        principalColumn: "authorID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "quiz",
                columns: table => new
                {
                    quizID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    authorID = table.Column<long>(type: "bigint", nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    quiz_code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quiz", x => x.quizID);
                    table.ForeignKey(
                        name: "FK_quiz_creator_authorID",
                        column: x => x.authorID,
                        principalTable: "creator",
                        principalColumn: "authorID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "course_chapter",
                columns: table => new
                {
                    chapterID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    courseID = table.Column<long>(type: "bigint", nullable: false),
                    guid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    authorID = table.Column<long>(type: "bigint", nullable: true),
                    chapter_number = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_chapter", x => x.chapterID);
                    table.ForeignKey(
                        name: "FK_course_chapter_course_courseID",
                        column: x => x.courseID,
                        principalTable: "course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_chapter_creator_authorID",
                        column: x => x.authorID,
                        principalTable: "creator",
                        principalColumn: "authorID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "course_enrollments_analytics",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    enrollment_id = table.Column<long>(type: "bigint", nullable: false),
                    course_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    enrolled_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    completed_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    is_completed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    completion_percentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    total_time_spent_minutes = table.Column<int>(type: "int", nullable: false),
                    last_accessed_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_enrollments_analytics", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_enrollments_analytics_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_enrollments_analytics_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "course_views",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    course_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    viewed_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ip_address = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_agent = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    referrer_url = table.Column<string>(type: "varchar(2083)", maxLength: 2083, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    session_duration_seconds = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_views", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_views_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_views_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "data_index",
                columns: table => new
                {
                    indexId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    courseId = table.Column<long>(type: "bigint", nullable: false),
                    index_data = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_data_index", x => x.indexId);
                    table.ForeignKey(
                        name: "FK_data_index_course_courseId",
                        column: x => x.courseId,
                        principalTable: "course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "enrollment",
                columns: table => new
                {
                    enrollmentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userID = table.Column<long>(type: "bigint", nullable: false),
                    courseID = table.Column<long>(type: "bigint", nullable: false),
                    date_enrolled = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    is_completed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    date_completed = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    completion_percentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    last_accessed = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    enrolled_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollment", x => x.enrollmentID);
                    table.ForeignKey(
                        name: "FK_enrollment_course_courseID",
                        column: x => x.courseID,
                        principalTable: "course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enrollment_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_certificate",
                columns: table => new
                {
                    user_certificateID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    certificateID = table.Column<long>(type: "bigint", nullable: false),
                    userID = table.Column<long>(type: "bigint", nullable: false),
                    courseID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_certificate", x => x.user_certificateID);
                    table.ForeignKey(
                        name: "FK_user_certificate_certificate_certificateID",
                        column: x => x.certificateID,
                        principalTable: "certificate",
                        principalColumn: "certificateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_certificate_course_courseID",
                        column: x => x.courseID,
                        principalTable: "course",
                        principalColumn: "courseID");
                    table.ForeignKey(
                        name: "FK_user_certificate_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "question_answer",
                columns: table => new
                {
                    question_answerID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    questionID = table.Column<long>(type: "bigint", nullable: false),
                    answer = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_correct = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_answer", x => x.question_answerID);
                    table.ForeignKey(
                        name: "FK_question_answer_question_questionID",
                        column: x => x.questionID,
                        principalTable: "question",
                        principalColumn: "questionID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "quiz_question",
                columns: table => new
                {
                    quiz_questionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    quizID = table.Column<long>(type: "bigint", nullable: false),
                    questionID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quiz_question", x => x.quiz_questionID);
                    table.ForeignKey(
                        name: "FK_quiz_question_question_questionID",
                        column: x => x.questionID,
                        principalTable: "question",
                        principalColumn: "questionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quiz_question_quiz_quizID",
                        column: x => x.quizID,
                        principalTable: "quiz",
                        principalColumn: "quizID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chapter_quiz",
                columns: table => new
                {
                    chapter_quizID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    quizID = table.Column<long>(type: "bigint", nullable: false),
                    chapterID = table.Column<long>(type: "bigint", nullable: false),
                    authorID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapter_quiz", x => x.chapter_quizID);
                    table.ForeignKey(
                        name: "FK_chapter_quiz_course_chapter_chapterID",
                        column: x => x.chapterID,
                        principalTable: "course_chapter",
                        principalColumn: "chapterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chapter_quiz_creator_authorID",
                        column: x => x.authorID,
                        principalTable: "creator",
                        principalColumn: "authorID");
                    table.ForeignKey(
                        name: "FK_chapter_quiz_quiz_quizID",
                        column: x => x.quizID,
                        principalTable: "quiz",
                        principalColumn: "quizID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "course_lesson",
                columns: table => new
                {
                    lessonID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    topic = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    chapterID = table.Column<long>(type: "bigint", nullable: false),
                    guid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    authorID = table.Column<long>(type: "bigint", nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    lesson_number = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_lesson", x => x.lessonID);
                    table.ForeignKey(
                        name: "FK_course_lesson_course_chapter_chapterID",
                        column: x => x.chapterID,
                        principalTable: "course_chapter",
                        principalColumn: "chapterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_lesson_creator_authorID",
                        column: x => x.authorID,
                        principalTable: "creator",
                        principalColumn: "authorID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "course_data",
                columns: table => new
                {
                    dataID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    enrollmentID = table.Column<long>(type: "bigint", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    study_record = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_data", x => x.dataID);
                    table.ForeignKey(
                        name: "FK_course_data_enrollment_enrollmentID",
                        column: x => x.enrollmentID,
                        principalTable: "enrollment",
                        principalColumn: "enrollmentID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "enrollment_quiz",
                columns: table => new
                {
                    enrollment_quizID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    enrollmentID = table.Column<long>(type: "bigint", nullable: false),
                    quizID = table.Column<long>(type: "bigint", nullable: false),
                    date_taken = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    passed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    time_taken = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollment_quiz", x => x.enrollment_quizID);
                    table.ForeignKey(
                        name: "FK_enrollment_quiz_enrollment_enrollmentID",
                        column: x => x.enrollmentID,
                        principalTable: "enrollment",
                        principalColumn: "enrollmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enrollment_quiz_quiz_quizID",
                        column: x => x.quizID,
                        principalTable: "quiz",
                        principalColumn: "quizID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_achievement",
                columns: table => new
                {
                    user_achievementID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    achievementID = table.Column<long>(type: "bigint", nullable: false),
                    userID = table.Column<long>(type: "bigint", nullable: false),
                    enrollmentID = table.Column<long>(type: "bigint", nullable: true),
                    catalogID = table.Column<long>(type: "bigint", nullable: true),
                    user_skillID = table.Column<long>(type: "bigint", nullable: true),
                    languageID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_achievement", x => x.user_achievementID);
                    table.ForeignKey(
                        name: "FK_user_achievement_achievement_achievementID",
                        column: x => x.achievementID,
                        principalTable: "achievement",
                        principalColumn: "achievementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_achievement_catalog_catalogID",
                        column: x => x.catalogID,
                        principalTable: "catalog",
                        principalColumn: "catalogID");
                    table.ForeignKey(
                        name: "FK_user_achievement_enrollment_enrollmentID",
                        column: x => x.enrollmentID,
                        principalTable: "enrollment",
                        principalColumn: "enrollmentID");
                    table.ForeignKey(
                        name: "FK_user_achievement_user_skill_user_skillID",
                        column: x => x.user_skillID,
                        principalTable: "user_skill",
                        principalColumn: "user_skillID");
                    table.ForeignKey(
                        name: "FK_user_achievement_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "question_answer_response",
                columns: table => new
                {
                    question_answer_responseID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    questionID = table.Column<long>(type: "bigint", nullable: false),
                    enrollmentID = table.Column<long>(type: "bigint", nullable: false),
                    question_answerID = table.Column<long>(type: "bigint", nullable: false),
                    time_answered = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_answer_response", x => x.question_answer_responseID);
                    table.ForeignKey(
                        name: "FK_question_answer_response_enrollment_enrollmentID",
                        column: x => x.enrollmentID,
                        principalTable: "enrollment",
                        principalColumn: "enrollmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_question_answer_response_question_answer_question_answerID",
                        column: x => x.question_answerID,
                        principalTable: "question_answer",
                        principalColumn: "question_answerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_question_answer_response_question_questionID",
                        column: x => x.questionID,
                        principalTable: "question",
                        principalColumn: "questionID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "course_content",
                columns: table => new
                {
                    contentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    lessonID = table.Column<long>(type: "bigint", nullable: false),
                    guid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    authorID = table.Column<long>(type: "bigint", nullable: true),
                    content_number = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    video_link = table.Column<string>(type: "varchar(2083)", maxLength: 2083, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    note = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_content", x => x.contentID);
                    table.ForeignKey(
                        name: "FK_course_content_course_lesson_lessonID",
                        column: x => x.lessonID,
                        principalTable: "course_lesson",
                        principalColumn: "lessonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_content_creator_authorID",
                        column: x => x.authorID,
                        principalTable: "creator",
                        principalColumn: "authorID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_account_roleID",
                table: "account",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_account_userID",
                table: "account",
                column: "userID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chapter_quiz_authorID",
                table: "chapter_quiz",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "IX_chapter_quiz_chapterID",
                table: "chapter_quiz",
                column: "chapterID");

            migrationBuilder.CreateIndex(
                name: "IX_chapter_quiz_quizID",
                table: "chapter_quiz",
                column: "quizID");

            migrationBuilder.CreateIndex(
                name: "idx_course_author",
                table: "course",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "idx_course_deleted",
                table: "course",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "idx_course_guid_unique",
                table: "course",
                column: "guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_course_published_level",
                table: "course",
                columns: new[] { "is_published", "level", "date_publish" });

            migrationBuilder.CreateIndex(
                name: "idx_chapter_course_number",
                table: "course_chapter",
                columns: new[] { "courseID", "chapter_number" });

            migrationBuilder.CreateIndex(
                name: "IX_course_chapter_authorID",
                table: "course_chapter",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "idx_content_lesson_number",
                table: "course_content",
                columns: new[] { "lessonID", "content_number" });

            migrationBuilder.CreateIndex(
                name: "IX_course_content_authorID",
                table: "course_content",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "IX_course_data_enrollmentID",
                table: "course_data",
                column: "enrollmentID");

            migrationBuilder.CreateIndex(
                name: "idx_courseenrollment_course_date",
                table: "course_enrollments_analytics",
                columns: new[] { "course_id", "enrolled_at" });

            migrationBuilder.CreateIndex(
                name: "idx_courseenrollment_user_completed",
                table: "course_enrollments_analytics",
                columns: new[] { "user_id", "is_completed" });

            migrationBuilder.CreateIndex(
                name: "idx_lesson_chapter_number",
                table: "course_lesson",
                columns: new[] { "chapterID", "lesson_number" });

            migrationBuilder.CreateIndex(
                name: "IX_course_lesson_authorID",
                table: "course_lesson",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "idx_courseview_course_date",
                table: "course_views",
                columns: new[] { "course_id", "viewed_at" });

            migrationBuilder.CreateIndex(
                name: "idx_courseview_user_date",
                table: "course_views",
                columns: new[] { "user_id", "viewed_at" });

            migrationBuilder.CreateIndex(
                name: "IX_creator_accountID",
                table: "creator",
                column: "accountID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_creator_roleID",
                table: "creator",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_data_index_courseId",
                table: "data_index",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "idx_email_address_unique",
                table: "email",
                column: "address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_engagement_user_catalog",
                table: "engagement",
                columns: new[] { "userID", "catalogID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_engagement_user_completed",
                table: "engagement",
                columns: new[] { "userID", "completed", "engagedDate" });

            migrationBuilder.CreateIndex(
                name: "IX_engagement_catalogID",
                table: "engagement",
                column: "catalogID");

            migrationBuilder.CreateIndex(
                name: "idx_enrollment_deleted",
                table: "enrollment",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "idx_enrollment_user_completed",
                table: "enrollment",
                columns: new[] { "userID", "is_completed", "date_enrolled" });

            migrationBuilder.CreateIndex(
                name: "idx_enrollment_user_course",
                table: "enrollment",
                columns: new[] { "userID", "courseID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_courseID",
                table: "enrollment",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_quiz_enrollmentID",
                table: "enrollment_quiz",
                column: "enrollmentID");

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_quiz_quizID",
                table: "enrollment_quiz",
                column: "quizID");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_userId",
                table: "feedback",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_language_countryId",
                table: "language",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "idx_notification_account_read_date",
                table: "notification",
                columns: new[] { "accountId", "marked_as_read", "date_created" });

            migrationBuilder.CreateIndex(
                name: "idx_otp_code_user",
                table: "otp",
                columns: new[] { "code", "userId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_otp_guid",
                table: "otp",
                column: "guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_otp_user_code_expiry",
                table: "otp",
                columns: new[] { "userId", "code", "expiryDate" });

            migrationBuilder.CreateIndex(
                name: "IX_phone_countryId",
                table: "phone",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_project_userID",
                table: "project",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_question_authorID",
                table: "question",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "IX_question_answer_questionID",
                table: "question_answer",
                column: "questionID");

            migrationBuilder.CreateIndex(
                name: "IX_question_answer_response_enrollmentID",
                table: "question_answer_response",
                column: "enrollmentID");

            migrationBuilder.CreateIndex(
                name: "IX_question_answer_response_question_answerID",
                table: "question_answer_response",
                column: "question_answerID");

            migrationBuilder.CreateIndex(
                name: "IX_question_answer_response_questionID",
                table: "question_answer_response",
                column: "questionID");

            migrationBuilder.CreateIndex(
                name: "IX_quiz_authorID",
                table: "quiz",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "IX_quiz_question_questionID",
                table: "quiz_question",
                column: "questionID");

            migrationBuilder.CreateIndex(
                name: "IX_quiz_question_quizID",
                table: "quiz_question",
                column: "quizID");

            migrationBuilder.CreateIndex(
                name: "idx_testimonial_user_unique",
                table: "testimonial",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_user_deleted",
                table: "user",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "idx_user_email_unique",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_user_username_unique",
                table: "user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_achievement_achievementID",
                table: "user_achievement",
                column: "achievementID");

            migrationBuilder.CreateIndex(
                name: "IX_user_achievement_catalogID",
                table: "user_achievement",
                column: "catalogID");

            migrationBuilder.CreateIndex(
                name: "IX_user_achievement_enrollmentID",
                table: "user_achievement",
                column: "enrollmentID");

            migrationBuilder.CreateIndex(
                name: "IX_user_achievement_user_skillID",
                table: "user_achievement",
                column: "user_skillID");

            migrationBuilder.CreateIndex(
                name: "IX_user_achievement_userID",
                table: "user_achievement",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_user_certificate_certificateID",
                table: "user_certificate",
                column: "certificateID");

            migrationBuilder.CreateIndex(
                name: "IX_user_certificate_courseID",
                table: "user_certificate",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_user_certificate_userID",
                table: "user_certificate",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_user_email_emailId",
                table: "user_email",
                column: "emailId");

            migrationBuilder.CreateIndex(
                name: "IX_user_email_userId",
                table: "user_email",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_user_phone_phoneId",
                table: "user_phone",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_user_phone_userId",
                table: "user_phone",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_user_skill_skillID",
                table: "user_skill",
                column: "skillID");

            migrationBuilder.CreateIndex(
                name: "IX_user_skill_userID",
                table: "user_skill",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_user_social_socialID",
                table: "user_social",
                column: "socialID");

            migrationBuilder.CreateIndex(
                name: "IX_user_social_userID",
                table: "user_social",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chapter_quiz");

            migrationBuilder.DropTable(
                name: "course_content");

            migrationBuilder.DropTable(
                name: "course_data");

            migrationBuilder.DropTable(
                name: "course_enrollments_analytics");

            migrationBuilder.DropTable(
                name: "course_views");

            migrationBuilder.DropTable(
                name: "data_index");

            migrationBuilder.DropTable(
                name: "engagement");

            migrationBuilder.DropTable(
                name: "enrollment_quiz");

            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "otp");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "question_answer_response");

            migrationBuilder.DropTable(
                name: "quiz_question");

            migrationBuilder.DropTable(
                name: "sentmails");

            migrationBuilder.DropTable(
                name: "testimonial");

            migrationBuilder.DropTable(
                name: "user_achievement");

            migrationBuilder.DropTable(
                name: "user_certificate");

            migrationBuilder.DropTable(
                name: "user_email");

            migrationBuilder.DropTable(
                name: "user_phone");

            migrationBuilder.DropTable(
                name: "user_social");

            migrationBuilder.DropTable(
                name: "course_lesson");

            migrationBuilder.DropTable(
                name: "question_answer");

            migrationBuilder.DropTable(
                name: "quiz");

            migrationBuilder.DropTable(
                name: "achievement");

            migrationBuilder.DropTable(
                name: "catalog");

            migrationBuilder.DropTable(
                name: "enrollment");

            migrationBuilder.DropTable(
                name: "user_skill");

            migrationBuilder.DropTable(
                name: "certificate");

            migrationBuilder.DropTable(
                name: "email");

            migrationBuilder.DropTable(
                name: "phone");

            migrationBuilder.DropTable(
                name: "social");

            migrationBuilder.DropTable(
                name: "course_chapter");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "creator");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
