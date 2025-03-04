using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class initiale2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCard_Players_PlayerId",
                table: "OwnedCard");

            migrationBuilder.DropIndex(
                name: "IX_OwnedCard_PlayerId",
                table: "OwnedCard");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "OwnedCard",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId1",
                table: "OwnedCard",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OwnedCard",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "959561a5-3a88-46f3-8b7d-9cb43ee50b09", "AQAAAAIAAYagAAAAEM/bj8QDf98y8XL/TpI7WqLqpTjZ9nOed+5YFXDBM274PNLbdzhazvM6JtKq49osAg==", "4929b095-4862-4bab-928c-a25658c52f6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a0bf8f14-14f8-47ac-906a-ee6e9300e3a3", "e7b6062f-a09a-41fd-ab33-7946c306f8aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "654e12c5-6df4-4101-bcf2-fd55b85803f8", "955f6fc9-5ca4-461f-8517-c4f38b75e426" });

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCard_PlayerId1",
                table: "OwnedCard",
                column: "PlayerId1");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCard_UserId",
                table: "OwnedCard",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedCard_AspNetUsers_UserId",
                table: "OwnedCard",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedCard_Players_PlayerId1",
                table: "OwnedCard",
                column: "PlayerId1",
                principalTable: "Players",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCard_AspNetUsers_UserId",
                table: "OwnedCard");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedCard_Players_PlayerId1",
                table: "OwnedCard");

            migrationBuilder.DropIndex(
                name: "IX_OwnedCard_PlayerId1",
                table: "OwnedCard");

            migrationBuilder.DropIndex(
                name: "IX_OwnedCard_UserId",
                table: "OwnedCard");

            migrationBuilder.DropColumn(
                name: "PlayerId1",
                table: "OwnedCard");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OwnedCard");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "OwnedCard",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a88f2bd-0f48-4d9c-9f17-0e97be9f82c9", "AQAAAAIAAYagAAAAEIZfHufn21/cO8fESPgyCqqI470FWkQkQt3s/hB1NVallifpXEM/K7FYJamAN1yywg==", "85c6c053-5b98-4055-88c2-595536c5e434" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "55bede3e-19d7-4bf1-af38-efad017fdb68", "b60b86b5-1f94-4870-b66a-40b0efbc1af2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "82e1ed70-c26b-4442-8f3f-92708b95256b", "91f24d8e-922f-46b1-b09f-6693c0d6aeaf" });

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCard_PlayerId",
                table: "OwnedCard",
                column: "PlayerId");

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
