using Microsoft.EntityFrameworkCore.Migrations;

namespace InteriumMiddleware.Migrations
{
    public partial class UserCreds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientCredential",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    ClientSecret = table.Column<string>(nullable: true),
                    RedirectUri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCredential", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "UserCredential",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    AccessToken = table.Column<string>(nullable: false),
                    ExchangeCode = table.Column<string>(nullable: false),
                    ClientCredentialsClientId = table.Column<string>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true),
                    CredentialsId = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredential", x => new { x.ClientId, x.AccessToken, x.ExchangeCode });
                    table.ForeignKey(
                        name: "FK_UserCredential_ClientCredential_ClientCredentialsClientId",
                        column: x => x.ClientCredentialsClientId,
                        principalTable: "ClientCredential",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCredential_ClientCredentialsClientId",
                table: "UserCredential",
                column: "ClientCredentialsClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCredential");

            migrationBuilder.DropTable(
                name: "ClientCredential");
        }
    }
}
