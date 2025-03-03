﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e86c687-bb03-45f3-9b7e-3add5f6cc138",
                column: "ConcurrencyStamp",
                value: "7f776e8b-0339-4246-94cd-481440cd158e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b2200a1-34fd-4fe0-a66f-f220f14ad3d2",
                column: "ConcurrencyStamp",
                value: "dbb5baa1-2594-4285-926d-cc3c17e130be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e337e5b4-63ef-4617-8e43-18a90b97c451",
                column: "ConcurrencyStamp",
                value: "60007cc3-2791-47d8-97ae-e4516f416b18");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2db2186c-6e17-4bb0-8ae1-fad543f3196c",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEB8bNW1OQ7phFFM7IqgeeTSQf8GPfkRnkWlNK8Ai9QvmGy/w4jlvd9XxbaMCBe5ikA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df0c8cd-26f4-488d-b76f-4b4aac7d56a2",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJUkyWmMDrMXYB8cHGMa9uJL7UGdRhTOuH9+IbwsdtktKSevtIq+wG1jMLiduWKpKA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1b066cb-5a51-4eb3-8afe-be2bf305648f",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAENIlC95NBG+aAR/5ABHs94tIo/RUkEw6bx2mDpLA7PswTxu7cm/SKdVnu6jsdjoixg==");
        }
    }
}
