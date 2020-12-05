using System;
using System.ComponentModel.DataAnnotations;
using SGM.Gestao.Domain.Entities.Enums;

namespace SGM.Gestao.Domain.Dtos
{
    public class CanditatoDtoCreate
    {
        [Required(ErrorMessage = "StatusCandidato é obrigatório.")]
        public StatusCandidato StatusCandidato { get; set; }
        
        [Required(ErrorMessage = "Colaborador Id é obrigatório.")]
        public string ColaboradorId { get; set; }
        
        [Required(ErrorMessage = "Vaga Id é obrigatório.")]
        public Guid VagaId { get; set; }   
    }
}