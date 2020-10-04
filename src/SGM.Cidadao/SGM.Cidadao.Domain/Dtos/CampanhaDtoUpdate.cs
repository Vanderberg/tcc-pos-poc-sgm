using System;
using System.ComponentModel.DataAnnotations;

namespace SGM.Cidadao.Domain.Dtos
{
    public class CampanhaDtoUpdate : CampanhaDtoCreate
    {
        [Required(ErrorMessage = "Id é campo obrigarorio para alteração")]
        public Guid Id { get; set; }
    }
}