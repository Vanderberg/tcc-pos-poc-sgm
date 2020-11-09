using SGM.Gestao.Domain.Entities.Enums;
using SGM.Shared.Domain.Entities;

namespace SGM.Gestao.Domain.Entities
{
    public class ColaborardorEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public Genero Genero { get; set; }
    }
}