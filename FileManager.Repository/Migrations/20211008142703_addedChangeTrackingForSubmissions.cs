using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Repository.Migrations
{
    public partial class addedChangeTrackingForSubmissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46a6541f-ad32-46d4-ac5b-583f8294147d", "9b3a0a20-6ccb-45d7-8952-472fed1a1ae3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "baaad2a5-dd82-40fd-8946-d8b8b591f07c", "c4dc3704-664d-4b6c-b131-01127695f276" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46a6541f-ad32-46d4-ac5b-583f8294147d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baaad2a5-dd82-40fd-8946-d8b8b591f07c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b3a0a20-6ccb-45d7-8952-472fed1a1ae3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4dc3704-664d-4b6c-b131-01127695f276");

            migrationBuilder.AlterColumn<string>(
                name: "VendorName",
                table: "Submissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectMatter",
                table: "Submissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Submissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Submissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Submissions");

            migrationBuilder.AlterColumn<string>(
                name: "VendorName",
                table: "Submissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectMatter",
                table: "Submissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46a6541f-ad32-46d4-ac5b-583f8294147d", "cdc53665-3a9b-4180-9b30-774d58763ca8", "Administrator", "ADMINISTRATOR" },
                    { "baaad2a5-dd82-40fd-8946-d8b8b591f07c", "c4b872d6-501b-46b5-99df-b313ec771275", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9b3a0a20-6ccb-45d7-8952-472fed1a1ae3", 0, "01573bd0-24cc-42fb-acd6-a96e6a79a738", "admin@filemanager.com", true, "FileManager Administrator", false, null, "ADMIN@FILEMANAGER.COM", "ADMIN@FILEMANAGER.COM", "AQAAAAEAACcQAAAAELF4izBlEC5mnMTP9wBvH2BZYMIP8ZNxo1rTaM1b3XGfdsoIZM6e95OQ2ALfYgdDAw==", null, false, "9aec7876-5498-437e-b060-38887980562f", false, "admin@filemanager.com" },
                    { "c4dc3704-664d-4b6c-b131-01127695f276", 0, "d656bfd9-d98e-45e9-bcf3-3f693f83a26e", "johndoe@filemanager.com", true, "John Doe", false, null, "JOHNDOE@FILEMANAGER.COM", "JOHNDOE@FILEMANAGER.COM", "AQAAAAEAACcQAAAAEFunOH5tXOuEdkfBnG1NIecqH44hcUAWhZtFYGxr8EdrrBiNqIRJ1FSnPkqcjevBxg==", null, false, "3db2045f-47fb-43bf-b813-51da80c0141f", false, "johndoe@filemanager.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "46a6541f-ad32-46d4-ac5b-583f8294147d", "9b3a0a20-6ccb-45d7-8952-472fed1a1ae3" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "baaad2a5-dd82-40fd-8946-d8b8b591f07c", "c4dc3704-664d-4b6c-b131-01127695f276" });
        }
    }
}
