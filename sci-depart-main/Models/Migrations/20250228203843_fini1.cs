using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class fini1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a39917e4-a99a-4b5d-9d11-246d3fe602e0", "AQAAAAIAAYagAAAAENOkH0mro2+ugBhznlg+0cXItfSMoIQddAeeBQ65rAEg9rO+/WK+E/FByS6dHutf6w==", "a37a1947-7fb8-4bd1-bb5a-2c80e3a308fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c62e5d40-dd92-4537-a6fe-1cbdab7d68b4", "84bf3693-74a0-4e3e-ae7b-bc91c42c8571" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2bf4cd8-ed5c-49fa-86f5-39b4fa860e7c", "02b95514-3896-4c7a-bbf7-e6feb0d754ff" });

            migrationBuilder.InsertData(
                table: "GameConfigs",
                columns: new[] { "id", "QtManaParTour", "nbCardsToDraw" },
                values: new object[] { 1, 3, 4 });

            migrationBuilder.InsertData(
                table: "StartingCards",
                columns: new[] { "Id", "CardID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 4 },
                    { 3, 6 },
                    { 4, 5 },
                    { 5, 3 },
                    { 6, 10 },
                    { 7, 5 },
                    { 8, 3 },
                    { 9, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameConfigs",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b301b17-e421-4b7c-9198-e1e65a7a00df", "AQAAAAIAAYagAAAAEMBOFQUtl2J8jQ/kT/akVq37Bay0kfth6+w1B0eUX/wJjyFaPXJRVfEKM2TZfLYS/Q==", "65094880-433f-40f4-b5f1-8011d7d17ceb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cd1e955a-0caf-4398-884f-c66b75e34218", "d52c85fe-9f57-4717-ab0d-4b259055dde6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7226a5a3-d7de-46ae-bcd2-936922ee0952", "f84b5b7e-5af2-4f10-8d8a-8dba97a5199e" });
        }
    }
}
