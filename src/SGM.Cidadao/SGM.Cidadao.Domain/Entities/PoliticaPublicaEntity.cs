using System;
using System.Data;
using SGM.Cidadao.Domain.Entities.Enums;
using SGM.Shared.Domain.Entities;

namespace SGM.Cidadao.Domain.Entities
{
    public class PoliticaPublicaEntity : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Area DescricaoArea { get; set; }
        public double OrcamentoPrevisto { get; set; }
        public double OrcamentoRealizado { get; set; }
        public string NomeResponsavel { get; set; }
        public DateTime DataPrevista { get; set; }
        public DateTime DataRealizada { get; set; }    
    }
}