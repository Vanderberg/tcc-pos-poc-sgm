using System;
using SGM.Gestao.Domain.Entities.Enums;
using SGM.Shared.Domain.Entities;

namespace SGM.Gestao.Domain.Entities
{
    public class VagaEntity : BaseEntity
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Status Status { get; set; }
    }
}