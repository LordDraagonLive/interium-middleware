using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteriumMiddleware.Migrations
{
    public partial class UserCredentials1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCredential_ClientCredential_ClientCredentialsClientId",
                table: "UserCredential");

            migrationBuilder.DropIndex(
                name: "IX_UserCredential_ClientCredentialsClientId",
                table: "UserCredential");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCredential",
                table: "ClientCredential");

            migrationBuilder.DropColumn(
                name: "ClientCredentialsClientId",
                table: "UserCredential");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientCredentialsId",
                table: "UserCredential",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "ClientCredential",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ClientCredential",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCredential",
                table: "ClientCredential",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredential_ClientCredentialsId",
                table: "UserCredential",
                column: "ClientCredentialsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCredential_ClientCredential_ClientCredentialsId",
                table: "UserCredential",
                column: "ClientCredentialsId",
                principalTable: "ClientCredential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCredential_ClientCredential_ClientCredentialsId",
                table: "UserCredential");

            migrationBuilder.DropIndex(
                name: "IX_UserCredential_ClientCredentialsId",
                table: "UserCredential");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCredential",
                table: "ClientCredential");

            migrationBuilder.DropColumn(
                name: "ClientCredentialsId",
                table: "UserCredential");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClientCredential");

            migrationBuilder.AddColumn<string>(
                name: "ClientCredentialsClientId",
                table: "UserCredential",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "ClientCredential",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCredential",
                table: "ClientCredential",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredential_ClientCredentialsClientId",
                table: "UserCredential",
                column: "ClientCredentialsClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCredential_ClientCredential_ClientCredentialsClientId",
                table: "UserCredential",
                column: "ClientCredentialsClientId",
                principalTable: "ClientCredential",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
