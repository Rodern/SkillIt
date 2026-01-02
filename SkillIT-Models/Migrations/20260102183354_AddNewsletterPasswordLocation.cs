using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillIT_Models.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsletterPasswordLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "news_letter",
                columns: table => new
                {
                    news_letterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    guid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    letter_body = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    letter_type = table.Column<int>(type: "int", nullable: false),
                    schedule_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news_letter", x => x.news_letterId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "password",
                columns: table => new
                {
                    passwordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    hashed = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    salt = table.Column<byte[]>(type: "varbinary(128)", nullable: false),
                    last_changed = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    past_passwords = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_password", x => x.passwordId);
                    table.ForeignKey(
                        name: "FK_password_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "simple_location",
                columns: table => new
                {
                    locationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    longitude = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    latitude = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_simple_location", x => x.locationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "news_letter_subscriber",
                columns: table => new
                {
                    news_letter_subscriberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    emailId = table.Column<long>(type: "bigint", nullable: false),
                    subscriber_code = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_subscribed = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NewsLetterId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news_letter_subscriber", x => x.news_letter_subscriberId);
                    table.ForeignKey(
                        name: "FK_news_letter_subscriber_email_emailId",
                        column: x => x.emailId,
                        principalTable: "email",
                        principalColumn: "emailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_news_letter_subscriber_news_letter_NewsLetterId",
                        column: x => x.NewsLetterId,
                        principalTable: "news_letter",
                        principalColumn: "news_letterId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "idx_newsletter_guid_unique",
                table: "news_letter",
                column: "guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_newsletter_status_schedule",
                table: "news_letter",
                columns: new[] { "status", "schedule_date" });

            migrationBuilder.CreateIndex(
                name: "idx_newslettersubscriber_code_unique",
                table: "news_letter_subscriber",
                column: "subscriber_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_newslettersubscriber_email",
                table: "news_letter_subscriber",
                column: "emailId");

            migrationBuilder.CreateIndex(
                name: "IX_news_letter_subscriber_NewsLetterId",
                table: "news_letter_subscriber",
                column: "NewsLetterId");

            migrationBuilder.CreateIndex(
                name: "idx_password_lastchanged",
                table: "password",
                column: "last_changed");

            migrationBuilder.CreateIndex(
                name: "idx_password_user",
                table: "password",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news_letter_subscriber");

            migrationBuilder.DropTable(
                name: "password");

            migrationBuilder.DropTable(
                name: "simple_location");

            migrationBuilder.DropTable(
                name: "news_letter");
        }
    }
}
