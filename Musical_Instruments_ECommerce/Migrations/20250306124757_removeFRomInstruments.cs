using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musical_Instruments_ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class removeFRomInstruments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_Accounts_AccountId",
                table: "Instruments");

            migrationBuilder.DropIndex(
                name: "IX_Instruments_AccountId",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Instruments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Instruments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_AccountId",
                table: "Instruments",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_Accounts_AccountId",
                table: "Instruments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
