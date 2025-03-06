using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCard_Cards_CardId",
                table: "OwnedCard");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCard_Players_PlayerId",
                table: "OwnedCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnedCard",
                table: "OwnedCard");

            migrationBuilder.RenameTable(
                name: "OwnedCard",
                newName: "OwnedCards");

            migrationBuilder.RenameIndex(
                name: "IX_OwnedCard_PlayerId",
                table: "OwnedCards",
                newName: "IX_OwnedCards_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_OwnedCard_CardId",
                table: "OwnedCards",
                newName: "IX_OwnedCards_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnedCards",
                table: "OwnedCards",
                column: "id");

            migrationBuilder.CreateTable(
                name: "GameConfigs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtManaParTour = table.Column<int>(type: "int", nullable: false),
                    nbCardsToDraw = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConfigs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StartingCards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartingCards", x => x.id);
                    table.ForeignKey(
                        name: "FK_StartingCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10ff9abb-ad5e-44d0-b859-04edb716a57e", "AQAAAAIAAYagAAAAELGSVDqUH83sZtGBtg3kAoTUB7PSWMy4kSFAoEN6cNWsQheYW2SLJ9zwEpBefToF9g==", "b1c950e0-019e-4231-bd91-70b5939a336b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "85bcb1bd-659d-4eaa-b519-5b663b29b163", "33165ee0-8a69-4669-a515-c6d17095331c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9dc4a52b-7e2d-4ae5-9e48-099ce94aa434", "db5df231-c3d3-4e27-9b19-6933b884edbc" });

            migrationBuilder.CreateIndex(
                name: "IX_StartingCards_CardId",
                table: "StartingCards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedCards_Cards_CardId",
                table: "OwnedCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedCards_Players_PlayerId",
                table: "OwnedCards",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCards_Cards_CardId",
                table: "OwnedCards");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCards_Players_PlayerId",
                table: "OwnedCards");

            migrationBuilder.DropTable(
                name: "GameConfigs");

            migrationBuilder.DropTable(
                name: "StartingCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnedCards",
                table: "OwnedCards");

            migrationBuilder.RenameTable(
                name: "OwnedCards",
                newName: "OwnedCard");

            migrationBuilder.RenameIndex(
                name: "IX_OwnedCards_PlayerId",
                table: "OwnedCard",
                newName: "IX_OwnedCard_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_OwnedCards_CardId",
                table: "OwnedCard",
                newName: "IX_OwnedCard_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnedCard",
                table: "OwnedCard",
                column: "id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "041154f5-1b71-4e9b-a512-a18176f5a119", "AQAAAAIAAYagAAAAEOtIbb8KPn0bWIDPAV4JPoDcw0WPgaTMCH9TXv7t+zHzhQznx5OgL9xc4vDsZt3mSg==", "45ab03be-edcf-4fa8-b5d1-40314da17a9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "301cc8f0-6b25-4dfd-9161-aa24ff72fbe1", "a7648d51-b943-467e-b978-cd160ce42f78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9049435f-abce-446f-924b-5c8dbf2d4afa", "67f483aa-e687-4993-816e-0a1a342c14c3" });

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedCard_Cards_CardId",
                table: "OwnedCard",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedCard_Players_PlayerId",
                table: "OwnedCard",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
