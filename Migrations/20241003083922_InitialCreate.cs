using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SitemaDeComandas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cozinhas",
                columns: table => new
                {
                    CozinhaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cozinhas", x => x.CozinhaId);
                });

            migrationBuilder.CreateTable(
                name: "FormasPagamentos",
                columns: table => new
                {
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamentos", x => x.FormaPagamentoId);
                });

            migrationBuilder.CreateTable(
                name: "SituacoesComandas",
                columns: table => new
                {
                    SituacaoComandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacoesComandas", x => x.SituacaoComandaId);
                });

            migrationBuilder.CreateTable(
                name: "SituacoesVendas",
                columns: table => new
                {
                    SituacaoVendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacoesVendas", x => x.SituacaoVendaId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CozinhaId = table.Column<int>(type: "int", nullable: true),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Cozinhas_CozinhaId",
                        column: x => x.CozinhaId,
                        principalTable: "Cozinhas",
                        principalColumn: "CozinhaId");
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    VendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: false),
                    SituacaoVendaId = table.Column<int>(type: "int", nullable: false),
                    PrecoTotal = table.Column<double>(type: "float", nullable: false),
                    DataHoraVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.VendaId);
                    table.ForeignKey(
                        name: "FK_Vendas_FormasPagamentos_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormasPagamentos",
                        principalColumn: "FormaPagamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_SituacoesVendas_SituacaoVendaId",
                        column: x => x.SituacaoVendaId,
                        principalTable: "SituacoesVendas",
                        principalColumn: "SituacaoVendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    ComandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendaId = table.Column<int>(type: "int", nullable: false),
                    CozinhaId = table.Column<int>(type: "int", nullable: false),
                    SituacaoComandaId = table.Column<int>(type: "int", nullable: false),
                    Viagem = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comandas_Cozinhas_CozinhaId",
                        column: x => x.CozinhaId,
                        principalTable: "Cozinhas",
                        principalColumn: "CozinhaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comandas_SituacoesComandas_SituacaoComandaId",
                        column: x => x.SituacaoComandaId,
                        principalTable: "SituacoesComandas",
                        principalColumn: "SituacaoComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comandas_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "VendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosVendas",
                columns: table => new
                {
                    ProdutoVendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<double>(type: "float", nullable: false),
                    PrecoTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosVendas", x => x.ProdutoVendaId);
                    table.ForeignKey(
                        name: "FK_ProdutosVendas_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosVendas_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "VendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosComandas",
                columns: table => new
                {
                    PratoComandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosComandas", x => x.PratoComandaId);
                    table.ForeignKey(
                        name: "FK_ProdutosComandas_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosComandas_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_CozinhaId",
                table: "Comandas",
                column: "CozinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_SituacaoComandaId",
                table: "Comandas",
                column: "SituacaoComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_VendaId",
                table: "Comandas",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CozinhaId",
                table: "Produtos",
                column: "CozinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosComandas_ComandaId",
                table: "ProdutosComandas",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosComandas_ProdutoId",
                table: "ProdutosComandas",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosVendas_ProdutoId",
                table: "ProdutosVendas",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosVendas_VendaId",
                table: "ProdutosVendas",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FormaPagamentoId",
                table: "Vendas",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_SituacaoVendaId",
                table: "Vendas",
                column: "SituacaoVendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosComandas");

            migrationBuilder.DropTable(
                name: "ProdutosVendas");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "SituacoesComandas");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Cozinhas");

            migrationBuilder.DropTable(
                name: "FormasPagamentos");

            migrationBuilder.DropTable(
                name: "SituacoesVendas");
        }
    }
}
