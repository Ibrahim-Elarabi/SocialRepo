using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTask.Migrations.BlogTask
{
    public partial class EDitcolumnNameinPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Post Content",
                table: "Posts",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Posts",
                newName: "Post Content");
        }
    }
}
