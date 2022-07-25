using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiDemo2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portslots",
                columns: table => new
                {
                    SlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruid = table.Column<int>(type: "int", nullable: true),
                    SluserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Enddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portslots", x => x.SlotId);
                });

            migrationBuilder.CreateTable(
                name: "Portusers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    Cost = table.Column<long>(type: "bigint", nullable: true),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Endtime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Usertype = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portusers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portslots");

            migrationBuilder.DropTable(
                name: "Portusers");
        }
    }
}
