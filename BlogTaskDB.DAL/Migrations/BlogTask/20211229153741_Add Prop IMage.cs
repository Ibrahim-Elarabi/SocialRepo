using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTask.Migrations.BlogTask
{
    public partial class AddPropIMage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Posts");
        }
    }
}
