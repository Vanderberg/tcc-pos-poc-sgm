using System;
using System.Linq;
using SGM.Auth.Data.Context;
using SGM.Shared.Domain.Entities;
using SGM.Shared.Domain.Entities.Enums;

namespace SGM.Auth.CrossCutting.DependencyInjection
{
    public class ConfigureSeed
    {
        private readonly SgmContext _context;

        public ConfigureSeed(SgmContext context)
        {
            _context = context;
        }

        public void Seed()
        {

            if (_context.Users.Any())
            {
                return; // banco já foi populado
            }

            //se tiver alguma coisa no banco, sai fora
            UserEntity u1 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "admin@bomdestino.gov.br",
                FirstName = "Alberto",
                LastName = "Roberto",
                Password = "admin",
                AcessLevel = Role.ADMIN,
                CreateAt = DateTime.UtcNow
            };

            UserEntity u2 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "monitor@bomdestino.gov.br",
                FirstName = "Vanessa",
                LastName = "Roberts",
                Password = "monitor",
                AcessLevel = Role.MONITOR,
                CreateAt = DateTime.UtcNow
            };

            UserEntity u3 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "user@bomdestino.gov.br",
                FirstName = "João",
                LastName = "da Silva",
                Password = "user",
                AcessLevel = Role.USER_COMMON,
                CreateAt = DateTime.UtcNow
            };

            UserEntity u4 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "manutencao@bomdestino.gov.br",
                FirstName = "Marcos",
                LastName = "Daniel",
                Password = "manutencao",
                AcessLevel = Role.MAINTENANCE,
                CreateAt = DateTime.UtcNow
            };

            _context.Users.AddRange(u1, u2, u3, u4);
            _context.SaveChanges();
        }
    }
}