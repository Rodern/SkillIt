using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillIT_Models.Migrations
{
    /// <inheritdoc />
    public partial class SeedCountriesAndLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed Countries - Essential countries for global platform
            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "countryId", "name", "iso2", "phoneCode", "currency_symbol", "capital", "currency", "region", "subregion", "iso3" },
                values: new object[,]
                {
                    { 1L, "Afghanistan", "AF", 93, "؋", "Kabul", "AFN", "Asia", "AS", "AFG" },
                    { 14L, "Australia", "AU", 61, "$", "Canberra", "AUD", "Oceania", "OC", "AUS" },
                    { 19L, "Bangladesh", "BD", 880, "৳", "Dhaka", "BDT", "Asia", "AS", "BGD" },
                    { 22L, "Belgium", "BE", 32, "€", "Brussels", "EUR", "Europe", "EU", "BEL" },
                    { 32L, "Brazil", "BR", 55, "R$", "Brasilia", "BRL", "South America", "SA", "BRA" },
                    { 39L, "Cameroon", "CM", 237, "FCFA", "Yaounde", "XAF", "Africa", "AF", "CMR" },
                    { 40L, "Canada", "CA", 1, "$", "Ottawa", "CAD", "North America", "NA", "CAN" },
                    { 46L, "China", "CN", 86, "¥", "Beijing", "CNY", "Asia", "AS", "CHN" },
                    { 49L, "Colombia", "CO", 57, "$", "Bogota", "COP", "South America", "SA", "COL" },
                    { 61L, "Denmark", "DK", 45, "Kr.", "Copenhagen", "DKK", "Europe", "EU", "DNK" },
                    { 66L, "Egypt", "EG", 20, "ج.م", "Cairo", "EGP", "Africa", "AF", "EGY" },
                    { 75L, "Finland", "FI", 358, "€", "Helsinki", "EUR", "Europe", "EU", "FIN" },
                    { 76L, "France", "FR", 33, "€", "Paris", "EUR", "Europe", "EU", "FRA" },
                    { 83L, "Germany", "DE", 49, "€", "Berlin", "EUR", "Europe", "EU", "DEU" },
                    { 84L, "Ghana", "GH", 233, "GH₵", "Accra", "GHS", "Africa", "AF", "GHA" },
                    { 86L, "Greece", "GR", 30, "€", "Athens", "EUR", "Europe", "EU", "GRC" },
                    { 100L, "Hong Kong", "HK", 852, "$", "Hong Kong", "HKD", "Asia", "AS", "HKG" },
                    { 103L, "India", "IN", 91, "₹", "New Delhi", "INR", "Asia", "AS", "IND" },
                    { 104L, "Indonesia", "ID", 62, "Rp", "Jakarta", "IDR", "Asia", "AS", "IDN" },
                    { 107L, "Ireland", "IE", 353, "€", "Dublin", "EUR", "Europe", "EU", "IRL" },
                    { 109L, "Israel", "IL", 972, "₪", "Jerusalem", "ILS", "Asia", "AS", "ISR" },
                    { 110L, "Italy", "IT", 39, "€", "Rome", "EUR", "Europe", "EU", "ITA" },
                    { 112L, "Japan", "JP", 81, "¥", "Tokyo", "JPY", "Asia", "AS", "JPN" },
                    { 116L, "Kenya", "KE", 254, "KSh", "Nairobi", "KES", "Africa", "AF", "KEN" },
                    { 119L, "South Korea", "KR", 82, "₩", "Seoul", "KRW", "Asia", "AS", "KOR" },
                    { 145L, "Mexico", "MX", 52, "$", "Mexico City", "MXN", "North America", "NA", "MEX" },
                    { 158L, "Netherlands", "NL", 31, "€", "Amsterdam", "EUR", "Europe", "EU", "NLD" },
                    { 161L, "New Zealand", "NZ", 64, "$", "Wellington", "NZD", "Oceania", "OC", "NZL" },
                    { 164L, "Nigeria", "NG", 234, "₦", "Abuja", "NGN", "Africa", "AF", "NGA" },
                    { 168L, "Norway", "NO", 47, "kr", "Oslo", "NOK", "Europe", "EU", "NOR" },
                    { 170L, "Pakistan", "PK", 92, "₨", "Islamabad", "PKR", "Asia", "AS", "PAK" },
                    { 177L, "Philippines", "PH", 63, "₱", "Manila", "PHP", "Asia", "AS", "PHL" },
                    { 179L, "Poland", "PL", 48, "zł", "Warsaw", "PLN", "Europe", "EU", "POL" },
                    { 180L, "Portugal", "PT", 351, "€", "Lisbon", "EUR", "Europe", "EU", "PRT" },
                    { 185L, "Russia", "RU", 70, "₽", "Moscow", "RUB", "Asia", "AS", "RUS" },
                    { 197L, "Saudi Arabia", "SA", 966, "﷼", "Riyadh", "SAR", "Asia", "AS", "SAU" },
                    { 203L, "Singapore", "SG", 65, "$", "Singapur", "SGD", "Asia", "AS", "SGP" },
                    { 209L, "South Africa", "ZA", 27, "R", "Pretoria", "ZAR", "Africa", "AF", "ZAF" },
                    { 212L, "Spain", "ES", 34, "€", "Madrid", "EUR", "Europe", "EU", "ESP" },
                    { 213L, "Sri Lanka", "LK", 94, "Rs", "Colombo", "LKR", "Asia", "AS", "LKA" },
                    { 218L, "Sweden", "SE", 46, "kr", "Stockholm", "SEK", "Europe", "EU", "SWE" },
                    { 219L, "Switzerland", "CH", 41, "CHf", "Berne", "CHF", "Europe", "EU", "CHE" },
                    { 221L, "Taiwan", "TW", 886, "$", "Taipei", "TWD", "Asia", "AS", "TWN" },
                    { 224L, "Thailand", "TH", 66, "฿", "Bangkok", "THB", "Asia", "AS", "THA" },
                    { 231L, "Turkey", "TR", 90, "₺", "Ankara", "TRY", "Asia", "AS", "TUR" },
                    { 237L, "United Arab Emirates", "AE", 971, "إ.د", "Abu Dhabi", "AED", "Asia", "AS", "ARE" },
                    { 238L, "United Kingdom", "GB", 44, "£", "London", "GBP", "Europe", "EU", "GBR" },
                    { 239L, "United States", "US", 1, "$", "Washington", "USD", "North America", "NA", "USA" },
                    { 245L, "Vietnam", "VN", 84, "₫", "Hanoi", "VND", "Asia", "AS", "VNM" }
                });

            // Seed Languages
            migrationBuilder.InsertData(
                table: "language",
                columns: new[] { "languageId", "countryId", "name" },
                values: new object[,]
                {
                    { 1L, 238L, "English" },
                    { 2L, 76L, "French" },
                    { 3L, 212L, "Spanish" },
                    { 4L, 46L, "Chinese" },
                    { 5L, 112L, "Japanese" },
                    { 6L, 83L, "German" },
                    { 7L, 180L, "Portuguese" },
                    { 8L, 185L, "Russian" },
                    { 9L, 103L, "Hindi" },
                    { 10L, 119L, "Korean" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove seeded languages
            migrationBuilder.DeleteData(
                table: "language",
                keyColumn: "languageId",
                keyValues: new object[] { 1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L, 9L, 10L });

            // Remove seeded countries
            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "countryId",
                keyValues: new object[] { 1L, 14L, 19L, 22L, 32L, 39L, 40L, 46L, 49L, 61L, 66L, 75L, 76L, 83L, 84L, 86L, 100L, 103L, 104L, 107L, 109L, 110L, 112L, 116L, 119L, 145L, 158L, 161L, 164L, 168L, 170L, 177L, 179L, 180L, 185L, 197L, 203L, 209L, 212L, 213L, 218L, 219L, 221L, 224L, 231L, 237L, 238L, 239L, 245L });
        }
    }
}
