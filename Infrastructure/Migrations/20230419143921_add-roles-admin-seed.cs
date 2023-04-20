using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addrolesadminseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
               values: new object[] { "1", "d3160f03-30bb-423d-a026-ec1cb33835ba", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "a3aef585-3eaf-481f-b71e-ebd4ec32ec61", "User", null });

            migrationBuilder.InsertData(
             table: "AspNetUsers",
             columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
             values: new object[] { "1", 0, "a6dae2d3-8850-478b-b501-61f51a822520", "admin123@gmail.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEP+9ZHdQlaNfCr2QvspdqV+jhhIEWt9vcOAVgbg/rjvFPfwFThQBd+KdZvYP79kipQ==", null, false, "9714d536-7101-469b-81ed-0d74c41debd6", false, "Admin123" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

                }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
          table: "AspNetUsers",
          keyColumn: "Id",
          keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
             table: "AspNetUserRoles",
             keyColumns: new[] { "RoleId", "UserId" },
             keyValues: new object[] { "1", "1" });



        }
    }
    }
