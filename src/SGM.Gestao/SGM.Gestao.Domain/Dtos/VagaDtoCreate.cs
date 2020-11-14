using System;
using System.ComponentModel.DataAnnotations;
using SGM.Gestao.Domain.Entities.Enums;

namespace SGM.Gestao.Domain.Dtos
{
    public class VagaDtoCreate
    {
        [Required(ErrorMessage = "Descricao da vaga obrigatório.")]     
        [StringLength(60, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Data Inicio é obrigatório.")]
        public DateTime DataInicio { get; set; }
        
        [Required(ErrorMessage = "Data Fim obrigatório.")]
        public DateTime DataFim { get; set; }
        
        [Required(ErrorMessage = "Status é obrigatório.")]
        public Status Status { get; set; }
    }
}