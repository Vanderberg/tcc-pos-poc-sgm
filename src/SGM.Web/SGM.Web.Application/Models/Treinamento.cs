using System;
using System.ComponentModel.DataAnnotations;
using SGM.Gestao.Domain.Entities.Enums;

namespace SGM.Web.Application.Models
{
    public class Treinamento
    {
        public Guid Id { get; set; }
        
        public string Objetivo { get; set; }
        
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        
        public string Cronogrmana { get; set; }
        
        [Display(Name = "Data Início")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }
        
        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }
        
        public Status Status { get; set; }
    }
}