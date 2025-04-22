using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class restart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94c427ad-9f33-4168-a77c-d523999c0307", "AQAAAAIAAYagAAAAEHba28M8lJdcZ0JFDWeFuPXwU97x8EKIud7OooKNjp/H6EIbC9D3XfzQbJlAD/SspQ==", "e2c4c36a-fbe2-4ac2-a421-c8ebe85d0e6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "30da1077-3be1-4945-a95d-e05313ffbb5b", "2050f15e-ce9d-493f-8968-603928a839b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "220d60bf-df76-4966-a02b-b2f90025acd7", "c7a0bf07-69e3-466a-8837-c4c790c69721" });
        }
    }
}
