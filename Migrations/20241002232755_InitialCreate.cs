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
                name: "Comandas",
                columns: table => new
                {
                    ComandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendaId = table.Column<int>(type: "int", nullable: false),
                    CozinhaId = table.Column<int>(type: "int", nullable: false),
                    SituacaoId = table.Column<int>(type: "int", nullable: false),
                    Viagem = table.Column<bool>(type: "bit", nullable: false),
                    FilaVIP = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.ComandaId);
                });

            migrationBuilder.CreateTable(
                name: "Cozinhas",
                columns: table => new
                {
                    CozinhaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cozinhas", x => x.CozinhaId);
                });

            migrationBuilder.CreateTable(
                name: "PratosComandas",
                columns: table => new
                {
                    PratoComandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PratoId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<int>(type: "int", nullable: false),
                    SituacaoId = table.Column<int>(type: "int", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PratosComandas", x => x.PratoComandaId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CozinhaId = table.Column<int>(type: "int", nullable: true),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
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
                });

            migrationBuilder.CreateTable(
                name: "SituacoesComandas",
                columns: table => new
                {
                    SituacaoComandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacoesComandas", x => x.SituacaoComandaId);
                });

            migrationBuilder.CreateTable(
                name: "SituacoesPratosComandas",
                columns: table => new
                {
                    SituacaoPratoComandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacoesPratosComandas", x => x.SituacaoPratoComandaId);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    VendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: false),
                    PrecoTotal = table.Column<double>(type: "float", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.VendaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "Cozinhas");

            migrationBuilder.DropTable(
                name: "PratosComandas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "ProdutosVendas");

            migrationBuilder.DropTable(
                name: "SituacoesComandas");

            migrationBuilder.DropTable(
                name: "SituacoesPratosComandas");

            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
