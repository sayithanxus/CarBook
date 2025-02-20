using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_add_RentACarProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "PickUpTime",
                table: "RentACarProcess",
                type: "Time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PickUpDate",
                table: "RentACarProcess",
                type: "Date",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "DropOffTime",
                table: "RentACarProcess",
                type: "Time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DropOffDate",
                table: "RentACarProcess",
                type: "Date",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "PickUpTime",
                table: "RentACarProcess",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "Time");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "PickUpDate",
                table: "RentACarProcess",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "Date");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DropOffTime",
                table: "RentACarProcess",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "Time");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DropOffDate",
                table: "RentACarProcess",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "Date");
        }
    }
}
