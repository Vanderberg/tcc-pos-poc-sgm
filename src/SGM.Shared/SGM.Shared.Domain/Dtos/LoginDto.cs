using System;
using System.ComponentModel.DataAnnotations;

namespace SGM.Shared.Domain.Dtos
{
    public class LoginDto
    {
        public LoginDto()
        {

        }
        public LoginDto(string User, string Password)
        {
            this.Email = User;
            this.firstName = Password;
        }

        [Required(ErrorMessage = "E-mail é campo obrigatório para Login")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
        public string firstName { get; set; }
    }
}