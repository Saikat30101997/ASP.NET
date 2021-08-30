using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEntityFrameWork.Migrations.Training
{
    public partial class AddCompanyandStockPrice1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_CompanyId",
                table: "StockPrices",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices");

            migrationBuilder.DropIndex(
                name: "IX_StockPrices_CompanyId",
                table: "StockPrices");
        }
    }
}
