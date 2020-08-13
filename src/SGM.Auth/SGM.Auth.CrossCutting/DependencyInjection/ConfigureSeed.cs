using System;
using SGM.Auth.Data.Context;
using SGM.Auth.Domain.Entities;
using SGM.Auth.Domain.Entities.Enums;
using System.Linq;

namespace SGM.Auth.CrossCutting.DependencyInjection
{
    public class ConfigureSeed
    {
        private readonly AuthContext _context;

        public ConfigureSeed(AuthContext context)
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
                Email = "admin@company.com",
                FirstName = "Alberto",
                LastName = "Roberto",
                Password = "admin",
                AcessLevel = Role.ADMIN,
                CreateAt = DateTime.UtcNow
            };

            UserEntity u2 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "monitor@company.com",
                FirstName = "Vanessa",
                LastName = "Roberts",
                Password = "monitor",
                AcessLevel = Role.MONITOR,
                CreateAt = DateTime.UtcNow
            };

            UserEntity u3 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "user@company.com",
                FirstName = "João",
                LastName = "da Silva",
                Password = "user",
                AcessLevel = Role.USER_COMMON,
                CreateAt = DateTime.UtcNow
            };

            UserEntity u4 = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "manutencao@company.com",
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