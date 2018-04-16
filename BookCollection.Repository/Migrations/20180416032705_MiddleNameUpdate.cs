using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCollection.Repository.Migrations
{
    public partial class MiddleNameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiddleInitial",
                table: "User",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "MiddleInitial",
                table: "Author",
                newName: "MiddleName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 201, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 946, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 201, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 946, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "BookCollection",
                nullable: false,
                defaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 204, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 949, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BookCollection",
                nullable: false,
                defaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 204, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 949, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Book",
                nullable: false,
                defaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 202, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 948, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Book",
                nullable: false,
                defaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 202, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 947, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 202, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 947, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 202, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 947, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "User",
                newName: "MiddleInitial");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Author",
                newName: "MiddleInitial");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 946, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 201, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 946, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 201, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "BookCollection",
                nullable: false,
                defaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 949, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 204, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "BookCollection",
                nullable: false,
                defaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 949, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 204, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Book",
                nullable: false,
                defaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 948, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 202, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Book",
                nullable: false,
                defaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 947, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 202, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 947, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 202, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Author",
                nullable: false,
                defaultValue: new DateTime(2018, 3, 12, 3, 39, 46, 947, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 4, 16, 3, 27, 5, 202, DateTimeKind.Utc));
        }
    }
}
