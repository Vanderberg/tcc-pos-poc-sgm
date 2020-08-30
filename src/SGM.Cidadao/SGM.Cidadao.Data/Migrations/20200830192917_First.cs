using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGM.Cidadao.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoliticaPublica",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Titulo = table.Column<string>(maxLength: 60, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: false),
                    DescricaoArea = table.Column<int>(nullable: false),
                    OrcamentoPrevisto = table.Column<double>(nullable: false),
                    OrcamentoRealizado = table.Column<double>(nullable: false),
                    NomeResponsavel = table.Column<string>(nullable: false),
                    DataPrevista = table.Column<DateTime>(nullable: false),
                    DataRealizada = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticaPublica", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoliticaPublica");
        }
    }
}
