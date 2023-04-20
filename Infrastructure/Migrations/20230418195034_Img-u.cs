using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Imgu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltAttribute",
                table: "pictures");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "pictures");

            migrationBuilder.DropColumn(
                name: "SeoFilename",
                table: "pictures");

            migrationBuilder.DropColumn(
                name: "TitleAttribute",
                table: "pictures");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5f90a965-fe22-49b8-b6f0-1ded677007e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4be12cc3-d6e8-4a2a-99b1-3c9a08ff06fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8935c4e3-7635-4df8-965c-7ecb1cca1c66", "AQAAAAEAACcQAAAAEACw0zqFBGBWvaH82QbzaaZGs1YQ25aRasu4ihH9q7hYcPdyvu8OioRaTY9uTfR/yg==", "f99db4b8-11cc-41ad-9619-934a93bb978c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltAttribute",
                table: "pictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "pictures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SeoFilename",
                table: "pictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleAttribute",
                table: "pictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c32e064d-e4bf-4cdb-87b7-7bf16e44313e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4de6b78f-3d36-42b4-8973-b0a0a375cf13");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe0e7160-a762-43fa-9e8b-50d9042a4dcc", "AQAAAAEAACcQAAAAEEZfFqsCe4yfIZMFMUgwVBZcI16NYv+6238WeCb6VUjSrY6votSJDCMDFHc49dmCWQ==", "3d1cfd79-89aa-4af2-ad8d-1088d9babae6" });
        }
    }
}
