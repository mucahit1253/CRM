using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDatabese : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
