using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CookieApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    benchmark_place = table.Column<int>(type: "integer", nullable: false),
                    votes_place = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ratings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nickname = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    password_salt = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false, defaultValue: "user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accessories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    benchmark = table.Column<int>(type: "integer", nullable: false),
                    votes_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    rating_id = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    cores_count = table.Column<int>(type: "integer", nullable: true),
                    threads_count = table.Column<int>(type: "integer", nullable: true),
                    minimum_frequency = table.Column<int>(type: "integer", nullable: true),
                    maximum_frequency = table.Column<int>(type: "integer", nullable: true),
                    nanometers_count = table.Column<int>(type: "integer", nullable: true),
                    video_memory_count = table.Column<int>(type: "integer", nullable: true),
                    manufacturer = table.Column<string>(type: "text", nullable: true),
                    memory = table.Column<int>(type: "integer", nullable: true),
                    memory_frequency = table.Column<int>(type: "integer", nullable: true),
                    timings = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accessories", x => x.id);
                    table.ForeignKey(
                        name: "fk_accessories_ratings_rating_id",
                        column: x => x.rating_id,
                        principalTable: "ratings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "nickname", "password_hash", "password_salt", "role" },
                values: new object[,]
                {
                    { new Guid("6d5815f0-36a4-4a8d-a914-2631cad2b46f"), "defaultAdmin", "HjTeJSbhG88kPT1FXDFFIsNxq17CwRZkrC7kv9iT25xvgN7PKKQea6GRRgk1qCs+cpkmNpYalrWfdOjG/xysEgX9WuqUMM5dW66Fs/DU+edR9WpW+aVrwbFsq7fglsuAlcbvoPyi+wiUp7lhweorDG7juz2VxAE2TdwoIEZ53q0=", "GPmPNNV1q0rF7+WkDgPTJQ==", "admin" },
                    { new Guid("baba17a6-d265-418d-8975-936e89ecc752"), "defaultUser", "N88fRfSdIMEsrcOa3iuM4MwqikwH9JzDHQXWfQAPW1BtqdcO+dXpwBTufghVG1Rjy/o4ucJgYsbRdEYT+pvQJz0+BJhSYu2G+Gf3W0UzegMRDMgdOP5C/Of3wKk3F5QYBKJ+4ryKjFN9QsoJzCQpsd+zQqFr0COdGtBqc2TAVzE=", "y9ssvBIp643GnKgThlsGyg==", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_accessories_rating_id",
                table: "accessories",
                column: "rating_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accessories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "ratings");
        }
    }
}
