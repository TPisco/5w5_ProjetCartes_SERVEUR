using System;
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
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

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
                name: "Power",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasValue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Power", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ELO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StartingCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StartingCards_Cards_CardID",
                        column: x => x.CardID,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cardPowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    PowerId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardPowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cardPowers_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cardPowers_Power_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Power",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decks_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Mana = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayersData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlayersData_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedCard",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    playerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedCard", x => x.id);
                    table.ForeignKey(
                        name: "FK_OwnedCard_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedCard_Players_playerId",
                        column: x => x.playerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPlayerATurn = table.Column<bool>(type: "bit", nullable: false),
                    IsMatchCompleted = table.Column<bool>(type: "bit", nullable: false),
                    WinnerUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserBId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerDataAId = table.Column<int>(type: "int", nullable: false),
                    PlayerDataBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_MatchPlayersData_PlayerDataAId",
                        column: x => x.PlayerDataAId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_MatchPlayersData_PlayerDataBId",
                        column: x => x.PlayerDataBId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayableCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    MatchPlayerDataId = table.Column<int>(type: "int", nullable: true),
                    MatchPlayerDataId1 = table.Column<int>(type: "int", nullable: true),
                    MatchPlayerDataId2 = table.Column<int>(type: "int", nullable: true),
                    MatchPlayerDataId3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayableCard_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId",
                        column: x => x.MatchPlayerDataId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId1",
                        column: x => x.MatchPlayerDataId1,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId2",
                        column: x => x.MatchPlayerDataId2,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCard_MatchPlayersData_MatchPlayerDataId3",
                        column: x => x.MatchPlayerDataId3,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeckCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnedCardid = table.Column<int>(type: "int", nullable: false),
                    DeckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckCards_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckCards_OwnedCard_OwnedCardid",
                        column: x => x.OwnedCardid,
                        principalTable: "OwnedCard",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11111111-1111-1111-1111-111111111112", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "b2f24ebf-0d64-42b0-9fb8-8463963a3669", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEGC/HqrC33tKzpQCLxLnO9+0uM92q89EOpZ/wcdzM5LjGTa0PqynKxk8KWTfMHbi9Q==", null, false, "a42f2c1d-8daf-46f8-a4c9-e6f689bdca75", false, "admin@admin.com" },
                    { "User1Id", 0, "7f74a83d-ebd1-4d91-b534-008b45b1c6d2", null, false, false, null, null, null, null, null, false, "b25c5a35-3ce4-4d07-8eb1-53eb8e11085f", false, null },
                    { "User2Id", 0, "b4fe762a-2e3d-410e-989d-ae1c8368c5df", null, false, false, null, null, null, null, null, false, "8acbddbc-4c18-4b2f-866d-eb83e63c1641", false, null }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Health", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 4, 3, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png", "Bulbizarre" },
                    { 2, 5, 4, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/002.png", "Herbizarre" },
                    { 3, 6, 5, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/003.png", "Florizarre" },
                    { 4, 7, 2, 8, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/004.png", "Salamèche" },
                    { 5, 3, 3, 9, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/005.png", "Reptincel" },
                    { 6, 4, 4, 10, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/006.png", "Dracaufeu" },
                    { 7, 5, 5, 4, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/007.png", "Carapuce" },
                    { 8, 6, 2, 5, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/008.png", "Carabaffe" },
                    { 9, 7, 3, 6, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/009.png", "Tortank" },
                    { 10, 3, 4, 7, "https://assets.pokemon.com/assets/cms2/img/pokedex/full/010.png", "Chenipan" },
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

            migrationBuilder.InsertData(
                table: "GameConfigs",
                columns: new[] { "id", "QtManaParTour", "nbCardsToDraw" },
                values: new object[] { 1, 3, 4 });

            migrationBuilder.InsertData(
                table: "Power",
                columns: new[] { "Id", "Description", "HasValue", "Icon", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Permet à une carte d’attaquer en « premier » et de ne pas recevoir de dégât si elle tue la carte de l’adversaire.", false, "🥇", "First Strike", 0 },
                    { 2, "Lorsqu’une carte défend, elle inflige X de dégâts AVANT de recevoir des dégâts. Si l’attaquant est tué par ces dégâts, l’attaque s’arrête et le défenseur ne reçoit pas de dégâts.", true, "🌹", "Thorns", 0 },
                    { 3, "Soigne les cartes alliées de X incluant elle-même AVANT d’attaquer (mais les cartes ne peuvent pas avoir plus de health qu’au départ.)", true, "💖", "Heal", 0 },
                    { 4, "Augmente la défense d'une carte de X", true, "🛡️", "Shield", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "11111111-1111-1111-1111-111111111112", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ELO", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 1000, "Test player 1", "User1Id" },
                    { 2, 1000, "Test player 2", "User2Id" }
                });

            migrationBuilder.InsertData(
                table: "StartingCards",
                columns: new[] { "Id", "CardID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 4 },
                    { 3, 6 },
                    { 4, 5 },
                    { 5, 3 },
                    { 6, 10 },
                    { 7, 5 },
                    { 8, 3 },
                    { 9, 10 }
                });

            migrationBuilder.InsertData(
                table: "cardPowers",
                columns: new[] { "Id", "CardId", "PowerId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, 0 },
                    { 2, 2, 2, 3 },
                    { 3, 3, 3, 2 },
                    { 4, 4, 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cardPowers_CardId",
                table: "cardPowers",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_cardPowers_PowerId",
                table: "cardPowers",
                column: "PowerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckCards_DeckId",
                table: "DeckCards",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckCards_OwnedCardid",
                table: "DeckCards",
                column: "OwnedCardid");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_PlayerId",
                table: "Decks",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerDataAId",
                table: "Matches",
                column: "PlayerDataAId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerDataBId",
                table: "Matches",
                column: "PlayerDataBId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayersData_PlayerId",
                table: "MatchPlayersData",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCard_CardId",
                table: "OwnedCard",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCard_playerId",
                table: "OwnedCard",
                column: "playerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_CardId",
                table: "PlayableCard",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId",
                table: "PlayableCard",
                column: "MatchPlayerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId1",
                table: "PlayableCard",
                column: "MatchPlayerDataId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId2",
                table: "PlayableCard",
                column: "MatchPlayerDataId2");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCard_MatchPlayerDataId3",
                table: "PlayableCard",
                column: "MatchPlayerDataId3");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StartingCards_CardID",
                table: "StartingCards",
                column: "CardID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "cardPowers");

            migrationBuilder.DropTable(
                name: "DeckCards");

            migrationBuilder.DropTable(
                name: "GameConfigs");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "PlayableCard");

            migrationBuilder.DropTable(
                name: "StartingCards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Power");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "OwnedCard");

            migrationBuilder.DropTable(
                name: "MatchPlayersData");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
