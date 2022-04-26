using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrafficManagementSystem.Infrastructure.Migrations
{
    public partial class offenceTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Offence_Types",
                table: "Offence_Types");

            migrationBuilder.RenameTable(
                name: "Offence_Types",
                newName: "OffenceTypes");

            migrationBuilder.AlterColumn<decimal>(
                name: "FineAmount",
                table: "OffenceTypes",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "OffenceTypes",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OffenceTypes",
                table: "OffenceTypes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OffenceTypes",
                table: "OffenceTypes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OffenceTypes");

            migrationBuilder.RenameTable(
                name: "OffenceTypes",
                newName: "Offence_Types");

            migrationBuilder.AlterColumn<decimal>(
                name: "FineAmount",
                table: "Offence_Types",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offence_Types",
                table: "Offence_Types",
                column: "Id");
        }
    }
}
