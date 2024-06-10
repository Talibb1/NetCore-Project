using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e86c687-bb03-45f3-9b7e-3add5f6cc138",
                column: "ConcurrencyStamp",
                value: "70dd1fbc-77f7-44ad-86d0-37155cd1192e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b2200a1-34fd-4fe0-a66f-f220f14ad3d2",
                column: "ConcurrencyStamp",
                value: "a99afeb2-8891-4752-a7e4-27ff7e7c15f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e337e5b4-63ef-4617-8e43-18a90b97c451",
                column: "ConcurrencyStamp",
                value: "de0b143e-7eb7-462f-9b05-5277015ddcff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df0c8cd-26f4-488d-b76f-4b4aac7d56a2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFYxzB0UdajIjicTyhFc5bIcAyfFHHlTFY9XDXVYHrwFjIdf7w5BvgafrijXDpkVkw==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e86c687-bb03-45f3-9b7e-3add5f6cc138",
                column: "ConcurrencyStamp",
                value: "e2a7d1ab-2cbe-48a5-b2f8-5ae44dde56c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b2200a1-34fd-4fe0-a66f-f220f14ad3d2",
                column: "ConcurrencyStamp",
                value: "71a61b12-695d-429a-9904-ac789a929eb5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e337e5b4-63ef-4617-8e43-18a90b97c451",
                column: "ConcurrencyStamp",
                value: "d04197b3-bc4b-46ad-9a71-af47b7d6991c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df0c8cd-26f4-488d-b76f-4b4aac7d56a2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEF5UtHXvqn0IqMyV/8A+2VboS6j1KiAgLHUmho+eBgwLvjrtJDAVv1F0Nhc8s5q04g==");
        }
    }
}
