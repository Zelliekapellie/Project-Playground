using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Porcupine3API.Migrations
{
    /// <inheritdoc />
    public partial class procupine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Group1" },
                    { 2, "Group2" },
                    { 3, "Group3" },
                    { 4, "Group4" },
                    { 5, "Group5" },
                    { 6, "Group6" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "ID", "GroupID", "Level", "UserID" },
                values: new object[,]
                {
                    { 1, 1, null, 1 },
                    { 2, 1, null, 2 },
                    { 3, 2, null, 1 },
                    { 4, 2, null, 5 },
                    { 5, 3, null, 3 },
                    { 6, 3, null, 4 },
                    { 7, 4, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "mmcd@email.com", "Marly", "McDonnell" },
                    { 2, "anewton@email.com", "Isaac", "Newton" },
                    { 3, "agarcia@email.com", "Isabella", "Garcia" },
                    { 4, "pcruz@email.com", "Penelope", "Cruz" },
                    { 5, "ttickle@email.com", "Tess", "Tickle" },
                    { 6, "sreed@email.com", "Spencer", "Reed" },
                    { 7, "drossi@email.com", "David", "Rossi" },
                    { 8, "ahotchner@email.com", "Aaron", "Hotchner" },
                    { 9, "mfreeman@email.com", "Morgan", "Freeman" },
                    { 10, "tlasso@email.com", "Ted", "Lasso" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
