using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class upaeudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeType",
                table: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "ChangedOn",
                table: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "TableName",
                table: "AuditTrails");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "AuditTrails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "After",
                table: "AuditTrails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Before",
                table: "AuditTrails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntityName",
                table: "AuditTrails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "AuditTrails",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "After",
                table: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "Before",
                table: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "EntityName",
                table: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "AuditTrails");

            migrationBuilder.AddColumn<string>(
                name: "ChangeType",
                table: "AuditTrails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangedOn",
                table: "AuditTrails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "AuditTrails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EntityId",
                table: "AuditTrails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TableName",
                table: "AuditTrails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
