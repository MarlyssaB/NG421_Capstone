using Microsoft.EntityFrameworkCore.Migrations;

namespace capstone.Data.Migrations
{
    public partial class AddMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "MovieEntries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: true),
                    genre = table.Column<string>(nullable: true),
                    stars = table.Column<int>(nullable: false),
                    review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieEntries", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "MovieEntries",
                columns: new[] { "id", "genre", "review", "stars", "title" },
                values: new object[] { 1, "Thriller, Horror", "Edge of your seat thriller, amazing performance by Anthony Hopkins", 5, "The Silence of the Lambs" });

            migrationBuilder.InsertData(
                table: "MovieEntries",
                columns: new[] { "id", "genre", "review", "stars", "title" },
                values: new object[] { 2, "Muscial, Drama", "Some memorable songs, decent date night movie", 3, "Chicago" });

            migrationBuilder.InsertData(
                table: "MovieEntries",
                columns: new[] { "id", "genre", "review", "stars", "title" },
                values: new object[] { 3, "Drama", "Awful movie that's fun it its own way. Best seen at a midnight showing", 2, "The Room" });

            migrationBuilder.InsertData(
                table: "MovieEntries",
                columns: new[] { "id", "genre", "review", "stars", "title" },
                values: new object[] { 4, "Musical, Comedy", "One of the Marx Brothers' best works", 4, "Animal Crackers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieEntries");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Sam", "Smith" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 2, "Tom", "Miller" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 3, "Mary", "Brooks" });
        }
    }
}
