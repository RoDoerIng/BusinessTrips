using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrips.WebApp.Migrations
{
    public partial class AddressSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "PostCode", "Street", "StreetNumber" },
                values: new object[] { 1, "FooCity", "12345", "FooStreet", "42" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "PostCode", "Street", "StreetNumber" },
                values: new object[] { 2, "BarTown", "99999", "BarAvenue", "0" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "PostCode", "Street", "StreetNumber" },
                values: new object[] { 3, "BazVillage", "00000", "BazWay", "99" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3);
        }
    }
}
