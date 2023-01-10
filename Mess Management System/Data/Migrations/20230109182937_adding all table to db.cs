using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mess_Management_System.Data.Migrations
{
    public partial class addingalltabletodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bazars",
                columns: table => new
                {
                    bazarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bazars", x => x.bazarId);
                });

            migrationBuilder.CreateTable(
                name: "DailyMeals",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Breakfast = table.Column<int>(type: "int", nullable: false),
                    Lunch = table.Column<int>(type: "int", nullable: false),
                    Dinner = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMeals", x => x.MealId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyBazars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    HouseRent = table.Column<double>(type: "float", nullable: false),
                    GassBill = table.Column<double>(type: "float", nullable: false),
                    BuaBill = table.Column<double>(type: "float", nullable: false),
                    ElectricityBill = table.Column<double>(type: "float", nullable: false),
                    InternetBill = table.Column<double>(type: "float", nullable: false),
                    WaterBill = table.Column<double>(type: "float", nullable: false),
                    DirtCost = table.Column<double>(type: "float", nullable: false),
                    FoodCost = table.Column<double>(type: "float", nullable: false),
                    PerviousDue = table.Column<double>(type: "float", nullable: false),
                    PersonalLoan = table.Column<double>(type: "float", nullable: false),
                    TotalMeal = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    TotalBazarCost = table.Column<double>(type: "float", nullable: false),
                    TotalPayableCost = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBazars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyBazarSetups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseRent = table.Column<double>(type: "float", nullable: false),
                    GassBill = table.Column<double>(type: "float", nullable: false),
                    BuaBill = table.Column<double>(type: "float", nullable: false),
                    ElectricityBill = table.Column<double>(type: "float", nullable: false),
                    InternetBill = table.Column<double>(type: "float", nullable: false),
                    WaterBill = table.Column<double>(type: "float", nullable: false),
                    DirtCost = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBazarSetups", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bazars");

            migrationBuilder.DropTable(
                name: "DailyMeals");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "MonthlyBazars");

            migrationBuilder.DropTable(
                name: "MonthlyBazarSetups");
        }
    }
}
