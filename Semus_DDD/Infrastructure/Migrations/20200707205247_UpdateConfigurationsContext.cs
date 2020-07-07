using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateConfigurationsContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Produto");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Produto",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Produto",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EstoqueProdutos",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    StockID = table.Column<int>(nullable: false),
                    QuantityTotal = table.Column<int>(nullable: false),
                    Quant_Input = table.Column<int>(nullable: false),
                    Quant_Output = table.Column<int>(nullable: false),
                    Quant_Shortage = table.Column<int>(nullable: false),
                    DateInput = table.Column<DateTime>(nullable: false),
                    DateOutput = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueProdutos", x => new { x.ProductID, x.StockID });
                    table.ForeignKey(
                        name: "FK_EstoqueProdutos_Produto_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Produto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstoqueProdutos_Estoque_StockID",
                        column: x => x.StockID,
                        principalTable: "Estoque",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueProdutos_StockID",
                table: "EstoqueProdutos",
                column: "StockID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstoqueProdutos");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ID");
        }
    }
}
