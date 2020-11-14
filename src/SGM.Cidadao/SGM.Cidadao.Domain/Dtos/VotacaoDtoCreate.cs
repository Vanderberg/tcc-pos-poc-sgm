using System;
using System.ComponentModel.DataAnnotations;

namespace SGM.Cidadao.Domain.Dtos
{
    public class VotacaoDtoCreate
    {
        [Required(ErrorMessage = "ID da campanha é obrigatório.")]
        public string CampanhaID { get; set; }
        
        [Required(ErrorMessage = "ID da Politica Publica é obrigatório.")]
        public Guid PoliticaPublicaID { get; set; }   
    }
}