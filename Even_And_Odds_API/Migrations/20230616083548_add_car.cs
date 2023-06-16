using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Even_And_Odds_API.Migrations
{
    /// <inheritdoc />
    public partial class add_car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegNo",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }
    }
}
