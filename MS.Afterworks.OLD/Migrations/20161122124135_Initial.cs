using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Smiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    IpAddress = table.Column<string>(nullable: true),
                    IsHappy = table.Column<bool>(nullable: false),
                    Why = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Smiles");
        }
    }
}
