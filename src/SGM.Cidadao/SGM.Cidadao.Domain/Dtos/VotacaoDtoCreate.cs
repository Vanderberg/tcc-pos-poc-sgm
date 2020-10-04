using System;
using System.ComponentModel.DataAnnotations;

namespace SGM.Cidadao.Domain.Dtos
{
    public class VotacaoDtoCreate
    {
        [Required(ErrorMessage = "Título é campo obrigatório.")]
        public Guid CampanhaID { get; set; }
        
        [Required(ErrorMessage = "Título é campo obrigatório.")]
        public Guid PoliticaPublicaID { get; set; }   
    }
}