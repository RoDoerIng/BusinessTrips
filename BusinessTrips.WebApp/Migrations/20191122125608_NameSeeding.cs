using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrips.WebApp.Migrations
{
    public partial class NameSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
