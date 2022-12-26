using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebActiveHealthyKidsVietNam.Migrations
{
    public partial class edit_table_Information : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AppInformations",
                newName: "KeyName");

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "AppInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "AppInformations");

            migrationBuilder.RenameColumn(
                name: "KeyName",
                table: "AppInformations",
                newName: "Name");
        }
    }
}
