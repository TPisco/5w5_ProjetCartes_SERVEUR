using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "041154f5-1b71-4e9b-a512-a18176f5a119", "AQAAAAIAAYagAAAAEOtIbb8KPn0bWIDPAV4JPoDcw0WPgaTMCH9TXv7t+zHzhQznx5OgL9xc4vDsZt3mSg==", "45ab03be-edcf-4fa8-b5d1-40314da17a9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "301cc8f0-6b25-4dfd-9161-aa24ff72fbe1", "a7648d51-b943-467e-b978-cd160ce42f78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9049435f-abce-446f-924b-5c8dbf2d4afa", "67f483aa-e687-4993-816e-0a1a342c14c3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e56b70b-4d09-4acd-a09f-9745897059e2", "AQAAAAIAAYagAAAAEFENsq2cA3DmbMEsD8uyCYENyHZx6DkZyNxf6gOAYbuQ86py8Wqp4w4RPaj3Gr5RZA==", "7082cf6d-7fe6-438e-90c7-41f4e3a254a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0ccb407a-f52c-45e4-9a6f-c34528dd119a", "d9bb4977-6e6b-4106-abc0-9722489da05c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f757df2a-4749-4dd4-ab46-033d1a276640", "f9056b7b-94b0-43ac-b387-461e7d240bdb" });
        }
    }
}
