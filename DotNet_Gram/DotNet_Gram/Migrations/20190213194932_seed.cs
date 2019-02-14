using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet_Gram.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NetGrams",
                columns: new[] { "ID", "Caption", "ImageURL", "NamePoster" },
                values: new object[] { 1, "pic", "url", "Jason" });

            migrationBuilder.InsertData(
                table: "NetGrams",
                columns: new[] { "ID", "Caption", "ImageURL", "NamePoster" },
                values: new object[] { 2, "pic", "URL", "Jennifer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NetGrams",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NetGrams",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
