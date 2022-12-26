using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebActiveHealthyKidsVietNam.Migrations
{
    public partial class editforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppInformations_AppInformations_ModuleId",
                table: "AppInformations");

            migrationBuilder.DropIndex(
                name: "IX_AppInformations_ModuleId",
                table: "AppInformations");

            migrationBuilder.AddForeignKey(
                name: "FK_AppInformations_AppModules_Id",
                table: "AppInformations",
                column: "Id",
                principalTable: "AppModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppInformations_AppModules_Id",
                table: "AppInformations");

            migrationBuilder.CreateIndex(
                name: "IX_AppInformations_ModuleId",
                table: "AppInformations",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppInformations_AppInformations_ModuleId",
                table: "AppInformations",
                column: "ModuleId",
                principalTable: "AppInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
