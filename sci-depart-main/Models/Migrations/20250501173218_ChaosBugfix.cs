using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ChaosBugfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c34d8b50-d60a-49da-bcbe-56eeac3ca371", "AQAAAAIAAYagAAAAEKyyZz6FCBnxxZHbT8XgUUUe/Jbi5DZGOcDXP07+RExyHGAoyMy7bsTwLD7a0gOi9Q==", "74083c39-b981-41cf-91e7-1cc4afd16e8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0341f09b-2a08-497c-aebf-11fdcfcd7e1f", "b1ad8f31-c91d-40a9-a6a8-7b20b5203bb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "476e5120-427b-467c-8c51-0e2cbc7910e9", "70f0dc0b-5630-4a10-920d-7dd558d3f91d" });

            migrationBuilder.UpdateData(
                table: "Power",
                keyColumn: "Id",
                keyValue: 5,
                column: "HasValue",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fca310b-011e-474b-8acf-486c4455a910", "AQAAAAIAAYagAAAAEMCQ7S7ZdIRgnknzvXfjNUWCtZPh+sgH9x6RBE2vS+WUVUZOyLDnfGCPoyzRRUsbew==", "3c2cc0ca-af78-42d3-99fe-b79956a23504" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d97d494b-62dd-4349-8d71-d540b5f6562b", "5e5509dc-a382-428c-8471-bb717b89fb2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e832f3c8-dc5b-467e-9c0a-c12380956121", "94aacf20-7a44-4e24-955c-ece9fd7d5cb0" });

            migrationBuilder.UpdateData(
                table: "Power",
                keyColumn: "Id",
                keyValue: 5,
                column: "HasValue",
                value: true);
        }
    }
}
