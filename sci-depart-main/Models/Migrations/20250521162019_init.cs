using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8864f433-545b-4f0b-bb4c-c8e35bbbe7f0", "AQAAAAIAAYagAAAAEIrC6uEx0LW8oVPDMouAmCWO0ujMEKJ8pZZXbnldWXYlik+Bdq2tFc5AElJ1y2n3Mg==", "0982798a-e636-4618-a34e-d7a3b4d447b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "18e32594-4c12-452a-96b5-d4c21caaed38", "a3602232-e742-4391-ba31-6f53d9b2ebbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4a8b9588-eef6-443c-bf68-fa7f7bfbb5cd", "ce570975-3e88-4581-8a69-6c9c177bec05" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 4, 3, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png", "Bulbizarre" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 5, 4, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/002.png", "Herbizarre" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 6, 5, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/003.png", "Florizarre" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 7, 2, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/004.png", "Salamèche" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 3, 3, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/005.png", "Reptincel" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 4, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/006.png", "Dracaufeu" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 5, 5, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/007.png", "Carapuce" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Attack", "Health", "ImageUrl", "Name" },
                values: new object[] { 6, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/008.png", "Carabaffe" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 7, 3, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/009.png", "Tortank" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 3, 4, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/010.png", "Chenipan" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 11, 4, 5, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/011.png", "Chrysacier" },
                    { 12, 5, 2, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/012.png", "Papilusion" },
                    { 13, 6, 3, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/013.png", "Aspicot" },
                    { 14, 7, 4, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/014.png", "Coconfort" },
                    { 15, 3, 5, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/015.png", "Dardargnan" },
                    { 16, 4, 2, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/016.png", "Roucool" },
                    { 17, 5, 3, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/017.png", "Roucoups" },
                    { 18, 6, 4, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/018.png", "Roucarnage" },
                    { 19, 7, 5, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/019.png", "Rattata" },
                    { 20, 3, 2, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/020.png", "Rattatac" },
                    { 21, 4, 3, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/021.png", "Piafabec" },
                    { 22, 5, 4, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/022.png", "Rapasdepic" },
                    { 23, 6, 5, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/023.png", "Abo" },
                    { 24, 7, 2, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/024.png", "Arbok" },
                    { 25, 3, 3, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/025.png", "Pikachu" },
                    { 26, 4, 4, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/026.png", "Raichu" },
                    { 27, 5, 5, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/027.png", "Sabelette" },
                    { 28, 6, 2, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/028.png", "Sablaireau" },
                    { 29, 7, 3, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/029.png", "Nidoran♀" },
                    { 30, 3, 4, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/030.png", "Nidorina" },
                    { 31, 4, 5, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/031.png", "Nidoqueen" },
                    { 32, 5, 2, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/032.png", "Nidoran♂" },
                    { 33, 6, 3, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/033.png", "Nidorino" },
                    { 34, 7, 4, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/034.png", "Nidoking" },
                    { 35, 3, 5, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/035.png", "Mélofée" },
                    { 36, 4, 2, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/036.png", "Mélodelfe" },
                    { 37, 5, 3, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/037.png", "Goupix" },
                    { 38, 6, 4, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/038.png", "Feunard" },
                    { 39, 7, 5, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/039.png", "Rondoudou" },
                    { 40, 3, 2, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/040.png", "Grodoudou" },
                    { 41, 4, 3, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/041.png", "Nosferapti" },
                    { 42, 5, 4, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/042.png", "Nosferalto" },
                    { 43, 6, 5, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/043.png", "Mystherbe" },
                    { 44, 7, 2, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/044.png", "Ortide" },
                    { 45, 3, 3, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/045.png", "Rafflesia" },
                    { 46, 4, 4, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/046.png", "Paras" },
                    { 47, 5, 5, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/047.png", "Parasect" },
                    { 48, 6, 2, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/048.png", "Mimitoss" },
                    { 49, 7, 3, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/049.png", "Aéromite" },
                    { 50, 3, 4, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/050.png", "Taupiqueur" },
                    { 51, 4, 5, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/051.png", "Triopikeur" },
                    { 52, 5, 2, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/052.png", "Miaouss" },
                    { 53, 6, 3, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/053.png", "Persian" },
                    { 54, 7, 4, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/054.png", "Psykokwak" },
                    { 55, 3, 5, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/055.png", "Akwakwak" },
                    { 56, 4, 2, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/056.png", "Férosinge" },
                    { 57, 5, 3, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/057.png", "Colossinge" },
                    { 58, 6, 4, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/058.png", "Caninos" },
                    { 59, 7, 5, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/059.png", "Arcanin" },
                    { 60, 3, 2, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/060.png", "Ptitard" },
                    { 61, 4, 3, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/061.png", "Têtarte" },
                    { 62, 5, 4, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/062.png", "Tartard" },
                    { 63, 6, 5, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/063.png", "Abra" },
                    { 64, 7, 2, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/064.png", "Kadabra" },
                    { 65, 3, 3, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/065.png", "Alakazam" },
                    { 66, 4, 4, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/066.png", "Machoc" },
                    { 67, 5, 5, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/067.png", "Machopeur" },
                    { 68, 6, 2, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/068.png", "Mackogneur" },
                    { 69, 7, 3, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/069.png", "Chétiflor" },
                    { 70, 3, 4, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/070.png", "Boustiflor" },
                    { 71, 4, 5, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/071.png", "Empiflor" },
                    { 72, 5, 2, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/072.png", "Tentacool" },
                    { 73, 6, 3, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/073.png", "Tentacruel" },
                    { 74, 7, 4, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/074.png", "Racaillou" },
                    { 75, 3, 5, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/075.png", "Gravalanch" },
                    { 76, 4, 2, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/076.png", "Grolem" },
                    { 77, 5, 3, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/077.png", "Ponyta" },
                    { 78, 6, 4, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/078.png", "Galopa" },
                    { 79, 7, 5, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/079.png", "Ramoloss" },
                    { 80, 3, 2, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/080.png", "Flagadoss" },
                    { 81, 4, 3, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/081.png", "Magnéti" },
                    { 82, 5, 4, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/082.png", "Magnéton" },
                    { 83, 6, 5, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/083.png", "Canarticho" },
                    { 84, 7, 2, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/084.png", "Doduo" },
                    { 85, 3, 3, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/085.png", "Dodrio" },
                    { 86, 4, 4, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/086.png", "Otaria" },
                    { 87, 5, 5, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/087.png", "Lamantine" },
                    { 88, 6, 2, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/088.png", "Tadmorv" },
                    { 89, 7, 3, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/089.png", "Grotadmorv" },
                    { 90, 3, 4, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/090.png", "Kokiyas" },
                    { 91, 4, 5, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/091.png", "Crustabri" },
                    { 92, 5, 2, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/092.png", "Fantominus" },
                    { 93, 6, 3, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/093.png", "Spectrum" },
                    { 94, 7, 4, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/094.png", "Ectoplasma" },
                    { 95, 3, 5, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/095.png", "Onix" },
                    { 96, 4, 2, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/096.png", "Soporifik" },
                    { 97, 5, 3, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/097.png", "Hypnomade" },
                    { 98, 6, 4, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/098.png", "Krabby" },
                    { 99, 7, 5, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/099.png", "Krabboss" },
                    { 100, 3, 2, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/100.png", "Voltorbe" },
                    { 101, 4, 3, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/101.png", "Électrode" },
                    { 102, 5, 4, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/102.png", "Noeunoeuf" },
                    { 103, 6, 5, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/103.png", "Noadkoko" },
                    { 104, 7, 2, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/104.png", "Osselait" },
                    { 105, 3, 3, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/105.png", "Ossatueur" },
                    { 106, 4, 4, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/106.png", "Kicklee" },
                    { 107, 5, 5, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/107.png", "Tygnon" },
                    { 108, 6, 2, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/108.png", "Excelangue" },
                    { 109, 7, 3, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/109.png", "Smogo" },
                    { 110, 3, 4, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/110.png", "Smogogo" },
                    { 111, 4, 5, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/111.png", "Rhinocorne" },
                    { 112, 5, 2, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/112.png", "Rhinoféros" },
                    { 113, 6, 3, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/113.png", "Leveinard" },
                    { 114, 7, 4, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/114.png", "Saquedeneu" },
                    { 115, 3, 5, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/115.png", "Kangourex" },
                    { 116, 4, 2, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/116.png", "Hypotrempe" },
                    { 117, 5, 3, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/117.png", "Hypocéan" },
                    { 118, 6, 4, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/118.png", "Poissirène" },
                    { 119, 7, 5, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/119.png", "Poissoroy" },
                    { 120, 3, 2, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/120.png", "Stari" },
                    { 121, 4, 3, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/121.png", "Staross" },
                    { 122, 5, 4, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/122.png", "M. Mime" },
                    { 123, 6, 5, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/123.png", "Insécateur" },
                    { 124, 7, 2, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/124.png", "Lippoutou" },
                    { 125, 3, 3, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/125.png", "Élektek" },
                    { 126, 4, 4, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/126.png", "Magmar" },
                    { 127, 5, 5, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/127.png", "Scarabrute" },
                    { 128, 6, 2, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/128.png", "Tauros" },
                    { 129, 7, 3, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/129.png", "Magicarpe" },
                    { 130, 3, 4, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/130.png", "Léviator" },
                    { 131, 4, 5, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/131.png", "Lokhlass" },
                    { 132, 5, 2, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/132.png", "Métamorph" },
                    { 133, 6, 3, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/133.png", "Évoli" },
                    { 134, 7, 4, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/134.png", "Aquali" },
                    { 135, 3, 5, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/135.png", "Voltali" },
                    { 136, 4, 2, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/136.png", "Pyroli" },
                    { 137, 5, 3, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/137.png", "Porygon" },
                    { 138, 6, 4, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/138.png", "Amonita" },
                    { 139, 7, 5, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/139.png", "Amonistar" },
                    { 140, 3, 2, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/140.png", "Kabuto" },
                    { 141, 4, 3, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/141.png", "Kabutops" },
                    { 142, 5, 4, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/142.png", "Ptéra" },
                    { 143, 6, 5, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/143.png", "Ronflex" },
                    { 144, 7, 2, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/144.png", "Artikodin" },
                    { 145, 3, 3, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/145.png", "Électhor" },
                    { 146, 4, 4, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/146.png", "Sulfura" },
                    { 147, 5, 5, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/147.png", "Minidraco" },
                    { 148, 6, 2, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/148.png", "Draco" },
                    { 149, 7, 3, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/149.png", "Dracolosse" },
                    { 150, 3, 4, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/150.png", "Mewtwo" },
                    { 151, 4, 5, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/151.png", "Mew" },
                    { 152, 5, 2, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/152.png", "Germignon" },
                    { 153, 6, 3, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/153.png", "Macronium" },
                    { 154, 7, 4, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/154.png", "Méganium" },
                    { 155, 3, 5, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/155.png", "Héricendre" },
                    { 156, 4, 2, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/156.png", "Feurisson" },
                    { 157, 5, 3, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/157.png", "Typhlosion" },
                    { 158, 6, 4, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/158.png", "Kaiminus" },
                    { 159, 7, 5, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/159.png", "Crocrodil" },
                    { 160, 3, 2, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/160.png", "Aligatueur" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04673a72-26e5-4f32-abac-238792dd60cc", "AQAAAAIAAYagAAAAEHFKT6qny7U9tWz8r+87z5IpLYx8aaZHWsZGsbvkHQ2iHQ8nT2yF22R7cM0S2EwYrw==", "00821fb0-7c4f-4a7f-ad94-b1c968938736" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "81903c0c-4f7b-4511-973d-75a36002c8c6", "d4c20aa2-04aa-410b-9011-45f092b2c412" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e610b8e4-b0ae-4cb6-9c91-4ce2d0729012", "42da8ddb-e30b-4847-b50f-b76f8db777c6" });

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
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 10, 9, 5, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/384.png", "Rayquaza" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 2, 1, 1, "https://upload.wikimedia.org/wikipedia/en/2/22/Pok%C3%A9mon_Jigglypuff_art.png", "Rondoudou" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 8, 6, 4, "https://e7.pngegg.com/pngimages/993/391/png-clipart-pokemon-character-illustration-pokemon-x-and-y-pokemon-go-pokemon-black-white-mewtwo-pokemon-go-purple-mammal.png", "Mewtwo" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 7, 5, 7, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/282.png", "Gardevoir" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 2, 2, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/065.png", "Alakazam" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 6, 4, 3, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/095.png", "Onix" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Attack", "Health", "ImageUrl", "Name" },
                values: new object[] { 1, 9, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/143.png", "Ronflex" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 5, 2, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/151.png", "Mew" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[] { 6, 2, 1, "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006_f2.png", "Dracofeu" });
        }
    }
}
