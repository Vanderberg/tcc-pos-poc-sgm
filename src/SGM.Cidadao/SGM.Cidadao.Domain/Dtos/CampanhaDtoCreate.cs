using System;
using System.ComponentModel.DataAnnotations;

namespace SGM.Cidadao.Domain.Dtos
{
    public class CampanhaDtoCreate
    {
        [Required(ErrorMessage = "Título é campo obrigatório.")]
        [StringLength(60, ErrorMessage = "Título deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Data Inicio é campo obrigatório")]
        public DateTime DataInicio { get; set; }
        
        [Required(ErrorMessage = "Data Fim é campo obrigatório")]
        public DateTime DataFim { get; set; }
    }
}