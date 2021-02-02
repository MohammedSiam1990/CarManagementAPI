using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubManagementAPI.Migrations
{
    public partial class CarCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarCards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarNumber = table.Column<int>(nullable: false),
                    TypeCar = table.Column<int>(nullable: false),
                    TypeCarName = table.Column<string>(nullable: true),
                    Nationality = table.Column<int>(nullable: false),
                    NationalityName = table.Column<string>(nullable: true),
                    CarModel = table.Column<int>(nullable: false),
                    CarModelName = table.Column<string>(nullable: true),
                    ScheduledCars = table.Column<int>(nullable: false),
                    ExistingCars = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
                    CarCarAdded = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCards", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCards");
        }
    }
}
