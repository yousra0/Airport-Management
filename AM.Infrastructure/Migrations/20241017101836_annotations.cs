﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class annotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_PassengersId",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PassengersId",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneId",
                table: "Flights",
                newName: "PlaneFk");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                newName: "IX_Flights_PlaneFk");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Passengers",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengersPassportNumber",
                table: "FlightPassenger",
                type: "nvarchar(7)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "PassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightId", "PassengersPassportNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "FlightPassenger",
                column: "PassengersPassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassportNumber",
                table: "FlightPassenger",
                column: "PassengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneFk",
                table: "Flights",
                column: "PlaneFk",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneFk",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneFk",
                table: "Flights",
                newName: "PlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneFk",
                table: "Flights",
                newName: "IX_Flights_PlaneId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PassengersId",
                table: "FlightPassenger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightId", "PassengersId" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_PassengersId",
                table: "FlightPassenger",
                column: "PassengersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersId",
                table: "FlightPassenger",
                column: "PassengersId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
