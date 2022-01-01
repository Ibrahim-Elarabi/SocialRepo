using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTask.Migrations.BlogTask
{
    public partial class AddStatusRequset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRequest",
                table: "GroupUsers");

            migrationBuilder.AddColumn<byte>(
                name: "StatusRequset",
                table: "GroupUsers",
                type: "tinyint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusRequset",
                table: "GroupUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsRequest",
                table: "GroupUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
