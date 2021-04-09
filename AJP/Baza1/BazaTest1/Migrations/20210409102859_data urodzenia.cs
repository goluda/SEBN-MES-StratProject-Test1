using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BazaTest1.Migrations
{
    public partial class dataurodzenia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dataUrodzenia",
                table: "ludziki",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataUrodzenia",
                table: "ludziki");
        }
    }
}
