using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comprador",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CodProduto = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Unidade = table.Column<string>(nullable: false),
                    Medida = table.Column<string>(nullable: false),
                    Preço = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumeroSolicitacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoFornecedor",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(nullable: false),
                    FornecedorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoFornecedor", x => new { x.ProdutoId, x.FornecedorId });
                    table.ForeignKey(
                        name: "FK_ProdutoFornecedor_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoFornecedor_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumeroCotacao = table.Column<string>(nullable: true),
                    ProviderId = table.Column<Guid>(nullable: true),
                    PurchaserId = table.Column<Guid>(nullable: true),
                    ProporsalId = table.Column<Guid>(nullable: true),
                    PrecoTotal = table.Column<double>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    PrazoPagamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cotacao_Solicitacao_ProporsalId",
                        column: x => x.ProporsalId,
                        principalTable: "Solicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotacao_Fornecedor_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotacao_Comprador_PurchaserId",
                        column: x => x.PurchaserId,
                        principalTable: "Comprador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CotacaoProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    PriceId = table.Column<Guid>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotacaoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CotacaoProduto_Cotacao_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Cotacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CotacaoProduto_Produto_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdemCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumeroOrdem = table.Column<string>(nullable: true),
                    Autorizacao = table.Column<bool>(nullable: false),
                    SelectedPriceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemCompra_Cotacao_SelectedPriceId",
                        column: x => x.SelectedPriceId,
                        principalTable: "Cotacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotacao_ProporsalId",
                table: "Cotacao",
                column: "ProporsalId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotacao_ProviderId",
                table: "Cotacao",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotacao_PurchaserId",
                table: "Cotacao",
                column: "PurchaserId");

            migrationBuilder.CreateIndex(
                name: "IX_CotacaoProduto_PriceId",
                table: "CotacaoProduto",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_CotacaoProduto_ProductId",
                table: "CotacaoProduto",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemCompra_SelectedPriceId",
                table: "OrdemCompra",
                column: "SelectedPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFornecedor_FornecedorId",
                table: "ProdutoFornecedor",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotacaoProduto");

            migrationBuilder.DropTable(
                name: "OrdemCompra");

            migrationBuilder.DropTable(
                name: "ProdutoFornecedor");

            migrationBuilder.DropTable(
                name: "Cotacao");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Solicitacao");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Comprador");
        }
    }
}
