using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Repository.Migrations
{
    public partial class updatedSubmissionFileModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7ccea50e-dcf3-4072-9eab-5637290d12fd", "bbdaf61d-e5fa-4112-a51f-78450ecae5cc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e2e4ce70-7396-47c5-b48b-98593f47be09", "f3424dde-6521-455f-902d-17e439bb7fe1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ccea50e-dcf3-4072-9eab-5637290d12fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2e4ce70-7396-47c5-b48b-98593f47be09");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbdaf61d-e5fa-4112-a51f-78450ecae5cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3424dde-6521-455f-902d-17e439bb7fe1");

            migrationBuilder.AddColumn<string>(
                name: "UniqueName",
                table: "SubmissionFile",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UniqueName",
                table: "SubmissionFile");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ccea50e-dcf3-4072-9eab-5637290d12fd", "1777ccad-218d-4101-97e9-dd9b3eed1daf", "Administrator", "ADMINISTRATOR" },
                    { "e2e4ce70-7396-47c5-b48b-98593f47be09", "892d1c31-61f9-4fe7-a033-d41abebb9d89", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bbdaf61d-e5fa-4112-a51f-78450ecae5cc", 0, "9d72583d-8535-40b9-b9e3-04ca0c248338", "admin@filemanager.com", true, "FileManager Administrator", false, null, "ADMIN@FILEMANAGER.COM", "ADMIN@FILEMANAGER.COM", "AQAAAAEAACcQAAAAEPZWQfctSD6/8GqzYfOFzaAvGg3sxYCUuDG7tXv3s4tWAmkX7P6O3W5e9foprdBI+A==", null, false, "48b40d30-2c25-4cdd-ba9b-32dc0642f6b5", false, "admin@filemanager.com" },
                    { "f3424dde-6521-455f-902d-17e439bb7fe1", 0, "f86253b5-4a3f-4144-b174-279423107ee3", "johndoe@filemanager.com", true, "John Doe", false, null, "JOHNDOE@FILEMANAGER.COM", "JOHNDOE@FILEMANAGER.COM", "AQAAAAEAACcQAAAAEOS96Njnz2t6xa2nzx0jHFG9QE5rZKZmgoPoGb6Wu757cp8eZKA4DjNRrOLJBcQVUQ==", null, false, "5e4bf614-227d-4a95-a71a-da4d3c6e5c98", false, "johndoe@filemanager.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7ccea50e-dcf3-4072-9eab-5637290d12fd", "bbdaf61d-e5fa-4112-a51f-78450ecae5cc" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e2e4ce70-7396-47c5-b48b-98593f47be09", "f3424dde-6521-455f-902d-17e439bb7fe1" });
        }
    }
}
