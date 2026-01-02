using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillIT_Models.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed default roles
            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "roleID", "name" },
                values: new object[,]
                {
                    { 1L, "User" },
                    { 2L, "Admin" },
                    { 3L, "Creator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove seeded roles
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "roleID",
                keyValues: new object[] { 1L, 2L, 3L });
        }
    }
}
