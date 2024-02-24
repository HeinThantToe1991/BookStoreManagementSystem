using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreManagementSystem.Infrastructure.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("d9cbb087-b31f-4441-8506-c21c7e0c15a4"), "Author is someone", "HeinThantToe-Author" });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "Id", "CategoryName", "Description" },
                values: new object[] { new Guid("3b79e7b8-9a4a-41be-883a-5853056716d7"), "Romance", "About Romance " });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerName", "PhoneNumber" },
                values: new object[] { new Guid("8d7fae5e-3cd5-497b-b334-86790609eedc"), "HeinThantToe", "09786779545" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookCategoriesId", "BookName", "Description" },
                values: new object[] { new Guid("3b79e7b8-9a4a-41be-883a-5853056716e9"), new Guid("d9cbb087-b31f-4441-8506-c21c7e0c15a4"), new Guid("3b79e7b8-9a4a-41be-883a-5853056716d7"), "Romeo & Juliet", "Rule Of Romance" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("3b79e7b8-9a4a-41be-883a-5853056716e9"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("8d7fae5e-3cd5-497b-b334-86790609eedc"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d9cbb087-b31f-4441-8506-c21c7e0c15a4"));

            migrationBuilder.DeleteData(
                table: "BookCategories",
                keyColumn: "Id",
                keyValue: new Guid("3b79e7b8-9a4a-41be-883a-5853056716d7"));
        }
    }
}
