using System;
using System.ComponentModel.DataAnnotations;

namespace SGM.Web.Application.Models
{
    public class Campanha
    {
        public Guid Id { get; set; }
        
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }
    }
}