using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Data.Migrations
{
    public partial class NewDBConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Gallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 15000, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagsJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_ArticleId",
                table: "Gallery",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_UserId",
                table: "Article",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gallery_Article_ArticleId",
                table: "Gallery",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gallery_Article_ArticleId",
                table: "Gallery");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Gallery_ArticleId",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Gallery");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
