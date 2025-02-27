using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "790c12b4-9f39-48a9-8288-ab42e0b609ae", "AQAAAAIAAYagAAAAEAqELuW5EHk/TI/Ce6q1vFD5Bl8v5QOhOJ5HEnGxcBO7Ia7kwgP96JInEdpWSucYRA==", "a38a02b4-791e-4bce-bb20-517a77fddb73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4e8537c7-472b-440e-ab8d-17c64c6b4caa", "10611f40-b388-4e81-8dcb-bf5fa0d34a19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "26b7291c-c8e3-4d69-acc9-707295a21cab", "d9e7892d-2dfe-4a37-9aff-632e66a70e49" });
        }
    }
}
