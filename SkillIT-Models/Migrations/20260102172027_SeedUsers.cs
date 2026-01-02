using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillIT_Models.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed all 8 users from old database
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userID", "gender", "first_name", "last_name", "email", "username", "password", "dob", "address", "date_created", "phone", "profile_image" },
                values: new object[,]
                {
                    { 1661689094366L, 0, "Alain", "Kimbu", "k.n.alain@gmail.com", "Aprilman", "AE1t3CWEYAqaIE0ISiCol6N8m+YsEvPO1Dq3WRn+G7pkYvMEjp3vOe/dOutAcQr84g==", new DateTime(2022, 8, 28), "Bambui, NorthWest Cameroon", new DateTime(2022, 8, 28, 12, 18, 14), "651008132", "1661689094366_k.n.alain@gmail.com_profileImage.png" },
                    { 1661689919349L, 0, "Alain", "Kimbu", "i.am@mail.com", "ak2000", "AOEEDhsuyl6lTjWbPvo5VhArqeGuOrrv8CQdgBQNlHkzQTjeJMAow1xCBE+kwSwUqg==", new DateTime(2022, 8, 28), "Address", new DateTime(2022, 8, 28, 12, 31, 59), "623012523", "" },
                    { 1663957971467L, 0, "Bradon", "Ted", "ted.bradon@mail.com", "bradon", "AAbhkMr741DvERk3DOG5S31cOQN/DUdbp5WJ4OQIQG42z0+FoNhyFqRBK6XG41Yq9w==", new DateTime(1, 1, 1), "Bambui, NorthWest Cameroon", new DateTime(2022, 9, 23, 18, 32, 51), "623948023", "" },
                    { 1668679350122L, 0, "Alain", "Kimbu", "nik.alain@gmail.com", "kan23", "AP/aIdz5B3LmJ3WhsLsGIlTI0cnYr28/X3mZ43Q8NUm4oNB0Qmgigqy6P008JYlEjw==", new DateTime(2000, 4, 29), "Bambui, Mile 10 mattam quarter", new DateTime(2022, 11, 17, 10, 2, 30), "651008132", "" },
                    { 1671885852119L, 1, "Rousanne", "Ngam", "rousy@gmail.com", "Rousy", "AH8WYbZYe3Vrs8twBnFYW3Yz5nrRdls+rCKprTJ8NOrFfZNn6TuvqMU76ewtEAkzCw==", new DateTime(2001, 4, 9), "Bambui, Mile 10 mattam quarter", new DateTime(2022, 12, 24, 12, 44, 12), "670312417", "1671885852119_rousy@gmail.com_profileImage.png" },
                    { 1677925925595L, 0, "Randy", "King", "randy.king@email.com", "King_R", "AFveUqywGJGRUy6qINcpdHlZ4kolQxsYubNOQX8jhQHq5Ehjk8QsZK928aqJOhqcSQ==", new DateTime(1993, 4, 14), "Bamenda Cameroon", new DateTime(2023, 3, 4, 10, 32, 5), "651008132", "1677925925595_randy.king@email.com_profileImage.png" },
                    { 1678544061950L, 0, "Lord", "Kimbu", "lordkimbu@gmail.com", "Lord_K", "AI5F6F59KvyQUnGmKUA/OverOK465h/P8jiFFRpAC5EtXvIHd7Yt/A487/QfejqulA==", new DateTime(2000, 2, 16), "Bambui, NorthWest Cameroon", new DateTime(2023, 3, 11, 14, 14, 22), "651008132", "1678544061950_lordkimbu@gmail.com_profileImage.png" },
                    { 1681811805905L, 0, "The", "Name", "test@gmail.com", "test_guy", "AEGdiiEK0i1hb1h18J9rLIfabiZLdRbDjF4ooiFHtQjSN4r3ox3gx9nLVXpFVq8Ujg==", new DateTime(2023, 4, 18), "Address", new DateTime(2023, 4, 18, 9, 56, 46), "673801740", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove seeded users
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userID",
                keyValues: new object[] { 1661689094366L, 1661689919349L, 1663957971467L, 1668679350122L, 1671885852119L, 1677925925595L, 1678544061950L, 1681811805905L });
        }
    }
}
