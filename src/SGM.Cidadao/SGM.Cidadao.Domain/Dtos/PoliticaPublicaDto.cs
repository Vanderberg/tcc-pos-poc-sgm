using System;
using System.ComponentModel.DataAnnotations;
using SGM.Cidadao.Domain.Entities.Enums;

namespace SGM.Cidadao.Domain.Dtos
{
    public class PoliticaPublicaDto
    {
        [Required(ErrorMessage = "Título é campo obrigatório.")]
        [StringLength(60, ErrorMessage = "Título deve ter no máximo {1} caracteres")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "Descrição é campo obrigatório")]
        [StringLength(1000, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Descrição da Área é campo obrigatório")]
        public Area DescricaoArea { get; set; }
        
        [Required(ErrorMessage = "Orçamento Previsto da Área é campo obrigatório")]
        public double OrcamentoPrevisto { get; set; }
        
        [Required(ErrorMessage = "Nome Responsável é campo obrigatório")]
        public string NomeResponsavel { get; set; }
        
        [Required(ErrorMessage = "Data Prevista é campo obrigatório")]
        public DateTime DataPrevista { get; set; }
    }
}