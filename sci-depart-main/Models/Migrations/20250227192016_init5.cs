using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StartingCards_Cards_CardId",
                table: "StartingCards");

            migrationBuilder.DropColumn(
                name: "GameConfigId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "StartingCards",
                newName: "CardID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "StartingCards",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_StartingCards_CardId",
                table: "StartingCards",
                newName: "IX_StartingCards_CardID");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "badde83b-e335-4db1-9873-61ae822d75e2", "AQAAAAIAAYagAAAAEL5bF+ROlq3rr6TyAIt6e0nPM+RYGMfWkNaZEQB+6w8n4665vxzH9EgFJHn6CYSAJA==", "bbbe45fe-482e-470f-929e-55f93eb05409" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b30d1929-15b1-47ba-9bec-def3ab0d9eec", "cd294ab4-5081-433f-ab7e-ba12b638d17b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e67f9d86-c9c6-4938-86bb-c544bc22890d", "0b0c6d41-5c31-4566-9f6f-1858fc403cd7" });

            migrationBuilder.AddForeignKey(
                name: "FK_StartingCards_Cards_CardID",
                table: "StartingCards",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StartingCards_Cards_CardID",
                table: "StartingCards");

            migrationBuilder.RenameColumn(
                name: "CardID",
                table: "StartingCards",
                newName: "CardId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StartingCards",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_StartingCards_CardID",
                table: "StartingCards",
                newName: "IX_StartingCards_CardId");

            migrationBuilder.AddColumn<int>(
                name: "GameConfigId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_StartingCards_Cards_CardId",
                table: "StartingCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
