using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebActiveHealthyKidsVietNam.Migrations
{
    public partial class edit_table_slide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "AppSlideLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "AppSlideLists");
        }
    }
}
