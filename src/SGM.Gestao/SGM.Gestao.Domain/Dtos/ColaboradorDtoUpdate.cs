using System;
using System.ComponentModel.DataAnnotations;

namespace SGM.Gestao.Domain.Dtos
{
    public class ColaboradorDtoUpdate : ColaboradorDtoCreate
    {
        [Required(ErrorMessage = "Id é campo obrigatório para alteração")]
        public Guid Id { get; set; }
    }
}