using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTask.Migrations.BlogTask
{
    public partial class editMG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_Groups_GroupID",
                table: "GroupUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "BlogID",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GroupID",
                table: "GroupUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_Groups_GroupID",
                table: "GroupUsers",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogID",
                table: "Posts",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_Groups_GroupID",
                table: "GroupUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogID",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "BlogID",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupID",
                table: "GroupUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_Groups_GroupID",
                table: "GroupUsers",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogID",
                table: "Posts",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
