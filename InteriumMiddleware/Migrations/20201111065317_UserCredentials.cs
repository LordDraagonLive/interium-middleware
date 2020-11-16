using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteriumMiddleware.Migrations
{
    public partial class UserCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCredential",
                table: "UserCredential");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "UserCredential");

            migrationBuilder.AlterColumn<string>(
                name: "ExchangeCode",
                table: "UserCredential",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AccessToken",
                table: "UserCredential",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserCredential",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCredential",
                table: "UserCredential",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCredential",
                table: "UserCredential");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserCredential");

            migrationBuilder.AlterColumn<string>(
                name: "ExchangeCode",
                table: "UserCredential",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccessToken",
                table: "UserCredential",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "UserCredential",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCredential",
                table: "UserCredential",
                columns: new[] { "ClientId", "AccessToken", "ExchangeCode" });
        }
    }
}
