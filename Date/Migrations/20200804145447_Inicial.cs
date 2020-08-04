using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Date.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TituloRecurso = table.Column<string>(type: "varchar(200)", nullable: true),
                    DescricaoRecurso = table.Column<string>(type: "varchar(999)", nullable: true),
                    NumeroVotacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroVotacoes",
                columns: table => new
                {
                    FuncionarioId = table.Column<Guid>(nullable: false),
                    RecursoId = table.Column<Guid>(nullable: false),
                    ComentarioRecurso = table.Column<string>(type: "varchar(999)", nullable: false),
                    DataVotacaoRecurso = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroVotacoes", x => new { x.FuncionarioId, x.RecursoId });
                    table.ForeignKey(
                        name: "FK_RegistroVotacoes_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroVotacoes_Recursos_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroVotacoes_RecursoId",
                table: "RegistroVotacoes",
                column: "RecursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroVotacoes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Recursos");
        }
    }
}
