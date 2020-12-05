using System;
using SGM.Gestao.Domain.Entities.Enums;
using SGM.Shared.Domain.Entities;

namespace SGM.Gestao.Domain.Entities
{
    public class CandidatoVagaEntity : BaseEntity
    {
        public StatusCandidato StatusCandidato { get; set; }
        public Guid ColaboradorId { get; set; }
        public Guid VagaId { get; set; }
    }
}