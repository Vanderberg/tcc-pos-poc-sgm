using System;
using System.ComponentModel.DataAnnotations;
using SGM.Cidadao.Domain.Entities.Enums;

namespace SGM.Cidadao.Domain.Dtos
{
    public class PoliticaPublicaDtoUpdate : PoliticaPublicaDtoCreate
    {
        [Required(ErrorMessage = "Id é campo obrigatório para alteração")]
        public Guid Id { get; set; }
    }
}