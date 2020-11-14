using System;
using System.ComponentModel.DataAnnotations;
using SGM.Gestao.Domain.Entities.Enums;

namespace SGM.Gestao.Domain.Dtos
{
    public class TreinamentoDtoCreate
    {
        [Required(ErrorMessage = "Descrição da vaga obrigatório.")]     
        [StringLength(250, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Objetivo { get; set; }
        
        [Required(ErrorMessage = "Descrição da vaga obrigatório.")]     
        [StringLength(60, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Descrição da vaga é obrigatório.")]
        public string Cronogrmana { get; set; }
        
        [Required(ErrorMessage = "Data Fim é obrigatório.")]
        public DateTime DataInicio { get; set; }
        
        [Required(ErrorMessage = "Data Fim é obrigatório.")]
        public DateTime DataFim { get; set; }
        
        [Required(ErrorMessage = "Status é obrigatório.")]
        public Status Status { get; set; }
    }
}