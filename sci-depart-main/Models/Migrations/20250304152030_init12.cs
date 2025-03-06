using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCards_Cards_CardId",
                table: "OwnedCards");

            migrationBuilder.DropIndex(
                name: "IX_OwnedCards_CardId",
                table: "OwnedCards");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "166b19e0-f6b3-4dd0-94ec-b97fd54032f8", "AQAAAAIAAYagAAAAEKRcBK9EnBDU0cOntfaeRP5C0k9iJmmrbGV1D2eKXr9HZiNRnGfulbsaOSrU6dnGCg==", "8093df44-822c-4b5b-ae0f-000465357242" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b2444b6-4fd2-448e-ba7c-a5179625365b", "bb5dab07-3426-46cf-b1d4-6fdfad8d03c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9f7a1ae9-5d4f-4172-93bc-cb134b69f151", "f1263217-5cf9-479b-944d-0a137df64dfa" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 5, 5, 8, "https://pm1.aminoapps.com/6906/f456d54f84291a3e3a9532251214cda80cbef906r1-335-431v2_hq.jpg", "Dracolosse" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "Cost", "ImageUrl", "Name" },
                values: new object[] { 10, 9, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/384.png", "Rayquaza" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://upload.wikimedia.org/wikipedia/en/2/22/Pok%C3%A9mon_Jigglypuff_art.png", "Rondoudou" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "ImageUrl", "Name" },
                values: new object[] { 6, "https://e7.pngegg.com/pngimages/993/391/png-clipart-pokemon-character-illustration-pokemon-x-and-y-pokemon-go-pokemon-black-white-mewtwo-pokemon-go-purple-mammal.png", "Mewtwo" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/282.png", "Gardevoir" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/065.png", "Alakazam" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/095.png", "Onix" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/143.png", "Ronflex" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/151.png", "Mew" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006_f2.png", "Dracofeu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a39917e4-a99a-4b5d-9d11-246d3fe602e0", "AQAAAAIAAYagAAAAENOkH0mro2+ugBhznlg+0cXItfSMoIQddAeeBQ65rAEg9rO+/WK+E/FByS6dHutf6w==", "a37a1947-7fb8-4bd1-bb5a-2c80e3a308fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c62e5d40-dd92-4537-a6fe-1cbdab7d68b4", "84bf3693-74a0-4e3e-ae7b-bc91c42c8571" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2bf4cd8-ed5c-49fa-86f5-39b4fa860e7c", "02b95514-3896-4c7a-bbf7-e6feb0d754ff" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 3, 3, 3, "https://i.pinimg.com/originals/a8/16/49/a81649bd4b0f032ce633161c5a076b87.jpg", "Chat Dragon" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "Cost", "ImageUrl", "Name" },
                values: new object[] { 2, 3, "https://i0.wp.com/thediscerningcat.com/wp-content/uploads/2021/02/tabby-cat-wearing-sunglasses.jpg", "Chat Awesome" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://cdn.wallpapersafari.com/27/53/SZ8PO9.jpg", "Chatton Laser" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "ImageUrl", "Name" },
                values: new object[] { 4, "https://wallpapers.com/images/hd/epic-cat-poster-baavft05ylgta4j8.jpg", "Chat Spacial" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://i.etsystatic.com/6230905/r/il/32aa5a/3474618751/il_fullxfull.3474618751_mfvf.jpg", "Chat Guerrier" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://store.playstation.com/store/api/chihiro/00_09_000/container/AU/en/99/EP2402-CUSA05624_00-ETH0000000002875/0/image?_version=00_09_000&platform=chihiro&bg_color=000000&opacity=100&w=720&h=720", "Chat Laser" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://images.squarespace-cdn.com/content/51b3dc8ee4b051b96ceb10de/1394662654865-JKOZ7ZFF39247VYDTGG9/hilarious-jedi-cats-fight-video-preview.jpg?content-type=image%2Fjpeg", "Jedi Chat" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://i.ytimg.com/vi/2I7pZlUhZak/maxresdefault.jpg", "Blob Chat" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://townsquare.media/site/142/files/2011/08/jedicats.jpg?w=980&q=75", "Jedi Chatton" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://cdn.theatlantic.com/thumbor/fOZjgqHH0RmXA1A5ek-yDz697W4=/133x0:2091x1020/1200x625/media/img/mt/2015/12/RTRD62Q/original.jpg", "Chat Furtif" });

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCards_CardId",
                table: "OwnedCards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedCards_Cards_CardId",
                table: "OwnedCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
