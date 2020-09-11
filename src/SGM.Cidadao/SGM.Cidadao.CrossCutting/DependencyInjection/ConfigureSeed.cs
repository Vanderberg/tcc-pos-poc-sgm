﻿using System;
using System.Linq;
using SGM.Cidadao.Data.Context;
using SGM.Cidadao.Domain.Entities;
using SGM.Cidadao.Domain.Entities.Enums;

namespace SGM.Cidadao.CrossCutting.DependencyInjection
{
    public class ConfigureSeed
    {
        private readonly SgmContextCidadao _context;

        public ConfigureSeed(SgmContextCidadao context)
        {
            _context = context;
        }

        public void Seed()
        {

            if (_context.PoliticaPublicas.Any())
            {
                return; // banco já foi populado
            }

            //se tiver alguma coisa no banco, sai fora
            PoliticaPublicaEntity u1 = new PoliticaPublicaEntity
            {
                Id = Guid.NewGuid(),
                Titulo = "Revitalização da Praça XV",
                Descricao = "Revitalização total da Praça XV. ",
                DescricaoArea = Area.INFRAESTRUTURA,
                NomeResponsavel = "José Alvez",
                OrcamentoPrevisto = 20000,
                CreateAt = DateTime.UtcNow
            };

            PoliticaPublicaEntity u2 = new PoliticaPublicaEntity
            {
                Id = Guid.NewGuid(),
                Titulo = "Construção escola infantil",
                Descricao = "Revitalização total da Praça XV. ",
                DescricaoArea = Area.EDUCACAO,
                NomeResponsavel = "Carloz da Silva",
                OrcamentoPrevisto = 300000,
                CreateAt = DateTime.UtcNow
            };


            _context.PoliticaPublicas.AddRange(u1, u2);
            _context.SaveChanges();
        }
    }
}    