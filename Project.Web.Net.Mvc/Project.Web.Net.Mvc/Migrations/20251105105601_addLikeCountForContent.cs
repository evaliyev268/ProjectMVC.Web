using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Web.Net.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class addLikeCountForContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Contents",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Contents");
        }
    }
}
