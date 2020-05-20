using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataSolutions.TransactionExchangeCentre.Migrations
{
    public partial class V007_Channel_Add_DataDirection_DocumentType_Remove_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Channels");

            migrationBuilder.AddColumn<int>(
                name: "DataDirection",
                table: "Channels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "Channels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDirection",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Channels");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Channels",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }
    }
}
