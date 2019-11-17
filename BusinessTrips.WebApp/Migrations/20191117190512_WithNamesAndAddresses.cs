using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrips.WebApp.Migrations
{
    public partial class WithNamesAndAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Address_AddressId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Name_NameId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_Person_NameId",
                table: "Persons",
                newName: "IX_Persons_NameId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_AddressId",
                table: "Persons",
                newName: "IX_Persons_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Address_AddressId",
                table: "Persons",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Name_NameId",
                table: "Persons",
                column: "NameId",
                principalTable: "Name",
                principalColumn: "NameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Address_AddressId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Name_NameId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_NameId",
                table: "Person",
                newName: "IX_Person_NameId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_AddressId",
                table: "Person",
                newName: "IX_Person_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Address_AddressId",
                table: "Person",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Name_NameId",
                table: "Person",
                column: "NameId",
                principalTable: "Name",
                principalColumn: "NameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
