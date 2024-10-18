using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GroupProject.Migrations
{
    /// <inheritdoc />
    public partial class Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Family" },
                    { 2, "Friend" },
                    { 3, "Work" },
                    { 4, "School" },
                    { 5, "Social" },
                    { 6, "Service Provider" },
                    { 7, "Community" }
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 1,
                column: "CategoryID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 2,
                column: "CategoryID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 3,
                column: "CategoryID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 4,
                column: "CategoryID",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactID",
                keyValue: 5,
                column: "CategoryID",
                value: 7);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryID",
                table: "Contacts",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Categories_CategoryID",
                table: "Contacts",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Categories_CategoryID",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CategoryID",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Contacts");
        }
    }
}
