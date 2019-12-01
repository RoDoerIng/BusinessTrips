using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrips.WebApp.Migrations
{
    public partial class NewDataTypeForDistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Distance",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 1,
                columns: new[] { "Date", "Distance" },
                values: new object[] { new DateTime(1989, 12, 1, 20, 20, 47, 512, DateTimeKind.Local).AddTicks(4139), 2.2999999999999998 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 2,
                columns: new[] { "Date", "Distance" },
                values: new object[] { new DateTime(2009, 12, 1, 20, 20, 47, 515, DateTimeKind.Local).AddTicks(9307), 4.0 });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 3,
                columns: new[] { "Date", "Distance" },
                values: new object[] { new DateTime(2018, 9, 2, 20, 20, 47, 515, DateTimeKind.Local).AddTicks(9388), 1.8999999999999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Distance",
                table: "Trips",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 1,
                columns: new[] { "Date", "Distance" },
                values: new object[] { new DateTime(1989, 11, 24, 20, 48, 31, 585, DateTimeKind.Local).AddTicks(5289), 2.3m });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 2,
                columns: new[] { "Date", "Distance" },
                values: new object[] { new DateTime(2009, 11, 24, 20, 48, 31, 588, DateTimeKind.Local).AddTicks(9486), 4.0m });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 3,
                columns: new[] { "Date", "Distance" },
                values: new object[] { new DateTime(2018, 8, 26, 20, 48, 31, 588, DateTimeKind.Local).AddTicks(9578), 1.9m });
        }
    }
}
