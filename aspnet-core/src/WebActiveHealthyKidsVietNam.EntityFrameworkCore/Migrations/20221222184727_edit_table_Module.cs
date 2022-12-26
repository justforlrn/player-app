using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebActiveHealthyKidsVietNam.Migrations
{
    public partial class edit_table_Module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "AppModules",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "Languge",
                table: "AppAboutUss",
                newName: "Language");

            migrationBuilder.AddColumn<string>(
                name: "KeyName",
                table: "AppModules",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyName",
                table: "AppModules");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "AppModules",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "AppAboutUss",
                newName: "Languge");
        }
    }
}
