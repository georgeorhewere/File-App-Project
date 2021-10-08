using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Repository.Migrations
{
    public partial class seedIdentityAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
