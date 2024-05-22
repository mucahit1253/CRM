using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22fae463-d2a2-4e4f-acaa-346b7d132978");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27d8db69-1666-408f-9bbc-74df2311e668");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abf0de01-54fa-4613-8cab-59232aa99c65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca91db35-836b-409f-a0ad-38fad27b62a7");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "471e8b34-aef0-498f-86b8-2b1ef551500a", null, "Userf", "USERF" },
                    { "5ccd648c-fb7f-474c-bf7f-d84c672038aa", null, "Admin", "ADMIN" },
                    { "69bc1a59-963a-4611-9f1e-0e0e4c83df58", null, "Personel", "PERSONEL" },
                    { "ed8f7ad5-904d-46ea-88cf-7a7616fd0b36", null, "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "471e8b34-aef0-498f-86b8-2b1ef551500a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ccd648c-fb7f-474c-bf7f-d84c672038aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69bc1a59-963a-4611-9f1e-0e0e4c83df58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed8f7ad5-904d-46ea-88cf-7a7616fd0b36");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22fae463-d2a2-4e4f-acaa-346b7d132978", null, "Userf", "USERF" },
                    { "27d8db69-1666-408f-9bbc-74df2311e668", null, "Personel", "PERSONEL" },
                    { "abf0de01-54fa-4613-8cab-59232aa99c65", null, "Editor", "EDITOR" },
                    { "ca91db35-836b-409f-a0ad-38fad27b62a7", null, "Admin", "ADMIN" }
                });
        }
    }
}
