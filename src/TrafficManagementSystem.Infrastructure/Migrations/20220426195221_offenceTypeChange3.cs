using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrafficManagementSystem.Infrastructure.Migrations
{
    public partial class offenceTypeChange3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OffenceTypeId",
                table: "Offences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffenceTypeId",
                table: "Offences");
        }
    }
}
