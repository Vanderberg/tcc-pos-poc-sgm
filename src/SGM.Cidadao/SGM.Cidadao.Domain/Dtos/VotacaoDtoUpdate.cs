using System;
using System.ComponentModel.DataAnnotations;

namespace SGM.Cidadao.Domain.Dtos
{
    public class VotacaoDtoUpdate : VotacaoDtoCreate
    {
        [Required(ErrorMessage = "Id é campo obrigarorio para alteração")]
        public Guid Id { get; set; }
    }
}