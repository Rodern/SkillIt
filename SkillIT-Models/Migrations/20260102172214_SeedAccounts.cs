using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillIT_Models.Migrations
{
    /// <inheritdoc />
    public partial class SeedAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed all 8 accounts - Note: account_status mapped to status enum, accountType enum (0=admin, 1=user)
            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "accountID", "userID", "accountType", "roleID", "last_login", "login_info", "status", "login_attemp" },
                values: new object[,]
                {
                    { 1L, 1661689094366L, 0, 2L, new DateTime(2022, 8, 28, 13, 18, 14), "[{\"Longitude\":\"1661689094366\",\"Latitude\":\"1661689094366\",\"DateTime\":\"2022-08-28T12:18:14.366Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"154.72.169.139\"}]", 3, "[{\"DateTime\":\"2022-08-28T12:18:14.366Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]" },
                    { 3L, 1661689919349L, 1, 1L, new DateTime(2022, 8, 28, 13, 31, 59), "[{\"Longitude\":\"1661689919349\",\"Latitude\":\"1661689919349\",\"DateTime\":\"2022-08-28T12:31:59.349Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"154.72.169.139\"}]", 3, "[{\"DateTime\":\"2022-08-28T12:31:59.349Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]" },
                    { 4L, 1663957971467L, 1, 3L, new DateTime(2022, 9, 23, 18, 32, 53), "[{\"Longitude\":\"10.1667\",\"Latitude\":\"5.9333\",\"DateTime\":\"2022-09-23T18:32:51.467Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.253\"}]", 3, "[{\"DateTime\":\"2022-09-23T18:32:51.467Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]" },
                    { 6L, 1668679350122L, 1, 1L, new DateTime(2022, 11, 17, 11, 2, 30), "[{\"Longitude\":\"1668679350122\",\"Latitude\":\"1668679350122\",\"DateTime\":\"2022-11-17T10:02:30.122Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.184\"}]", 3, "[{\"DateTime\":\"2022-11-17T10:02:30.122Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]" },
                    { 7L, 1671885852119L, 1, 2L, new DateTime(2022, 12, 24, 13, 44, 24), "[{\"Longitude\":\"1671885852119\",\"Latitude\":\"1671885852119\",\"DateTime\":\"2022-12-24T12:44:12.119Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.245\"}]", 3, "[{\"DateTime\":\"2022-12-24T12:44:12.119Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]" },
                    { 9L, 1677925925595L, 1, 1L, new DateTime(2023, 3, 4, 11, 32, 6), "[{\"Longitude\":\"1677925925595\",\"Latitude\":\"1677925925595\",\"DateTime\":\"2023-03-04T10:32:05.595Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.157\"}]", 3, "[{\"DateTime\":\"2023-03-04T10:32:05.595Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]" },
                    { 15L, 1678544061950L, 1, 1L, new DateTime(2023, 3, 11, 14, 14, 22), "[{\"Longitude\":\"4.6628\",\"Latitude\":\"52.3952\",\"DateTime\":\"2023-03-11T14:14:21.95Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"51.15.5.5\"}]", 3, "[{\"DateTime\":\"2023-03-11T14:14:21.95Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]" },
                    { 18L, 1681811805905L, 1, 1L, new DateTime(2023, 4, 18, 9, 56, 46), "[{\"Longitude\":\"10.146\",\"Latitude\":\"5.9597\",\"DateTime\":\"2023-04-18T09:56:45.906Z\",\"IsOnline\":false,\"IsLoggedOut\":true,\"Ip\":\"129.0.78.239\"}]", 3, "[{\"DateTime\":\"2023-04-18T09:56:45.906Z\",\"Reason\":\"Justified\",\"Status\":\"success\"}]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove seeded accounts
            migrationBuilder.DeleteData(
                table: "account",
                keyColumn: "accountID",
                keyValues: new object[] { 1L, 3L, 4L, 6L, 7L, 9L, 15L, 18L });
        }
    }
}
