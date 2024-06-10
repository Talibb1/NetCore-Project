using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e86c687-bb03-45f3-9b7e-3add5f6cc138",
                column: "ConcurrencyStamp",
                value: "f8e016ea-6ed5-4911-ab0c-ce9d8efc5796");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b2200a1-34fd-4fe0-a66f-f220f14ad3d2",
                column: "ConcurrencyStamp",
                value: "e15e3603-ef2d-4ae2-969c-0e30c5c8ad20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e337e5b4-63ef-4617-8e43-18a90b97c451",
                column: "ConcurrencyStamp",
                value: "ce500aee-8af3-4f1a-ac51-39ffb8d86247");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df0c8cd-26f4-488d-b76f-4b4aac7d56a2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFd9UEhja05csnvUHpPxSSfyT0Afx8sOf88xKuvIXv3q9hfKy5w8557c7olBjQC+WQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e86c687-bb03-45f3-9b7e-3add5f6cc138",
                column: "ConcurrencyStamp",
                value: "d74988a5-a8d5-43d6-a74c-3107ab3fb6c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b2200a1-34fd-4fe0-a66f-f220f14ad3d2",
                column: "ConcurrencyStamp",
                value: "7fff0c31-ce0e-4727-933e-e7e502c70f64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e337e5b4-63ef-4617-8e43-18a90b97c451",
                column: "ConcurrencyStamp",
                value: "cfa89c10-7337-4c4d-8eb9-8423eedfab1d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df0c8cd-26f4-488d-b76f-4b4aac7d56a2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELRIe21ihurbQJ3SuzRgsca62vodeQDuzVQvt8zMbOZwptYAODOhYSDYL5F0CjDhfg==");
        }
    }
}
