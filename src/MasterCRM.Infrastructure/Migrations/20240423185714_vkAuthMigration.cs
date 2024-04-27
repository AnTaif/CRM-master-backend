using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class vkAuthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VkId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VkId",
                table: "AspNetUsers");
        }
    }
}
