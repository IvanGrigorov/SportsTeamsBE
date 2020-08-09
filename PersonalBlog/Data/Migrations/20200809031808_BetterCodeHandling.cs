using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Data.Migrations
{
    public partial class BetterCodeHandling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Project_ProjectId",
                table: "Gallery");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Project_ProjectId",
                table: "Gallery",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Project_ProjectId",
                table: "Gallery");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Project_ProjectId",
                table: "Gallery",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }
    }
}
