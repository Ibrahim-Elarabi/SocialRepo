using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTask.Migrations.BlogTask
{
    public partial class Editv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_AspNetUsers_UserId",
                table: "GroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Group_GroupID",
                table: "GroupUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUser",
                table: "GroupUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "GroupUser",
                newName: "GroupUsers");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_GroupUser_UserId",
                table: "GroupUsers",
                newName: "IX_GroupUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupUser_GroupID",
                table: "GroupUsers",
                newName: "IX_GroupUsers_GroupID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUsers",
                table: "GroupUsers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_AspNetUsers_UserId",
                table: "GroupUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_Groups_GroupID",
                table: "GroupUsers",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_AspNetUsers_UserId",
                table: "GroupUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_Groups_GroupID",
                table: "GroupUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUsers",
                table: "GroupUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "GroupUsers",
                newName: "GroupUser");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_GroupUsers_UserId",
                table: "GroupUser",
                newName: "IX_GroupUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupUsers_GroupID",
                table: "GroupUser",
                newName: "IX_GroupUser_GroupID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUser",
                table: "GroupUser",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_AspNetUsers_UserId",
                table: "GroupUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Group_GroupID",
                table: "GroupUser",
                column: "GroupID",
                principalTable: "Group",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
