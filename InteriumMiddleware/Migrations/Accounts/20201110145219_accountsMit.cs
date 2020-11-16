using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteriumMiddleware.Migrations.Accounts
{
    public partial class accountsMit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account_Number",
                columns: table => new
                {
                    number = table.Column<string>(nullable: false),
                    swift_bic = table.Column<string>(nullable: true),
                    sort_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_Number", x => x.number);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    provider_id = table.Column<string>(nullable: false),
                    display_name = table.Column<string>(nullable: true),
                    logo_uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.provider_id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    account_id = table.Column<string>(nullable: false),
                    update_timestamp = table.Column<DateTime>(nullable: false),
                    account_type = table.Column<string>(nullable: true),
                    display_name = table.Column<string>(nullable: true),
                    currency = table.Column<string>(nullable: true),
                    account_numbernumber = table.Column<string>(nullable: true),
                    provider_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_Account_Account_Number_account_numbernumber",
                        column: x => x.account_numbernumber,
                        principalTable: "Account_Number",
                        principalColumn: "number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Provider_provider_id",
                        column: x => x.provider_id,
                        principalTable: "Provider",
                        principalColumn: "provider_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_account_numbernumber",
                table: "Account",
                column: "account_numbernumber");

            migrationBuilder.CreateIndex(
                name: "IX_Account_provider_id",
                table: "Account",
                column: "provider_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Account_Number");

            migrationBuilder.DropTable(
                name: "Provider");
        }
    }
}
