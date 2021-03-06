using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SGM.Gestao.Domain.Entities.Enums;

namespace SGM.Web.Application.Models
{
    public class Vaga
    {
        public Guid Id { get; set; }
        
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        
        [Display(Name = "Data inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]        
        public DateTime DataInicio { get; set; }
        
        [Display(Name = "Data fim")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]        
        public DateTime DataFim { get; set; }
        
        [Display(Name = "Status")]
        public Status Status { get; set; }
    }
}