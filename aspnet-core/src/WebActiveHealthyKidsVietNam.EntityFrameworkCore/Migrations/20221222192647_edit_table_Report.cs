using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebActiveHealthyKidsVietNam.Migrations
{
    public partial class edit_table_Report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SlideType",
                table: "AppSlideLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "AppReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "AppModuleHomes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlideType",
                table: "AppSlideLists");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AppReports");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "AppModuleHomes");
        }
    }
}
