using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Data.Migrations
{
    public partial class RemoveForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Article_ArticleId",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Project_ProjectId",
                table: "Gallery");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Article_ArticleId",
                table: "Gallery",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Project_ProjectId",
                table: "Gallery",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Article_ArticleId",
                table: "Gallery");

            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Project_ProjectId",
                table: "Gallery");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Article_ArticleId",
                table: "Gallery",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Project_ProjectId",
                table: "Gallery",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
