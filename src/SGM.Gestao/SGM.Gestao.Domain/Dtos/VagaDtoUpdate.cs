using System;
using System.ComponentModel.DataAnnotations;
using SGM.Gestao.Domain.Entities.Enums;

namespace SGM.Gestao.Domain.Dtos
{
    public class VagaDtoUpdate : VagaDtoCreate
    {
        [Required(ErrorMessage = "Id é campo obrigatório para alteração")]
        public Guid Id { get; set; }
    }
}