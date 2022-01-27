using Microsoft.EntityFrameworkCore.Migrations;

namespace SushiSite.Migrations
{
    public partial class addpropertyinordermodelforcheckisaddedtocart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAddedToCart",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAddedToCart",
                table: "Orders");
        }
    }
}
