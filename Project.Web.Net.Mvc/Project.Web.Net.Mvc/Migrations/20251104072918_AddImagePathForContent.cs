using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Web.Net.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathForContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Contents",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Contents");
        }
    }
}
