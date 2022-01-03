using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagValue = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => new { x.TagId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_ArticleTag_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paragraph",
                columns: table => new
                {
                    ParagraphId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraph", x => x.ParagraphId);
                    table.ForeignKey(
                        name: "FK_Paragraph_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("02a95519-a82b-4b57-8c51-05d261e27c05"), "Physics" },
                    { new Guid("098d3a1e-f70d-445a-8487-72ca58fcc596"), "Health" },
                    { new Guid("0e18c37c-2a15-44fc-ace9-73e15d2a5d03"), "Politics" },
                    { new Guid("3c723d99-f1a2-4ce8-965b-7b037c87f83e"), "Well-Being" },
                    { new Guid("d90aab27-c51d-46d6-8471-130e7390024a"), "Psycology" },
                    { new Guid("f473dafa-67a8-4f80-ba84-684a849965ba"), "Metaphyysics" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagValue" },
                values: new object[,]
                {
                    { new Guid("0e617317-64c7-4e53-bf27-396d93c87c82"), "right-politics" },
                    { new Guid("0eea77a8-e163-4b52-b0dc-d67fd7eec682"), "Anxiety" },
                    { new Guid("61191da9-4363-47ef-9745-996b9410dce4"), "phylosophy" },
                    { new Guid("975f1f23-971f-45f0-bcf8-8a354e4e1cf9"), "Personal" },
                    { new Guid("ce9f0204-8ded-4e5b-b044-328455f0c3f0"), "ecology" },
                    { new Guid("e7a6fd40-bde2-4b29-a9cd-de69093296ca"), "Boudism" },
                    { new Guid("eee4a769-de0c-4e4d-9b4e-8f50406a5fac"), "left-politics" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "CategoryId", "CreatedDate", "Summary", "Title" },
                values: new object[,]
                {
                    { new Guid("1f16a542-b836-4152-893c-a0884baf210c"), new Guid("0e18c37c-2a15-44fc-ace9-73e15d2a5d03"), new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified), "SummaryArticleOne", "TitleArticleOne" },
                    { new Guid("ab52df6b-5881-4e09-a4f6-959200b54376"), new Guid("0e18c37c-2a15-44fc-ace9-73e15d2a5d03"), new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified), "SummaryArticleOne", "TitleArticleOne" },
                    { new Guid("bb296082-a5e4-4b5c-99e3-4595144be332"), new Guid("02a95519-a82b-4b57-8c51-05d261e27c05"), new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified), "SummaryArticleOne", "TitleArticleOne" },
                    { new Guid("d6bbcf6b-a935-46cc-9359-f52b6f2f11f1"), new Guid("02a95519-a82b-4b57-8c51-05d261e27c05"), new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified), "SummaryArticleOne", "TitleArticleOne" },
                    { new Guid("eea19341-1122-4ba8-b94c-404348adcc00"), new Guid("02a95519-a82b-4b57-8c51-05d261e27c05"), new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified), "SummaryArticleOne", "TitleArticleOne" }
                });

            migrationBuilder.InsertData(
                table: "ArticleTag",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[,]
                {
                    { new Guid("ab52df6b-5881-4e09-a4f6-959200b54376"), new Guid("0e617317-64c7-4e53-bf27-396d93c87c82") },
                    { new Guid("1f16a542-b836-4152-893c-a0884baf210c"), new Guid("0eea77a8-e163-4b52-b0dc-d67fd7eec682") },
                    { new Guid("1f16a542-b836-4152-893c-a0884baf210c"), new Guid("61191da9-4363-47ef-9745-996b9410dce4") },
                    { new Guid("1f16a542-b836-4152-893c-a0884baf210c"), new Guid("975f1f23-971f-45f0-bcf8-8a354e4e1cf9") },
                    { new Guid("ab52df6b-5881-4e09-a4f6-959200b54376"), new Guid("ce9f0204-8ded-4e5b-b044-328455f0c3f0") },
                    { new Guid("1f16a542-b836-4152-893c-a0884baf210c"), new Guid("e7a6fd40-bde2-4b29-a9cd-de69093296ca") },
                    { new Guid("ab52df6b-5881-4e09-a4f6-959200b54376"), new Guid("eee4a769-de0c-4e4d-9b4e-8f50406a5fac") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_ArticleId",
                table: "ArticleTag",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraph_ArticleId",
                table: "Paragraph",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTag");

            migrationBuilder.DropTable(
                name: "Paragraph");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
