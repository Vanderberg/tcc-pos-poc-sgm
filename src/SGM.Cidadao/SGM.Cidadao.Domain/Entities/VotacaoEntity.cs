using System;
using SGM.Shared.Domain.Entities;

namespace SGM.Cidadao.Domain.Entities
{
    public class VotacaoEntity : BaseEntity
    {
        public int Votos { get; set; }

        public Guid CampanhaID { get; set; }
        public Guid PoliticaPublicaID { get; set; }    
    }
}