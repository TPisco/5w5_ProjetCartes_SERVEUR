using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Courant",
                table: "Decks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "432ff023-0d5b-43d1-9448-623c37ad6eaa", "AQAAAAIAAYagAAAAEGH9yBvO1N3q3WhDIjWIJ+pJUV5RXCFvtQORxBqIMa8/RwNQKcIm248AO2rvt+mxdw==", "eaf59771-d30e-403d-9f44-dc9a01cb91ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c1335df3-8b34-43e5-97c9-fd6fd2f4a69a", "2703c3fd-4589-4b96-a95a-035788a7c8ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0e0c62ea-2d97-4975-8a7d-f539ba56acce", "3bdaddf6-139b-4164-9358-7b44623bccbc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Courant",
                table: "Decks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de0535d3-2cb3-42ae-af80-a0fabc32d74b", "AQAAAAIAAYagAAAAEAISxaaZX3sXru8fZ8bKF/eB2/UT9RC/5yL1XkTreayx4ZpatCS08UhbmxFk9c6vMQ==", "0372e784-5cc6-48ff-8567-4dffc55ae71c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "68becaec-008a-40a0-b00a-a33a3f35553e", "c1223306-8b54-41dc-9f4c-0cdbdadfb551" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e8fc1ee9-b76f-4f3f-b693-3d606579f3c7", "7bfda8ca-13c6-432b-ab61-31ab133e37f4" });
        }
    }
}
