using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class Seed400Pokemon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c801bc6-3fd8-461f-a3ba-401343bcc248", "AQAAAAIAAYagAAAAEMWOBP0d8hhm0butT7H3twPKSJO0Beo19bJYbeBV8BhndSs34F8N6ShbFHZHXFv7VQ==", "8cccb016-5518-481c-83ad-4e377c436e81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cd48ad54-149d-47a7-b982-1f1232b6a7b2", "fc54b3a7-37e3-4af0-b9d9-16cf28fa4d7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d9624350-cdca-457d-a89b-ae85eab191be", "89a767c0-33d5-4888-acaf-f4514c2cf755" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/001.png", "Bulbizarre", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/002.png", "Herbizarre", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/003.png", "Florizarre", 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/004.png", "Salamèche", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Attack", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/005.png", "Reptincel", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006.png", "Dracaufeu", 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Attack", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/007.png", "Carapuce", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/008.png", "Carabaffe" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/009.png", "Tortank", 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Attack", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/010.png", "Chenipan", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Attack", "Health", "ImageUrl", "Name" },
                values: new object[] { 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/011.png", "Chrysacier" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/012.png", "Papilusion" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 2, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/013.png", "Aspicot" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 2, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/014.png", "Coconfort", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/015.png", "Dardargnan", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/016.png", "Roucool", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/017.png", "Roucoups", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/018.png", "Roucarnage", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 3, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/019.png", "Rattata", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/020.png", "Rattatac", 0 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[,]
                {
                    { 21, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/021.png", "Piafabec", 0 },
                    { 22, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/022.png", "Rapasdepic", 0 },
                    { 23, 4, 3, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/023.png", "Abo", 0 },
                    { 24, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/024.png", "Arbok", 0 },
                    { 25, 4, 3, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/025.png", "Pikachu", 0 },
                    { 26, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/026.png", "Raichu", 0 },
                    { 27, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/027.png", "Sabelette", 0 },
                    { 28, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/028.png", "Sablaireau", 0 },
                    { 29, 3, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/029.png", "Nidoran♀", 0 },
                    { 30, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/030.png", "Nidorina", 0 },
                    { 31, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/031.png", "Nidoqueen", 1 },
                    { 32, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/032.png", "Nidoran♂", 0 },
                    { 33, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/033.png", "Nidorino", 0 },
                    { 34, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/034.png", "Nidoking", 1 },
                    { 35, 4, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/035.png", "Mélofée", 0 },
                    { 36, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/036.png", "Mélodelfe", 0 },
                    { 37, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/037.png", "Goupix", 0 },
                    { 38, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/038.png", "Feunard", 1 },
                    { 39, 4, 6, 8, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/039.png", "Rondoudou", 0 },
                    { 40, 6, 8, 9, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/040.png", "Grodoudou", 0 },
                    { 41, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/041.png", "Nosferapti", 0 },
                    { 42, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/042.png", "Nosferalto", 0 },
                    { 43, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/043.png", "Mystherbe", 0 },
                    { 44, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/044.png", "Ortide", 0 },
                    { 45, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/045.png", "Rafflesia", 0 },
                    { 46, 5, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/046.png", "Paras", 0 },
                    { 47, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/047.png", "Parasect", 0 },
                    { 48, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/048.png", "Mimitoss", 0 },
                    { 49, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/049.png", "Aéromite", 0 },
                    { 50, 4, 2, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/050.png", "Taupiqueur", 0 },
                    { 51, 6, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/051.png", "Triopikeur", 0 },
                    { 52, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/052.png", "Miaouss", 0 },
                    { 53, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/053.png", "Persian", 0 },
                    { 54, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/054.png", "Psykokwak", 0 },
                    { 55, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/055.png", "Akwakwak", 1 },
                    { 56, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/056.png", "Férosinge", 0 },
                    { 57, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/057.png", "Colossinge", 0 },
                    { 58, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/058.png", "Caninos", 0 },
                    { 59, 8, 7, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/059.png", "Arcanin", 1 },
                    { 60, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/060.png", "Ptitard", 0 },
                    { 61, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/061.png", "Têtarte", 0 },
                    { 62, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/062.png", "Tartard", 1 },
                    { 63, 5, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/063.png", "Abra", 0 },
                    { 64, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/064.png", "Kadabra", 0 },
                    { 65, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/065.png", "Alakazam", 1 },
                    { 66, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/066.png", "Machoc", 0 },
                    { 67, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/067.png", "Machopeur", 0 },
                    { 68, 8, 7, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/068.png", "Mackogneur", 1 },
                    { 69, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/069.png", "Chétiflor", 0 },
                    { 70, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/070.png", "Boustiflor", 0 },
                    { 71, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/071.png", "Empiflor", 0 },
                    { 72, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/072.png", "Tentacool", 0 },
                    { 73, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/073.png", "Tentacruel", 1 },
                    { 74, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/074.png", "Racaillou", 0 },
                    { 75, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/075.png", "Gravalanch", 0 },
                    { 76, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/076.png", "Grolem", 0 },
                    { 77, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/077.png", "Ponyta", 0 },
                    { 78, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/078.png", "Galopa", 1 },
                    { 79, 4, 5, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/079.png", "Ramoloss", 0 },
                    { 80, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/080.png", "Flagadoss", 0 },
                    { 81, 5, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/081.png", "Magnéti", 0 },
                    { 82, 7, 5, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/082.png", "Magnéton", 0 },
                    { 83, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/083.png", "Canarticho", 0 },
                    { 84, 5, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/084.png", "Doduo", 0 },
                    { 85, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/085.png", "Dodrio", 0 },
                    { 86, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/086.png", "Otaria", 0 },
                    { 87, 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/087.png", "Lamantine", 0 },
                    { 88, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/088.png", "Tadmorv", 0 },
                    { 89, 7, 7, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/089.png", "Grotadmorv", 1 },
                    { 90, 4, 3, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/090.png", "Kokiyas", 0 },
                    { 91, 7, 5, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/091.png", "Crustabri", 1 },
                    { 92, 5, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/092.png", "Fantominus", 0 },
                    { 93, 7, 5, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/093.png", "Spectrum", 0 },
                    { 94, 8, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/094.png", "Ectoplasma", 1 },
                    { 95, 3, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/095.png", "Onix", 0 },
                    { 96, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/096.png", "Soporifik", 0 },
                    { 97, 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/097.png", "Hypnomade", 0 },
                    { 98, 5, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/098.png", "Krabby", 0 },
                    { 99, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/099.png", "Krabboss", 0 },
                    { 100, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/100.png", "Voltorbe", 0 },
                    { 101, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/101.png", "Électrode", 0 },
                    { 102, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/102.png", "Noeunoeuf", 0 },
                    { 103, 9, 8, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/103.png", "Noadkoko", 1 },
                    { 104, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/104.png", "Osselait", 0 },
                    { 105, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/105.png", "Ossatueur", 0 },
                    { 106, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/106.png", "Kicklee", 0 },
                    { 107, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/107.png", "Tygnon", 0 },
                    { 108, 5, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/108.png", "Excelangue", 0 },
                    { 109, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/109.png", "Smogo", 0 },
                    { 110, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/110.png", "Smogogo", 0 },
                    { 111, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/111.png", "Rhinocorne", 0 },
                    { 112, 7, 7, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/112.png", "Rhinoféros", 0 },
                    { 113, 2, 6, 10, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/113.png", "Leveinard", 0 },
                    { 114, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/114.png", "Saquedeneu", 0 },
                    { 115, 5, 6, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/115.png", "Kangourex", 0 },
                    { 116, 4, 3, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/116.png", "Hypotrempe", 0 },
                    { 117, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/117.png", "Hypocéan", 0 },
                    { 118, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/118.png", "Poissirène", 0 },
                    { 119, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/119.png", "Poissoroy", 0 },
                    { 120, 5, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/120.png", "Stari", 0 },
                    { 121, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/121.png", "Staross", 1 },
                    { 122, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/122.png", "M. Mime", 0 },
                    { 123, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/123.png", "Insécateur", 1 },
                    { 124, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/124.png", "Lippoutou", 0 },
                    { 125, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/125.png", "Élektek", 0 },
                    { 126, 8, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/126.png", "Magmar", 0 },
                    { 127, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/127.png", "Scarabrute", 1 },
                    { 128, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/128.png", "Tauros", 0 },
                    { 129, 1, 1, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/129.png", "Magicarpe", 0 },
                    { 130, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/130.png", "Léviator", 1 },
                    { 131, 7, 8, 9, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/131.png", "Lokhlass", 1 },
                    { 132, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/132.png", "Métamorph", 0 },
                    { 133, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/133.png", "Évoli", 0 },
                    { 134, 7, 8, 9, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/134.png", "Aquali", 1 },
                    { 135, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/135.png", "Voltali", 1 },
                    { 136, 9, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/136.png", "Pyroli", 1 },
                    { 137, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/137.png", "Porygon", 0 },
                    { 138, 5, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/138.png", "Amonita", 0 },
                    { 139, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/139.png", "Amonistar", 0 },
                    { 140, 5, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/140.png", "Kabuto", 0 },
                    { 141, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/141.png", "Kabutops", 0 },
                    { 142, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/142.png", "Ptéra", 1 },
                    { 143, 7, 8, 10, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/143.png", "Ronflex", 1 },
                    { 144, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/144.png", "Artikodin", 3 },
                    { 145, 9, 8, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/145.png", "Électhor", 3 },
                    { 146, 9, 8, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/146.png", "Sulfura", 3 },
                    { 147, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/147.png", "Minidraco", 0 },
                    { 148, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/148.png", "Draco", 0 },
                    { 149, 9, 8, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/149.png", "Dracolosse", 2 },
                    { 150, 10, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/150.png", "Mewtwo", 3 },
                    { 151, 8, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/151.png", "Mew", 3 },
                    { 152, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/152.png", "Germignon", 0 },
                    { 153, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/153.png", "Macronium", 0 },
                    { 154, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/154.png", "Méganium", 1 },
                    { 155, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/155.png", "Héricendre", 0 },
                    { 156, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/156.png", "Feurisson", 0 },
                    { 157, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/157.png", "Typhlosion", 1 },
                    { 158, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/158.png", "Kaiminus", 0 },
                    { 159, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/159.png", "Crocrodil", 0 },
                    { 160, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/160.png", "Aligatueur", 1 },
                    { 161, 3, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/161.png", "Fouinette", 0 },
                    { 162, 5, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/162.png", "Fouinar", 0 },
                    { 163, 3, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/163.png", "Hoothoot", 0 },
                    { 164, 5, 6, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/164.png", "Noarfang", 0 },
                    { 165, 2, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/165.png", "Coxy", 0 },
                    { 166, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/166.png", "Coxyclaque", 0 },
                    { 167, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/167.png", "Mimigal", 0 },
                    { 168, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/168.png", "Migalos", 0 },
                    { 169, 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/169.png", "Nostenfer", 1 },
                    { 170, 4, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/170.png", "Loupio", 0 },
                    { 171, 5, 6, 8, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/171.png", "Lanturn", 0 },
                    { 172, 3, 2, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/172.png", "Pichu", 0 },
                    { 173, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/173.png", "Mélo", 0 },
                    { 174, 3, 4, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/174.png", "Toudoudou", 0 },
                    { 175, 2, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/175.png", "Togepi", 0 },
                    { 176, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/176.png", "Togetic", 0 },
                    { 177, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/177.png", "Natu", 0 },
                    { 178, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/178.png", "Xatu", 0 },
                    { 179, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/179.png", "Wattouat", 0 },
                    { 180, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/180.png", "Lainergie", 0 },
                    { 181, 8, 7, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/181.png", "Pharamp", 1 },
                    { 182, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/182.png", "Joliflor", 0 },
                    { 183, 2, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/183.png", "Marill", 0 },
                    { 184, 4, 6, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/184.png", "Azumarill", 0 },
                    { 185, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/185.png", "Simularbre", 0 },
                    { 186, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/186.png", "Tarpaud", 1 },
                    { 187, 3, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/187.png", "Granivol", 0 },
                    { 188, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/188.png", "Floravol", 0 },
                    { 189, 4, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/189.png", "Cotovol", 0 },
                    { 190, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/190.png", "Capumain", 0 },
                    { 191, 2, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/191.png", "Tournegrin", 0 },
                    { 192, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/192.png", "Héliatronc", 0 },
                    { 193, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/193.png", "Yanma", 0 },
                    { 194, 3, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/194.png", "Axoloto", 0 },
                    { 195, 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/195.png", "Maraiste", 0 },
                    { 196, 8, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/196.png", "Mentali", 1 },
                    { 197, 5, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/197.png", "Noctali", 1 },
                    { 198, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/198.png", "Cornèbre", 0 },
                    { 199, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/199.png", "Roigada", 0 },
                    { 200, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/200.png", "Feuforêve", 0 },
                    { 201, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/201.png", "Zarbi", 0 },
                    { 202, 3, 6, 10, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/202.png", "Qulbutoké", 0 },
                    { 203, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/203.png", "Girafarig", 0 },
                    { 204, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/204.png", "Pomdepik", 0 },
                    { 205, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/205.png", "Foretress", 0 },
                    { 206, 5, 6, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/206.png", "Insolourdo", 0 },
                    { 207, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/207.png", "Scorplane", 0 },
                    { 208, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/208.png", "Steelix", 1 },
                    { 209, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/209.png", "Snubbull", 0 },
                    { 210, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/210.png", "Granbull", 0 },
                    { 211, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/211.png", "Qwilfish", 0 },
                    { 212, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/212.png", "Cizayox", 1 },
                    { 213, 1, 1, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/213.png", "Caratroc", 1 },
                    { 214, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/214.png", "Scarhino", 1 },
                    { 215, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/215.png", "Farfuret", 0 },
                    { 216, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/216.png", "Teddiursa", 0 },
                    { 217, 8, 7, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/217.png", "Ursaring", 1 },
                    { 218, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/218.png", "Limagma", 0 },
                    { 219, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/219.png", "Volcaropod", 0 },
                    { 220, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/220.png", "Marcacrin", 0 },
                    { 221, 6, 6, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/221.png", "Cochignon", 0 },
                    { 222, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/222.png", "Corayon", 0 },
                    { 223, 5, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/223.png", "Rémoraid", 0 },
                    { 224, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/224.png", "Octillery", 0 },
                    { 225, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/225.png", "Cadoizo", 0 },
                    { 226, 5, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/226.png", "Démanta", 0 },
                    { 227, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/227.png", "Airmure", 0 },
                    { 228, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/228.png", "Malosse", 0 },
                    { 229, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/229.png", "Démolosse", 1 },
                    { 230, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/230.png", "Hyporoi", 1 },
                    { 231, 4, 5, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/231.png", "Phanpy", 0 },
                    { 232, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/232.png", "Donphan", 1 },
                    { 233, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/233.png", "Porygon2", 1 },
                    { 234, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/234.png", "Cerfrousse", 0 },
                    { 235, 2, 3, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/235.png", "Queulorior", 0 },
                    { 236, 3, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/236.png", "Debugant", 0 },
                    { 237, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/237.png", "Kapoera", 0 },
                    { 238, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/238.png", "Lippouti", 0 },
                    { 239, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/239.png", "Élekid", 0 },
                    { 240, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/240.png", "Magby", 0 },
                    { 241, 5, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/241.png", "Écrémeuh", 0 },
                    { 242, 3, 6, 10, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/242.png", "Leuphorie", 1 },
                    { 243, 8, 7, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/243.png", "Raikou", 3 },
                    { 244, 8, 8, 8, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/244.png", "Entei", 3 },
                    { 245, 7, 7, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/245.png", "Suicune", 3 },
                    { 246, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/246.png", "Embrylex", 0 },
                    { 247, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/247.png", "Ymphect", 0 },
                    { 248, 9, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/248.png", "Tyranocif", 2 },
                    { 249, 7, 7, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/249.png", "Lugia", 3 },
                    { 250, 10, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/250.png", "Ho-Oh", 3 },
                    { 251, 8, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/251.png", "Celebi", 3 },
                    { 252, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/252.png", "Arcko", 0 },
                    { 253, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/253.png", "Massko", 0 },
                    { 254, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/254.png", "Jungko", 1 },
                    { 255, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/255.png", "Poussifeu", 0 },
                    { 256, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/256.png", "Galifeu", 0 },
                    { 257, 9, 7, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/257.png", "Braségali", 1 },
                    { 258, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/258.png", "Gobou", 0 },
                    { 259, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/259.png", "Flobio", 0 },
                    { 260, 8, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/260.png", "Laggron", 1 },
                    { 261, 3, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/261.png", "Medhyèna", 0 },
                    { 262, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/262.png", "Grahyèna", 0 },
                    { 263, 2, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/263.png", "Zigzaton", 0 },
                    { 264, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/264.png", "Linéon", 0 },
                    { 265, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/265.png", "Chenipotte", 0 },
                    { 266, 2, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/266.png", "Armulys", 0 },
                    { 267, 7, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/267.png", "Charmillon", 0 },
                    { 268, 2, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/268.png", "Blindalys", 0 },
                    { 269, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/269.png", "Papinox", 0 },
                    { 270, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/270.png", "Nénupiot", 0 },
                    { 271, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/271.png", "Lombre", 0 },
                    { 272, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/272.png", "Ludicolo", 0 },
                    { 273, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/273.png", "Grainipiot", 0 },
                    { 274, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/274.png", "Pifeuil", 0 },
                    { 275, 8, 7, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/275.png", "Tengalice", 0 },
                    { 276, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/276.png", "Nirondelle", 0 },
                    { 277, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/277.png", "Hélédelle", 0 },
                    { 278, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/278.png", "Goélise", 0 },
                    { 279, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/279.png", "Bekipan", 0 },
                    { 280, 3, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/280.png", "Tarsal", 0 },
                    { 281, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/281.png", "Kirlia", 0 },
                    { 282, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/282.png", "Gardevoir", 1 },
                    { 283, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/283.png", "Arakdo", 0 },
                    { 284, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/284.png", "Maskadra", 0 },
                    { 285, 3, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/285.png", "Balignon", 0 },
                    { 286, 8, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/286.png", "Chapignon", 0 },
                    { 287, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/287.png", "Parecool", 0 },
                    { 288, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/288.png", "Vigoroth", 0 },
                    { 289, 10, 10, 10, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/289.png", "Monaflèmit", 2 },
                    { 290, 3, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/290.png", "Ningale", 0 },
                    { 291, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/291.png", "Ninjask", 0 },
                    { 292, 5, 3, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/292.png", "Munja", 0 },
                    { 293, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/293.png", "Chuchmur", 0 },
                    { 294, 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/294.png", "Ramboum", 0 },
                    { 295, 7, 7, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/295.png", "Brouhabam", 0 },
                    { 296, 3, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/296.png", "Makuhita", 0 },
                    { 297, 6, 8, 10, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/297.png", "Hariyama", 0 },
                    { 298, 2, 2, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/298.png", "Azurill", 0 },
                    { 299, 4, 3, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/299.png", "Tarinor", 0 },
                    { 300, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/300.png", "Skitty", 0 },
                    { 301, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/301.png", "Delcatty", 0 },
                    { 302, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/302.png", "Ténéfix", 0 },
                    { 303, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/303.png", "Mysdibule", 0 },
                    { 304, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/304.png", "Galekid", 0 },
                    { 305, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/305.png", "Galegon", 0 },
                    { 306, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/306.png", "Galeking", 1 },
                    { 307, 3, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/307.png", "Méditikka", 0 },
                    { 308, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/308.png", "Charmina", 0 },
                    { 309, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/309.png", "Dynavolt", 0 },
                    { 310, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/310.png", "Élecsprint", 0 },
                    { 311, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/311.png", "Posipi", 0 },
                    { 312, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/312.png", "Négapi", 0 },
                    { 313, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/313.png", "Muciole", 0 },
                    { 314, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/314.png", "Lumivole", 0 },
                    { 315, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/315.png", "Rosélia", 0 },
                    { 316, 3, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/316.png", "Gloupti", 0 },
                    { 317, 6, 6, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/317.png", "Avaltout", 0 },
                    { 318, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/318.png", "Carvanha", 0 },
                    { 319, 9, 7, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/319.png", "Sharpedo", 0 },
                    { 320, 6, 8, 9, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/320.png", "Wailmer", 0 },
                    { 321, 7, 8, 10, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/321.png", "Wailord", 1 },
                    { 322, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/322.png", "Chamallot", 0 },
                    { 323, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/323.png", "Camérupt", 0 },
                    { 324, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/324.png", "Chartor", 0 },
                    { 325, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/325.png", "Spoink", 0 },
                    { 326, 5, 5, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/326.png", "Groret", 0 },
                    { 327, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/327.png", "Spinda", 0 },
                    { 328, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/328.png", "Kraknoix", 0 },
                    { 329, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/329.png", "Vibraninf", 0 },
                    { 330, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/330.png", "Libégon", 1 },
                    { 331, 7, 5, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/331.png", "Cacnea", 0 },
                    { 332, 9, 7, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/332.png", "Cacturne", 0 },
                    { 333, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/333.png", "Tylton", 0 },
                    { 334, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/334.png", "Altaria", 0 },
                    { 335, 7, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/335.png", "Mangriff", 0 },
                    { 336, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/336.png", "Séviper", 0 },
                    { 337, 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/337.png", "Séléroc", 0 },
                    { 338, 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/338.png", "Solaroc", 0 },
                    { 339, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/339.png", "Barloche", 0 },
                    { 340, 6, 6, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/340.png", "Barbicha", 0 },
                    { 341, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/341.png", "Écrapince", 0 },
                    { 342, 8, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/342.png", "Colhomard", 0 },
                    { 343, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/343.png", "Balbuto", 0 },
                    { 344, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/344.png", "Kaorine", 1 },
                    { 345, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/345.png", "Lilia", 0 },
                    { 346, 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/346.png", "Vacilys", 0 },
                    { 347, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/347.png", "Anorith", 0 },
                    { 348, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/348.png", "Armaldo", 0 },
                    { 349, 1, 1, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/349.png", "Barpau", 0 },
                    { 350, 6, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/350.png", "Milobellus", 1 },
                    { 351, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/351.png", "Morphéo", 0 },
                    { 352, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/352.png", "Kecleon", 0 },
                    { 353, 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/353.png", "Polichombr", 0 },
                    { 354, 8, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/354.png", "Branette", 0 },
                    { 355, 3, 2, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/355.png", "Skelénox", 0 },
                    { 356, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/356.png", "Téraclope", 0 },
                    { 357, 6, 6, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/357.png", "Tropius", 0 },
                    { 358, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/358.png", "Éoko", 0 },
                    { 359, 8, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/359.png", "Absol", 0 },
                    { 360, 2, 4, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/360.png", "Okéoké", 0 },
                    { 361, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/361.png", "Stalgamin", 0 },
                    { 362, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/362.png", "Oniglali", 0 },
                    { 363, 4, 4, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/363.png", "Obalie", 0 },
                    { 364, 5, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/364.png", "Phogleur", 0 },
                    { 365, 7, 7, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/365.png", "Kaimorse", 1 },
                    { 366, 6, 4, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/366.png", "Coquiperl", 0 },
                    { 367, 8, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/367.png", "Serpang", 0 },
                    { 368, 8, 6, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/368.png", "Rosabyss", 0 },
                    { 369, 5, 6, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/369.png", "Relicanth", 0 },
                    { 370, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/370.png", "Lovdisc", 0 },
                    { 371, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/371.png", "Draby", 0 },
                    { 372, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/372.png", "Drackhaus", 0 },
                    { 373, 10, 8, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/373.png", "Drattak", 2 },
                    { 374, 4, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/374.png", "Terhal", 0 },
                    { 375, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/375.png", "Métang", 0 },
                    { 376, 9, 7, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/376.png", "Métalosse", 2 },
                    { 377, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/377.png", "Regirock", 3 },
                    { 378, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/378.png", "Regice", 3 },
                    { 379, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/379.png", "Registeel", 3 },
                    { 380, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/380.png", "Latias", 3 },
                    { 381, 9, 7, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/381.png", "Latios", 3 },
                    { 382, 10, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/382.png", "Kyogre", 3 },
                    { 383, 10, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/383.png", "Groudon", 3 },
                    { 384, 10, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/384.png", "Rayquaza", 3 },
                    { 385, 8, 8, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/385.png", "Jirachi", 3 },
                    { 386, 10, 6, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/386.png", "Deoxys", 3 },
                    { 387, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/387.png", "Tortipouss", 0 },
                    { 388, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/388.png", "Boskara", 0 },
                    { 389, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/389.png", "Torterra", 1 },
                    { 390, 5, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/390.png", "Ouisticram", 0 },
                    { 391, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/391.png", "Chimpenfeu", 0 },
                    { 392, 8, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/392.png", "Simiabraz", 1 },
                    { 393, 4, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/393.png", "Tiplouf", 0 },
                    { 394, 6, 5, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/394.png", "Prinplouf", 0 },
                    { 395, 8, 7, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/395.png", "Pingoléon", 1 },
                    { 396, 3, 3, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/396.png", "Étourmi", 0 },
                    { 397, 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/397.png", "Étourvol", 0 },
                    { 398, 7, 6, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/398.png", "Étouraptor", 0 },
                    { 399, 3, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/399.png", "Keunotor", 0 },
                    { 400, 6, 6, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/400.png", "Castorno", 0 }
                });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "GoldLoss", "GoldWin" },
                values: new object[] { 10, 50 });

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CardID",
                value: 149);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CardID",
                value: 150);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CardID",
                value: 65);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CardID",
                value: 282);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 5,
                column: "CardID",
                value: 39);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 6,
                column: "CardID",
                value: 6);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 7,
                column: "CardID",
                value: 282);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 8,
                column: "CardID",
                value: 39);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 9,
                column: "CardID",
                value: 6);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CardId",
                value: 149);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CardId",
                value: 384);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CardId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CardId",
                value: 150);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CardId",
                value: 282);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CardId",
                value: 143);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CardId",
                value: 65);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CardId",
                value: 95);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 400);

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
                columns: new[] { "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 5, 8, "https://pm1.aminoapps.com/6906/f456d54f84291a3e3a9532251214cda80cbef906r1-335-431v2_hq.jpg", "Dracolosse", 2 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 10, 9, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/384.png", "Rayquaza", 3 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 2, 1, 1, "https://upload.wikimedia.org/wikipedia/en/2/22/Pok%C3%A9mon_Jigglypuff_art.png", "Rondoudou", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 8, 6, 4, "https://e7.pngegg.com/pngimages/993/391/png-clipart-pokemon-character-illustration-pokemon-x-and-y-pokemon-go-pokemon-black-white-mewtwo-pokemon-go-purple-mammal.png", "Mewtwo", 2 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Attack", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 7, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/282.png", "Gardevoir", 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 4, 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/065.png", "Alakazam", 0 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Attack", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/095.png", "Onix", 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 1, 2, 9, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/143.png", "Ronflex" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 5, 2, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/151.png", "Mew", 3 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Attack", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 6, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006_f2.png", "Dracofeu", 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Attack", "Health", "ImageUrl", "Name" },
                values: new object[] { 3, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/025.png", "Pikachu" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 2, 1, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/133.png", "Evoli" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 1, 1, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/129.png", "Magicarpe" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 5, 4, 4, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/448.png", "Lucario", 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 4, 3, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/471.png", "Givrali", 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 6, 5, 6, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/009.png", "Tortank", 2 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 5, 5, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/003.png", "Florizarre", 2 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 7, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/658.png", "Amphinobi", 2 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 9, 10, 9, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/493.png", "Arceus", 3 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[] { 8, 8, 8, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/483.png", "Dialga", 3 });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "GoldLoss", "GoldWin" },
                values: new object[] { 5, 20 });

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CardID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CardID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CardID",
                value: 6);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CardID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 5,
                column: "CardID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 6,
                column: "CardID",
                value: 10);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 7,
                column: "CardID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 8,
                column: "CardID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 9,
                column: "CardID",
                value: 10);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CardId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CardId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CardId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CardId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CardId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CardId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CardId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "cardPowers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CardId",
                value: 7);
        }
    }
}
