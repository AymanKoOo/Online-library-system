using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookPictures_Picture_PictureId",
                table: "bookPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "pictures");

            migrationBuilder.AlterColumn<int>(
                name: "ISBN",
                table: "books",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pictures",
                table: "pictures",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_bookPictures_pictures_PictureId",
                table: "bookPictures",
                column: "PictureId",
                principalTable: "pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookPictures_pictures_PictureId",
                table: "bookPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pictures",
                table: "pictures");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "books");

            migrationBuilder.RenameTable(
                name: "pictures",
                newName: "Picture");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "74870362-422e-4384-91da-efc768fea50a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c3429d68-2178-40e3-97a8-af83fb33ced4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae7de89a-1b87-45d5-9d8a-21a33f7fe538", "AQAAAAEAACcQAAAAEMlfZPmgtY1OTgw2CUWA3ZYnQk4z9Id7dYtf/gSfe3mgFzMhDDVB1VdsCXnpOaGk7A==", "d1e24aba-6449-493e-8962-243445b54e37" });

            migrationBuilder.AddForeignKey(
                name: "FK_bookPictures_Picture_PictureId",
                table: "bookPictures",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
