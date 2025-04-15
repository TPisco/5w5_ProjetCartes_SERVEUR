using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class suighsj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3accdc05-407a-4f2b-af56-d3dc89af2c34", "AQAAAAIAAYagAAAAENNwE1gbk/X5REURmjvpkp90S6DCrG96MiM59kWJSJl3f5OIiI76LU7WoRTzr2F1Mg==", "fb5133ee-e86d-4ff2-8306-e07cc2840538" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ca141391-c3b7-4a3a-b962-b5623ca4a978", "69aaed95-ca01-4d0d-8988-0343a733b613" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0aa6d9e7-c2b0-4ea9-8f63-08f7c29d73ab", "4b4dc7dc-9611-4f9f-9b5d-789e854f9bf0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92588650-5102-421d-8bde-43dfd7d66bb7", "AQAAAAIAAYagAAAAELdIzs3eo/jtY+y8OI0n3mRwEafuRColAKM4PKFVqEBruGDGUwOH8kF59LtqcbA1dQ==", "7c4383b1-f192-4ded-b483-258664fc44c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4fc773c5-3694-454c-890a-0da0bb079578", "6678471e-7c3c-4e1c-ab58-003de4e96168" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e92d6e22-e7ed-4e9d-ad17-79d843357109", "6ef3b7b8-8043-46d1-8e73-372544fe9298" });
        }
    }
}
