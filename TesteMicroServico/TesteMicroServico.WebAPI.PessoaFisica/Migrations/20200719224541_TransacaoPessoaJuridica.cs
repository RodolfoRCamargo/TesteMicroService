using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TesteMicroServico.WebAPI.PessoaFisica.Migrations
{
    public partial class TransacaoPessoaJuridica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                            name: "TransacaoPessoaJuridica",
                            columns: table => new
                            {
                                Id = table.Column<Guid>(nullable: false),
                                PessoaId = table.Column<Guid>(nullable: true),
                                TipoTransacao = table.Column<string>(nullable: true),
                                Valor = table.Column<double>(nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_TransacaoPessoaJuridica", x => x.Id);
                                table.ForeignKey(
                                    name: "FK_TransacaoPessoaJuridica_Pessoa_PessoaId",
                                    column: x => x.PessoaId,
                                    principalTable: "PessoaJuridica",
                                    principalColumn: "Id",
                                    onUpdate: ReferentialAction.Cascade,
                                    onDelete: ReferentialAction.Cascade);
                            });

            migrationBuilder.CreateIndex(
                name: "IX_TransacaoPessoaJuridica_PessoaId",
                table: "TransacaoPessoaJuridica",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransacaoPessoaJuridica");
        }
    }
}
