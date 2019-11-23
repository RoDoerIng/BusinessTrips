using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrips.WebApp.Migrations
{
    public partial class DataSeeding : Migration
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

            migrationBuilder.InsertData(
                table: "Names",
                columns: new[] { "NameId", "FirstName", "LastName" },
                values: new object[] { 1, "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Names",
                columns: new[] { "NameId", "FirstName", "LastName" },
                values: new object[] { 2, "Jane", "Doe" });

            migrationBuilder.InsertData(
                table: "Names",
                columns: new[] { "NameId", "FirstName", "LastName" },
                values: new object[] { 3, "FooBert", "BazMan" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "AddressId", "NameId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "AddressId", "NameId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "AddressId", "NameId" },
                values: new object[] { 3, 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "Names",
                keyColumn: "NameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Names",
                keyColumn: "NameId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Names",
                keyColumn: "NameId",
                keyValue: 3);
        }
    }
}
