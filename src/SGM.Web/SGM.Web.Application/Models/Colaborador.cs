using System;
using SGM.Gestao.Domain.Entities.Enums;

namespace SGM.Web.Application.Models
{
    public class Colaborador
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public Genero Genero { get; set; }
    }
}