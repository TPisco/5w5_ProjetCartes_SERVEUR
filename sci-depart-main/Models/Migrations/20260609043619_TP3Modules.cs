using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class TP3Modules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gold",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Losses",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "RewardsApplied",
                table: "Matches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GoldLoss",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoldStarting",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoldWin",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxCardsPerDeck",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxDecks",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Losses",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rarity",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Packs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CardCount = table.Column<int>(type: "int", nullable: false),
                    DefaultRarity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackProbabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackId = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    ProbabilityPercent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackProbabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackProbabilities_Packs_PackId",
                        column: x => x.PackId,
                        principalTable: "Packs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "daf0da8b-7740-4422-8c56-7910353c9b62", "AQAAAAIAAYagAAAAEKhNQJr64yG74d9ghKJoX3Uedofcq9PSVvfkPITPABBPJmoGA2uwCnWuBScA1cn5iQ==", "5ef13671-9d74-4111-9694-a289d5d17ee7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6df59671-e092-4511-8baa-b6c140a3e730", "50fce9b8-b5da-40c8-91bb-ffbe60214674" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a093e867-956a-4e42-960d-de1eac633917", "045d18bc-4a0b-4016-852f-5674e1558d10" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rarity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rarity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rarity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rarity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rarity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rarity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rarity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "Rarity",
                value: 1);

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[,]
                {
                    { 11, 3, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/025.png", "Pikachu", 0 },
                    { 12, 2, 1, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/133.png", "Evoli", 0 },
                    { 13, 1, 1, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/129.png", "Magicarpe", 0 },
                    { 14, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/448.png", "Lucario", 1 },
                    { 15, 4, 3, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/471.png", "Givrali", 1 },
                    { 16, 6, 5, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/009.png", "Tortank", 2 },
                    { 17, 5, 5, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/003.png", "Florizarre", 2 },
                    { 18, 7, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/658.png", "Amphinobi", 2 },
                    { 19, 9, 10, 9, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/493.png", "Arceus", 3 },
                    { 20, 8, 8, 8, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/483.png", "Dialga", 3 }
                });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "GoldLoss", "GoldStarting", "GoldWin", "MaxCardsPerDeck", "MaxDecks" },
                values: new object[] { 5, 300, 20, 30, 10 });

            migrationBuilder.InsertData(
                table: "Packs",
                columns: new[] { "Id", "CardCount", "DefaultRarity", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 3, 0, "/images/pack-basic.png", "Basic", 50 },
                    { 2, 4, 0, "/images/pack-normal.png", "Normal", 100 },
                    { 3, 5, 1, "/images/pack-super.png", "Super", 200 }
                });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Gold", "Losses", "Wins" },
                values: new object[] { 300, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Gold", "Losses", "Wins" },
                values: new object[] { 300, 0, 0 });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "Inflige la quantité X de dégâts à la carte affectée à la fin de son activation.Si une carte a déjà une valeur de poison et qu’elle est à nouveau attaquée, la valeur de poison est augmentée. (Stacks)", "☠", "PoisonX" },
                    { 2, "Empêche une carte d’agir pendant son activation durant X tours.Recoit quand-même les dégâts de poison et des autres cartes.", "💫", "StunnedX" },
                    { 3, "Un effet qui réduit les dégâts totaux d'une carte par X.", "⬇", "DamageDownX" }
                });

            migrationBuilder.InsertData(
                table: "PackProbabilities",
                columns: new[] { "Id", "PackId", "ProbabilityPercent", "Rarity" },
                values: new object[,]
                {
                    { 1, 1, 30.0, 1 },
                    { 2, 2, 30.0, 1 },
                    { 3, 2, 10.0, 2 },
                    { 4, 2, 2.0, 3 },
                    { 5, 3, 25.0, 2 },
                    { 6, 3, 10.0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackProbabilities_PackId",
                table: "PackProbabilities",
                column: "PackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackProbabilities");

            migrationBuilder.DropTable(
                name: "Packs");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Gold",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Losses",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RewardsApplied",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "GoldLoss",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "GoldStarting",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "GoldWin",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "MaxCardsPerDeck",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "MaxDecks",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "Losses",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "Cards");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d23784d-df87-40f8-9831-819a331101a4", "AQAAAAIAAYagAAAAEAkGJ/WuQtD44yhMqUG+1J3yYTBuWDzuKCm/kd2IfEtWrYOtd//EqcMcvEl2py8Cug==", "23f6e7b1-43f0-413a-ae24-0be26700a123" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8f5acab7-486f-4cb7-b2b5-aa4f30f81969", "17e7e0cc-0109-4213-81e0-ce02fc8f4ede" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bc668372-5a2e-4301-a9e0-fa56c1307d17", "44caf92c-ad72-45e7-8abc-e2f6fdf41117" });
        }
    }
}
