using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_holds_AspNetUsers_UserId1",
                table: "holds");

            migrationBuilder.DropIndex(
                name: "IX_holds_UserId1",
                table: "holds");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "holds");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "holds",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "IX_holds_UserId",
                table: "holds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_holds_AspNetUsers_UserId",
                table: "holds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_holds_AspNetUsers_UserId",
                table: "holds");

            migrationBuilder.DropIndex(
                name: "IX_holds_UserId",
                table: "holds");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "holds",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "holds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "72f5f904-c1bb-4b23-b40e-2a7af0176142");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "339c28dc-3802-4744-ae88-7cc1bd0efac3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "983e0ca2-2516-4e4e-b4ce-3f2d4931d48b", "AQAAAAEAACcQAAAAEG3PAGz3jBZ+enu2JMn7dlNe0yadbtbBKg71wx2A0fpz7DFEbXB+CV6nao0CqlL6Fg==", "a87df006-45be-4f82-aab9-fddc5686063b" });

            migrationBuilder.CreateIndex(
                name: "IX_holds_UserId1",
                table: "holds",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_holds_AspNetUsers_UserId1",
                table: "holds",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
