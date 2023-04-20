using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6aaf9793-8675-442d-a7ca-3a57acb3b1e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b9ddbfa1-bf4d-437d-888c-9f1af2edcd74");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31c0a64e-7de8-4c71-b2e6-3fdb78a97244", "AQAAAAEAACcQAAAAEGMwoF2jrEGRrBCKwp/eQPijawpuoTJFe92qPANhYnepOINlmNdEHfG6sICDrwizaA==", "f96af2c9-1f9f-476c-a817-d56b8f0c3ef2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
