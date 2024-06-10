using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class mig22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e86c687-bb03-45f3-9b7e-3add5f6cc138",
                column: "ConcurrencyStamp",
                value: "709b4683-d660-4a96-b11f-dffab220cc4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b2200a1-34fd-4fe0-a66f-f220f14ad3d2",
                column: "ConcurrencyStamp",
                value: "4804e0f8-2490-4bba-a514-1a1154b4b40e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e337e5b4-63ef-4617-8e43-18a90b97c451",
                column: "ConcurrencyStamp",
                value: "c0062d43-c366-490d-8fe7-3e7bfd1da9f3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2db2186c-6e17-4bb0-8ae1-fad543f3196c",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPrgPia+dP5sIsgdrhd/0WcnlsQV08UyWTkHpSZtu8whkZDtMWoLa29s/TTfNecBGQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df0c8cd-26f4-488d-b76f-4b4aac7d56a2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEL9gCJHygQG5pA2ZLMv7PchBMYUVB/imvxH30bJY76IzMgFOYVKZL8WLRuy9Ij3b/w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1b066cb-5a51-4eb3-8afe-be2bf305648f",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPhc+gVt5Aoe3Q5rLU3Sj+kAdN8DwlyWyLGi7eSPoDDRAbu69XJZdDQGZ5SpNKn2yA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e86c687-bb03-45f3-9b7e-3add5f6cc138",
                column: "ConcurrencyStamp",
                value: "20af9f63-d959-4b0d-bdde-985746469f0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b2200a1-34fd-4fe0-a66f-f220f14ad3d2",
                column: "ConcurrencyStamp",
                value: "a36f6408-cf1c-44ae-a87c-8ed77d720e15");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e337e5b4-63ef-4617-8e43-18a90b97c451",
                column: "ConcurrencyStamp",
                value: "de9efa76-2db1-4654-b3b2-1f7e441f87ff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2db2186c-6e17-4bb0-8ae1-fad543f3196c",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIwCxOpmNNtQXXndSSXsznovAs6GoXyx/4yGHWaJqpLasnRaoZCeAIWQIuwiGVlCxA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df0c8cd-26f4-488d-b76f-4b4aac7d56a2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGzRYLcJ7JYfMiw8nyM+bGTxMUrDCVjs2M+b1IKMvNVeeNGNTrCBGRfetw1wNT5COg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1b066cb-5a51-4eb3-8afe-be2bf305648f",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAENmjXzxkNeea+Cm8ANX7p1TF3L2j+30b5zcIQEcIxis3+XxutERlQPdfNnyRYGt0Cg==");
        }
    }
}
