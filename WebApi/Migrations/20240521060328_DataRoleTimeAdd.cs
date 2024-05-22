using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class DataRoleTimeAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c09619c-126e-48d2-a786-de5773b68034");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1cf8943-a286-4916-b8d8-09c76a6a7f23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac7bc5ba-b58f-4ba4-88a3-bcc104376811");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d68197ba-20ca-47b3-b030-9be74dc63aad");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c09619c-126e-48d2-a786-de5773b68034", null, "Personel", "PERSONEL" },
                    { "a1cf8943-a286-4916-b8d8-09c76a6a7f23", null, "Admin", "ADMIN" },
                    { "ac7bc5ba-b58f-4ba4-88a3-bcc104376811", null, "Editor", "EDITOR" },
                    { "d68197ba-20ca-47b3-b030-9be74dc63aad", null, "Userf", "USERF" }
                });
        }
    }
}
