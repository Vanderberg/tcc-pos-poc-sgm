using System;
using SGM.Gestao.Domain.Entities.Enums;
using SGM.Shared.Domain.Entities;

namespace SGM.Gestao.Domain.Entities
{
    public class TreinamentoEntity : BaseEntity
    {
        public string Objetivo { get; set; }
        public string Descricao { get; set; }
        public string Cronogrmana { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Status Status { get; set; }
        
        
    }
}