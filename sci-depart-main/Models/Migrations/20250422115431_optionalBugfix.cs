using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class optionalBugfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a13cba47-9c11-4787-a89b-437394190078", "AQAAAAIAAYagAAAAEOPVvGcZHAacUlfscvhyP9kMX414FE/6uxk486ZU8G/buy/FsS+uQAxNWtTEXeEb/Q==", "032d8d09-7c93-422a-a46f-5820e1b83215" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "245d3ef7-5f08-408d-bf4c-44ffa3bfb7dc", "89ce6117-cf88-4720-9dae-e7ef8068064e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3ee7e286-fbb1-4803-b8e6-d76c5e95d215", "fd70e892-5f43-45f5-838b-beca07314661" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c074f43-4928-4826-a709-f513ce68a7b9", "AQAAAAIAAYagAAAAEFCKT6vnL+QCkADlsUYMXQBVkdSyUVcpI3GswFRp/Pup1cs4YZm65aGZR7orC4Egsw==", "11dd07a5-aaf0-4a0e-9335-b18784ed09ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "22cc9545-e1c5-4304-a030-e645652f86f1", "771968c9-d09d-46be-b8b2-0e5336d12820" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "00c128c8-bb8b-4909-a675-b3b36688c058", "af02e9e5-f7a1-413a-a54f-d90dc8788238" });
        }
    }
}
