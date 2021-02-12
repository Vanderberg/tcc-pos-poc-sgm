using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SGM.Cidadao.Domain.Entities.Enums;

namespace SGM.Web.Application.Models
{
    public class PoliticaPublica
    {
        public Guid Id { get; set; }
        
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        
        [Display(Name = "Descrição área" )]
        public Area DescricaoArea { get; set; }
        [Display(Name = "Orçamento previsto" )]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double OrcamentoPrevisto { get; set; }
        [Display(Name = "Orçamento realizado" )]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double OrcamentoRealizado { get; set; }
        [Display(Name = "Nome responsável" )]
        public string NomeResponsavel { get; set; }
        
        [Display(Name = "Data prevista" )]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPrevista { get; set; }
        [Display(Name = "Data realizado" )]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataRealizada { get; set; }   
    }
}