using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrafficManagementSystem.Infrastructure.Migrations
{
    public partial class offenceTypeChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffenceTypeId",
                table: "Offences");

            migrationBuilder.AddColumn<string>(
                name: "OffenceTypeCode",
                table: "Offences",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffenceTypeCode",
                table: "Offences");

            migrationBuilder.AddColumn<int>(
                name: "OffenceTypeId",
                table: "Offences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
