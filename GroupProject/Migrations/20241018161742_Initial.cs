using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GroupProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactID", "Email", "FirstName", "LastName", "Organization", "Phone" },
                values: new object[,]
                {
                    { 1, "huda.judeh@southeasttech.edu", "Huda", "Judeh", "Southeast Technial College", "605-555-1234" },
                    { 2, "ducotemike@yahoo.com", "Michael", "Ducote", null, "225-987-5555" },
                    { 3, "tom.winker@winfieldcorp.com", "Thomas", "Winker", "Winfield Corporation", "605-555-6789" },
                    { 4, "drmattb@siouxfallschiro.com", "Matt", "Brandner", "Sioux Falls Chiropractic", "605-555-9876" },
                    { 5, "arends.em@gmail.com", "Emma", "Arends", null, "320-456-7890" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
