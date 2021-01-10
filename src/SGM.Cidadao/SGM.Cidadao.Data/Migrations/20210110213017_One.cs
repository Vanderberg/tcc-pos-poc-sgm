using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGM.Cidadao.Data.Migrations
{
    public partial class One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campanha",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 60, nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanha", x => x.Id);
                });

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
                    NomeResponsavel = table.Column<string>(maxLength: 60, nullable: false),
                    DataPrevista = table.Column<DateTime>(nullable: false),
                    DataRealizada = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticaPublica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Votos = table.Column<int>(nullable: false),
                    CampanhaID = table.Column<Guid>(nullable: false),
                    PoliticaPublicaID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campanha");

            migrationBuilder.DropTable(
                name: "PoliticaPublica");

            migrationBuilder.DropTable(
                name: "Votacao");
        }
    }
}
