using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewShopApp.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "12c24bb3-41d8-413e-9ae0-17b63040caab");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71db12b9-03f2-4772-b15c-5c82f1ffb9b6", "AQAAAAEAACcQAAAAENzy03kzla6wndNsrtS3GfiUoeDKMNe3+zo9i70KzHAUTe/j7kEHZtH1dEoAI0TqkQ==" });

            migrationBuilder.UpdateData(
                table: "CategorieTests",
                keyColumn: "ID",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CategorieTests",
                keyColumn: "ID",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTests",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 27, 19, 30, 50, 496, DateTimeKind.Local).AddTicks(5524));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "bc38801b-9347-4f80-89d7-0ecfeca49767");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4c60fbbd-24b7-4c19-96d8-5be64d566ca9", "AQAAAAEAACcQAAAAEGHPNz3Ise3neNsvYJ9J/OWLqjg19YVDIL27rdmTicxOxhP6ImWZcLy2ML95xVq/Bw==" });

            migrationBuilder.UpdateData(
                table: "CategorieTests",
                keyColumn: "ID",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CategorieTests",
                keyColumn: "ID",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTests",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 27, 11, 45, 51, 532, DateTimeKind.Local).AddTicks(2654));
        }
    }
}
