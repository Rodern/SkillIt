using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillIT_Models.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationAndTokenEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    cityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    countryId = table.Column<long>(type: "bigint", nullable: false),
                    guid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    latitude = table.Column<double>(type: "double", nullable: false),
                    longitude = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.cityId);
                    table.ForeignKey(
                        name: "FK_city_country_countryId",
                        column: x => x.countryId,
                        principalTable: "country",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "region",
                columns: table => new
                {
                    regionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    countryId = table.Column<long>(type: "bigint", nullable: false),
                    guid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    short_code = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    capital_city = table.Column<long>(type: "bigint", nullable: false),
                    latitude = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    longitude = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_region", x => x.regionId);
                    table.ForeignKey(
                        name: "FK_region_country_countryId",
                        column: x => x.countryId,
                        principalTable: "country",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_country",
                columns: table => new
                {
                    user_countryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    countryId = table.Column<long>(type: "bigint", nullable: false),
                    date_set = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_country", x => x.user_countryId);
                    table.ForeignKey(
                        name: "FK_user_country_country_countryId",
                        column: x => x.countryId,
                        principalTable: "country",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_country_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_token",
                columns: table => new
                {
                    user_tokenId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    token = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    expiry_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_modified = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_token", x => x.user_tokenId);
                    table.ForeignKey(
                        name: "FK_user_token_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_city",
                columns: table => new
                {
                    user_cityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    cityId = table.Column<long>(type: "bigint", nullable: false),
                    date_set = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_city", x => x.user_cityId);
                    table.ForeignKey(
                        name: "FK_user_city_city_cityId",
                        column: x => x.cityId,
                        principalTable: "city",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_city_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_region",
                columns: table => new
                {
                    user_regionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    regionId = table.Column<long>(type: "bigint", nullable: false),
                    date_set = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_region", x => x.user_regionId);
                    table.ForeignKey(
                        name: "FK_user_region_region_regionId",
                        column: x => x.regionId,
                        principalTable: "region",
                        principalColumn: "regionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_region_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "idx_city_country",
                table: "city",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "idx_city_guid_unique",
                table: "city",
                column: "guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_region_country",
                table: "region",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "idx_region_guid_unique",
                table: "region",
                column: "guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_usercity_user_city_unique",
                table: "user_city",
                columns: new[] { "userId", "cityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_city_cityId",
                table: "user_city",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "idx_usercountry_user_country_unique",
                table: "user_country",
                columns: new[] { "userId", "countryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_country_countryId",
                table: "user_country",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "idx_userregion_user_region_unique",
                table: "user_region",
                columns: new[] { "userId", "regionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_region_regionId",
                table: "user_region",
                column: "regionId");

            migrationBuilder.CreateIndex(
                name: "idx_usertoken_user_unique",
                table: "user_token",
                column: "userId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_city");

            migrationBuilder.DropTable(
                name: "user_country");

            migrationBuilder.DropTable(
                name: "user_region");

            migrationBuilder.DropTable(
                name: "user_token");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "region");
        }
    }
}
