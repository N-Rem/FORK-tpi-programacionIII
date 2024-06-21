using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sneakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sneakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    IsClient = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFinalized = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationSneaker",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false),
                    SneakersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationSneaker", x => new { x.ReservationId, x.SneakersId });
                    table.ForeignKey(
                        name: "FK_ReservationSneaker_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationSneaker_sneakers_SneakersId",
                        column: x => x.SneakersId,
                        principalTable: "sneakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "sneakers",
                columns: new[] { "Id", "Brand", "Category", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Nike", "Sports", "Air Max", 120, 50 },
                    { 2, "Adidas", "Casual", "Classic", 100, 30 },
                    { 3, "Nike", "Running", "ZoomX", 150, 20 },
                    { 4, "Adidas", "Casual", "Superstar", 80, 40 },
                    { 5, "Adidas", "Running", "Gel-Kayano", 140, 25 },
                    { 6, "Converse", "Casual", "Chuck Taylor", 60, 35 },
                    { 7, "Adidas", "Running", "Ultraboost", 180, 15 },
                    { 8, "Nike", "Sports", "Pegasus", 110, 45 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "EmailAddress", "IsClient", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Ana@example.com", false, "Ana", "Pass1" },
                    { 2, "delfina@example.com", false, "Delfina", "Pass2" },
                    { 3, "juan.doe@example.com", true, "Juan", "Pass3" },
                    { 4, "vicky.sosa@example.com", true, "Victoria", "Pass4" },
                    { 5, "lautaro.rb@example.com", true, "Lautaro", "Pass5" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "IdUser", "IsFinalized" },
                values: new object[,]
                {
                    { 1, 3, false },
                    { 2, 4, false },
                    { 3, 5, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IdUser",
                table: "Reservations",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSneaker_SneakersId",
                table: "ReservationSneaker",
                column: "SneakersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationSneaker");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "sneakers");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
