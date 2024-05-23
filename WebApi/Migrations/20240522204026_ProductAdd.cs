using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ProductAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f8f12dd-d441-4de2-aac3-e2388d17f6a9", null, "Editor", "EDITOR" },
                    { "3c322d87-2249-4d2d-8cc2-2f5fb8636c21", null, "Personel", "PERSONEL" },
                    { "6e4c6518-9e36-480a-b31a-81325ab99ff6", null, "Userf", "USERF" },
                    { "967cc832-228c-4731-b82b-49c338fd81aa", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 100m, "Ürün1" },
                    { 2, 200m, "Ürün2" },
                    { 3, 300m, "Ürün3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f8f12dd-d441-4de2-aac3-e2388d17f6a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c322d87-2249-4d2d-8cc2-2f5fb8636c21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e4c6518-9e36-480a-b31a-81325ab99ff6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967cc832-228c-4731-b82b-49c338fd81aa");

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
    }
}
