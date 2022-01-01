using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTask.Migrations.BlogTask
{
    public partial class deletecolumnInpublicinPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InPublic",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Posts",
                newName: "Post Content");

            migrationBuilder.AlterColumn<string>(
                name: "Post Content",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Post Content",
                table: "Posts",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "InPublic",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
