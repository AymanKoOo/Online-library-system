using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class editstr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_borrowings_AspNetUsers_UserId1",
                table: "borrowings");

            migrationBuilder.DropIndex(
                name: "IX_borrowings_UserId1",
                table: "borrowings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "borrowings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "borrowings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8f87e87b-d3c6-4464-83cc-cf89b3b767c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e720077e-1dbd-49a1-9c48-b9e7c254f38c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8450489-9946-4c4c-a43b-08f0db1ad12e", "AQAAAAEAACcQAAAAELloo2kpByKCHR1tN6LIsKXa/7dSxllyAFmMjIpz5xyiz8Z95IETaPMBt6+7JO33ZA==", "9a01155f-b02c-4ce4-bf13-5a6eb0befdec" });

            migrationBuilder.CreateIndex(
                name: "IX_borrowings_UserId",
                table: "borrowings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_borrowings_AspNetUsers_UserId",
                table: "borrowings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_borrowings_AspNetUsers_UserId",
                table: "borrowings");

            migrationBuilder.DropIndex(
                name: "IX_borrowings_UserId",
                table: "borrowings");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "borrowings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "borrowings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "670c9327-5bdf-4e5a-888b-cbeba50168e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d31b1880-0bfc-4285-922d-ecb2e1e1f66a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b71abab-8ad1-4c4b-8399-2d83327601d3", "AQAAAAEAACcQAAAAENSZ3D2v5Fmkqlcam3pxAlfGqTvaO1+0noNEBzdvkCcl+c1hkxKsoXSQqrZ3Us658A==", "7dad7aa0-2881-415b-9d0e-33222a7868c8" });

            migrationBuilder.CreateIndex(
                name: "IX_borrowings_UserId1",
                table: "borrowings",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_borrowings_AspNetUsers_UserId1",
                table: "borrowings",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
