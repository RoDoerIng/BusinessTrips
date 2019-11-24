using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrips.WebApp.Migrations
{
    public partial class TripSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Date", "DestinationAddressAddressId", "Distance", "StartAddressAddressId" },
                values: new object[] { 1, new DateTime(1989, 11, 24, 20, 48, 31, 585, DateTimeKind.Local).AddTicks(5289), 2, 2.3m, 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Date", "DestinationAddressAddressId", "Distance", "StartAddressAddressId" },
                values: new object[] { 2, new DateTime(2009, 11, 24, 20, 48, 31, 588, DateTimeKind.Local).AddTicks(9486), 3, 4.0m, 2 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Date", "DestinationAddressAddressId", "Distance", "StartAddressAddressId" },
                values: new object[] { 3, new DateTime(2018, 8, 26, 20, 48, 31, 588, DateTimeKind.Local).AddTicks(9578), 1, 1.9m, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 3);
        }
    }
}
