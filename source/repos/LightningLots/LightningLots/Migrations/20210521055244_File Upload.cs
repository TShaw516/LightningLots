using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningLots.Migrations
{
    public partial class FileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46c26d83-863e-45d9-94ab-9da8e9aafd1a");

            migrationBuilder.AddColumn<string>(
                name: "AttachmentPath",
                table: "Lot",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e45a7972-e467-4973-af45-1837c82d5520", 0, "Akron", "8c173646-4d40-4107-b3e8-67333acfd1be", null, false, "Tom", "Shaw", false, null, null, null, null, null, false, "078ee9c5-8a3d-41fc-9123-748fe8699f7b", "Ohio", false, null });

            migrationBuilder.UpdateData(
                table: "Reagent",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReceiptTimeStamp",
                value: new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e45a7972-e467-4973-af45-1837c82d5520");

            migrationBuilder.DropColumn(
                name: "AttachmentPath",
                table: "Lot");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46c26d83-863e-45d9-94ab-9da8e9aafd1a", 0, "Akron", "2023e123-9c52-4090-a968-9a15117d72e5", null, false, "Tom", "Shaw", false, null, null, null, null, null, false, "56553d95-00d0-4603-b3c6-10a94373c764", "Ohio", false, null });

            migrationBuilder.UpdateData(
                table: "Reagent",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReceiptTimeStamp",
                value: new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
