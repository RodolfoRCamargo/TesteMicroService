using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteMicroServico.WebAPI.PessoaFisica.Migrations
{
    public partial class Transacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransacaoPessoaFisica",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PessoaId = table.Column<Guid>(nullable: true),
                    TipoTransacao = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacaoPessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransacaoPessoaFisica_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransacaoPessoaFisica_PessoaId",
                table: "TransacaoPessoaFisica",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransacaoPessoaFisica");            
        }
    }
}
