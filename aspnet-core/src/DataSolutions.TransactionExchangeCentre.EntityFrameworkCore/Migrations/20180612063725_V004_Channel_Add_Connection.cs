using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataSolutions.TransactionExchangeCentre.Migrations
{
    public partial class V004_Channel_Add_Connection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConnectionStatus",
                table: "Channels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DestinationPath",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtensionName",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FtpAddress",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FtpPassword",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FtpProtocol",
                table: "Channels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FtpUserName",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceLocalPath",
                table: "Channels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionStatus",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "DestinationPath",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "ExtensionName",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "FtpAddress",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "FtpPassword",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "FtpProtocol",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "FtpUserName",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "SourceLocalPath",
                table: "Channels");
        }
    }
}
