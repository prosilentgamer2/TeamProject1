using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupProject.Migrations
{
    /// <inheritdoc />
    public partial class AddDateAddedToContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Contacts");
        }
    }
}
