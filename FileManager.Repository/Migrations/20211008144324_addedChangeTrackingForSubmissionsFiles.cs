using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Repository.Migrations
{
    public partial class addedChangeTrackingForSubmissionsFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "16335518-4b2c-42ff-bad1-187f179fedff", "920314a8-d5e2-4590-a916-0f9383bba030" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9c5fd92-eaca-49e2-854c-73fe6cac3da5", "e2333c76-d08e-4566-8b7b-7fbb7c492737" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16335518-4b2c-42ff-bad1-187f179fedff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9c5fd92-eaca-49e2-854c-73fe6cac3da5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "920314a8-d5e2-4590-a916-0f9383bba030");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2333c76-d08e-4566-8b7b-7fbb7c492737");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueName",
                table: "SubmissionFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubmissionFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "SubmissionFile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "SubmissionFile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6876c2ed-e57a-49ba-83e0-21f83a470ac2", "d3f3e250-b72a-4430-82d5-ca1ef809fdbb", "Administrator", "ADMINISTRATOR" },
                    { "64db6fbe-3042-4d64-89ab-cace0c6c3903", "1818eb86-6e4f-406d-ac7a-34e1de201899", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "63fa277f-84e7-4c0b-8ceb-aece4072cb62", 0, "fd36eef5-9da1-443e-b909-e1beecd9fc3c", "admin@filemanager.com", true, "FileManager Administrator", false, null, "ADMIN@FILEMANAGER.COM", "ADMIN@FILEMANAGER.COM", "AQAAAAEAACcQAAAAEHv68eCmhTrotA1/km7yTRyxwIB7L5HD+nS81s2JtlDzmkQ7XQ9qsiv9ck0a11zfPQ==", null, false, "6f7db7a6-9e14-48ad-8d07-2160a17c070e", false, "admin@filemanager.com" },
                    { "328ccefc-6fad-49a1-8627-664f6f9ff8a9", 0, "ea20b903-a9e0-460e-bdc8-2f4e9610281d", "johndoe@filemanager.com", true, "John Doe", false, null, "JOHNDOE@FILEMANAGER.COM", "JOHNDOE@FILEMANAGER.COM", "AQAAAAEAACcQAAAAEBaNV9Q+IDRbkTc13H1d3GihicnDA0yELvjGzu1q77g30Wbt7F4q0hU0hNUeFlmRPA==", null, false, "f58ac6fe-f3e2-43c4-b091-7d81ad80d4ea", false, "johndoe@filemanager.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6876c2ed-e57a-49ba-83e0-21f83a470ac2", "63fa277f-84e7-4c0b-8ceb-aece4072cb62" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "64db6fbe-3042-4d64-89ab-cace0c6c3903", "328ccefc-6fad-49a1-8627-664f6f9ff8a9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64db6fbe-3042-4d64-89ab-cace0c6c3903", "328ccefc-6fad-49a1-8627-664f6f9ff8a9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6876c2ed-e57a-49ba-83e0-21f83a470ac2", "63fa277f-84e7-4c0b-8ceb-aece4072cb62" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64db6fbe-3042-4d64-89ab-cace0c6c3903");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6876c2ed-e57a-49ba-83e0-21f83a470ac2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "328ccefc-6fad-49a1-8627-664f6f9ff8a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63fa277f-84e7-4c0b-8ceb-aece4072cb62");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SubmissionFile");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "SubmissionFile");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueName",
                table: "SubmissionFile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubmissionFile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16335518-4b2c-42ff-bad1-187f179fedff", "faddcf27-d718-4863-88f5-d8e67f94255a", "Administrator", "ADMINISTRATOR" },
                    { "c9c5fd92-eaca-49e2-854c-73fe6cac3da5", "aabff647-676c-4ed3-9cc9-12db4cf38eef", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "920314a8-d5e2-4590-a916-0f9383bba030", 0, "d713794d-2721-4a1a-af99-9f005c54f9b6", "admin@filemanager.com", true, "FileManager Administrator", false, null, "ADMIN@FILEMANAGER.COM", "ADMIN@FILEMANAGER.COM", "AQAAAAEAACcQAAAAELbGnvM9etsjZRJH0UUMXlQWK3+HMnsWtv2pguTnL278Cv7lckGspVkmjbDDKyEYsw==", null, false, "e9691ed7-e5a6-452c-b74f-5834dcf0a94d", false, "admin@filemanager.com" },
                    { "e2333c76-d08e-4566-8b7b-7fbb7c492737", 0, "9f08435b-59f8-4571-9aa3-5e869a2bdc3d", "johndoe@filemanager.com", true, "John Doe", false, null, "JOHNDOE@FILEMANAGER.COM", "JOHNDOE@FILEMANAGER.COM", "AQAAAAEAACcQAAAAEE1fJOz1qLRjTBkEXY4t0i/IuiKMAMaYEkroS64wItgAE4BIT1NTH33T0GJczEfyLQ==", null, false, "827b9d90-1be8-4b62-880c-85c7fa9f2988", false, "johndoe@filemanager.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16335518-4b2c-42ff-bad1-187f179fedff", "920314a8-d5e2-4590-a916-0f9383bba030" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c9c5fd92-eaca-49e2-854c-73fe6cac3da5", "e2333c76-d08e-4566-8b7b-7fbb7c492737" });
        }
    }
}
