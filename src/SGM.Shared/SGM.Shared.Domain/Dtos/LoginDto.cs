using System;
using System.ComponentModel.DataAnnotations;

namespace SGM.Shared.Domain.Dtos
{
    public class LoginDto
    {
        public LoginDto()
        {

        }
        public LoginDto(string CPF, string Password)
        {
            this.CPF = CPF;
            this.Password = Password;
        }

        [Required(ErrorMessage = "CPF é campo obrigatório para Login")]
        //[EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(11, ErrorMessage = "CPF deve ter no máximo {1} caracteres")]
        public string CPF { get; set; }
        public string Password { get; set; }
    }
}