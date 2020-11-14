using System.ComponentModel.DataAnnotations;
using SGM.Gestao.Domain.Entities.Enums;

namespace SGM.Gestao.Domain.Dtos
{
    public class ColaboradorDtoCreate
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]     
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório.")]     
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Sobrenome { get; set; }
        
        [Required(ErrorMessage = "CPF é obrigatório.")]     
        [StringLength(11, ErrorMessage = "CPF deve ter no máximo {1} caracteres")]
        public string CPF { get; set; }
        
        [Required(ErrorMessage = "Genero é obrigatório.")]
        public Genero Genero { get; set; }
    }
}