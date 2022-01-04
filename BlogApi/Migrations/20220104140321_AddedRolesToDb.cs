using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("1f16a542-b836-4152-893c-a0884baf210c"),
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 15, 3, 20, 897, DateTimeKind.Local).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("ab52df6b-5881-4e09-a4f6-959200b54376"),
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 15, 3, 20, 897, DateTimeKind.Local).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("bb296082-a5e4-4b5c-99e3-4595144be332"),
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 15, 3, 20, 897, DateTimeKind.Local).AddTicks(2815));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("d6bbcf6b-a935-46cc-9359-f52b6f2f11f1"),
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 15, 3, 20, 897, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("eea19341-1122-4ba8-b94c-404348adcc00"),
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 15, 3, 20, 897, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "81edfecf-f9dc-4e36-bc8e-d6be270a7aa8", "417fc5c7-5c81-4db0-83bd-d1df36b0ccec", "Manager", "MANAGER" },
                    { "bc7bda4e-35e1-42a4-abee-2846cd098601", "4dcf9d1f-d86c-43e1-978a-8096e19aaee5", "Client", "CLIENT" },
                    { "f8e145f6-4568-43d3-9756-384ba74d4b8f", "827549e3-0dbb-4695-922e-f358996b06d2", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81edfecf-f9dc-4e36-bc8e-d6be270a7aa8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc7bda4e-35e1-42a4-abee-2846cd098601");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8e145f6-4568-43d3-9756-384ba74d4b8f");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("1f16a542-b836-4152-893c-a0884baf210c"),
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 14, 50, 4, 866, DateTimeKind.Local).AddTicks(8925));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("ab52df6b-5881-4e09-a4f6-959200b54376"),
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 14, 50, 4, 866, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("bb296082-a5e4-4b5c-99e3-4595144be332"),
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 14, 50, 4, 866, DateTimeKind.Local).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("d6bbcf6b-a935-46cc-9359-f52b6f2f11f1"),
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 14, 50, 4, 866, DateTimeKind.Local).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("eea19341-1122-4ba8-b94c-404348adcc00"),
                column: "CreatedDate",
                value: new DateTime(2022, 1, 4, 14, 50, 4, 866, DateTimeKind.Local).AddTicks(8932));
        }
    }
}
