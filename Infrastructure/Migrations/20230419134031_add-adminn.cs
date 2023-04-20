using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addadminn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "a6dae2d3-8850-478b-b501-61f51a822520", "admin123@gmail.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEP+9ZHdQlaNfCr2QvspdqV+jhhIEWt9vcOAVgbg/rjvFPfwFThQBd+KdZvYP79kipQ==", null, false, "9714d536-7101-469b-81ed-0d74c41debd6", false, "Admin123" });
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
