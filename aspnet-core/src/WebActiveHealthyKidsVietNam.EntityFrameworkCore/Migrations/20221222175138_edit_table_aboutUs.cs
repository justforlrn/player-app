using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebActiveHealthyKidsVietNam.Migrations
{
    public partial class edit_table_aboutUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AppAboutUss");

            migrationBuilder.AddColumn<string>(
                name: "KeyName",
                table: "AppAboutUss",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Languge",
                table: "AppAboutUss",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyName",
                table: "AppAboutUss");

            migrationBuilder.DropColumn(
                name: "Languge",
                table: "AppAboutUss");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "AppAboutUss",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
