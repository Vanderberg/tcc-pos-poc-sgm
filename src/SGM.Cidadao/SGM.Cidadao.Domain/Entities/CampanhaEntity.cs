using System;
using System.Collections.Generic;
using SGM.Shared.Domain.Entities;

namespace SGM.Cidadao.Domain.Entities
{
    public class CampanhaEntity : BaseEntity
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}