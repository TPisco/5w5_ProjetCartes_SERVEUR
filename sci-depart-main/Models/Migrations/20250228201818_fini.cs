using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class fini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StartingCards");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "StartingCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
