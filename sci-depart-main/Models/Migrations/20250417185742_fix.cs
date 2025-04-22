using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5035481-3c81-4844-b588-ef6d652ee911", "AQAAAAIAAYagAAAAEPyDqMP2v7MOsYrrH46fgEdIGsduatNYKm/xmfYc6KL7iPnnSVgaWkL+A2X9gkG9lA==", "d7262755-ad94-4e99-ad46-4242351dc2fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7f29b69e-27af-4e95-907c-0c21fef0e82f", "36023313-0088-4c5f-b2c4-db7b4a315ece" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cb582bbb-1d72-4b5f-8eb9-a0a3ce184746", "53a2a492-13b8-4fec-8861-b6a58bf75cb3" });
        }
    }
}
