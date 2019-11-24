using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrips.WebApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(nullable: false),
                    StreetNumber = table.Column<string>(nullable: false),
                    PostCode = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    NameId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.NameId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Distance = table.Column<decimal>(nullable: false),
                    StartAddressAddressId = table.Column<int>(nullable: false),
                    DestinationAddressAddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trips_Addresses_DestinationAddressAddressId",
                        column: x => x.DestinationAddressAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Addresses_StartAddressAddressId",
                        column: x => x.StartAddressAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Names_NameId",
                        column: x => x.NameId,
                        principalTable: "Names",
                        principalColumn: "NameId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressId",
                table: "Persons",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_NameId",
                table: "Persons",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DestinationAddressAddressId",
                table: "Trips",
                column: "DestinationAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_StartAddressAddressId",
                table: "Trips",
                column: "StartAddressAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Names");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
