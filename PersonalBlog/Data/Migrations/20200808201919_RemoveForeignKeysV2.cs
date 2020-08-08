using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Data.Migrations
{
    public partial class RemoveForeignKeysV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Article_ArticleId",
                table: "Gallery");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Article_ArticleId",
                table: "Gallery",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Article_ArticleId",
                table: "Gallery");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Article_ArticleId",
                table: "Gallery",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id");
        }
    }
}
