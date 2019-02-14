using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet_Gram.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetGrams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamePoster = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetGrams", x => x.ID);
                });

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
            migrationBuilder.DropTable(
                name: "NetGrams");
        }
    }
}
