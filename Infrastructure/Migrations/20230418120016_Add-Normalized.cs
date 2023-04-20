using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddNormalized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "74870362-422e-4384-91da-efc768fea50a", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "c3429d68-2178-40e3-97a8-af83fb33ced4", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae7de89a-1b87-45d5-9d8a-21a33f7fe538", "ADMIN123", "AQAAAAEAACcQAAAAEMlfZPmgtY1OTgw2CUWA3ZYnQk4z9Id7dYtf/gSfe3mgFzMhDDVB1VdsCXnpOaGk7A==", "d1e24aba-6449-493e-8962-243445b54e37" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "f11ea3c8-81d7-4a44-a4b5-7e6da225a07f", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "afd397f4-9a88-43fe-96ab-2f2e96f142f4", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6dae2d3-8850-478b-b501-61f51a822520", null, "AQAAAAEAACcQAAAAEP+9ZHdQlaNfCr2QvspdqV+jhhIEWt9vcOAVgbg/rjvFPfwFThQBd+KdZvYP79kipQ==", "9714d536-7101-469b-81ed-0d74c41debd6" });
        }
    }
}
