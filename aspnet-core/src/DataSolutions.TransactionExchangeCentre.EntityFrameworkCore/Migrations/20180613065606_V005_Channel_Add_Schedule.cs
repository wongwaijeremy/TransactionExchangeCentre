using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataSolutions.TransactionExchangeCentre.Migrations
{
    public partial class V005_Channel_Add_Schedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IntervalValue",
                table: "Channels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OnExactDayTime",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UploadIntervalOption",
                table: "Channels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntervalValue",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "OnExactDayTime",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "UploadIntervalOption",
                table: "Channels");
        }
    }
}
