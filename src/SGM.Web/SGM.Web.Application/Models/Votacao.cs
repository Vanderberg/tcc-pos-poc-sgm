using System;
using System.ComponentModel.DataAnnotations;

namespace SGM.Web.Application.Models
{
    public class Votacao
    {
        public Guid Id { get; set; }
        public int Votos { get; set; }
        public Guid CampanhaID { get; set; }
        
        [Display(Name = "Campanha")]
        public string CampanhaDescricao { get; set; }
        public Guid PoliticaPublicaID { get; set; }
        [Display(Name = "Titulo")]
        public string PoliticaTitulo { get; set; }
    }
}