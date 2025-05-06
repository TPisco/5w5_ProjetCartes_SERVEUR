using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ModelsBugfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb36da18-82b1-4be0-abe8-71b3731f4f68", "AQAAAAIAAYagAAAAELP6ZZmbfwZN4n8Tzxlzz2CemZTWZdlwoQSouCbHcZ4MvutS+FxUy+5WZuvrKtqzBw==", "a5e6b152-c963-4e97-b7c0-c803cab40cbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b7df6d7-f81c-4825-92bf-a32709da99af", "fc4976ee-7573-4f3d-bf70-7ba75f4aba35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7b455899-4982-4195-a0c0-efeae01983ad", "44552189-e162-4a21-9cdc-8d6ec18050b7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
