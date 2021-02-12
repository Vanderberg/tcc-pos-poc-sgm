using System;
using System.Linq;
using SGM.Cidadao.Data.Context;
using SGM.Cidadao.Data.Mapping;
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
            PoliticaPublicaEntity Pol1 = new PoliticaPublicaEntity();
            PoliticaPublicaEntity Pol2 = new PoliticaPublicaEntity();
            CampanhaEntity Cam1 = new CampanhaEntity();
            CampanhaEntity Cam2 = new CampanhaEntity();

            if (!_context.PoliticaPublicas.Any()) // banco já foi populado
            {
                PoliticaPublicaEntity u1 = new PoliticaPublicaEntity {Id = Guid.NewGuid(), Titulo = "Revitalização da Praça XV", Descricao = "Revitalização total da Praça XV. ", DescricaoArea = Area.INFRAESTRUTURA, NomeResponsavel = "José Alvez", OrcamentoPrevisto = 20000, CreateAt = DateTime.UtcNow};
                PoliticaPublicaEntity u2 = new PoliticaPublicaEntity {Id = Guid.NewGuid(), Titulo = "Construção escola infantil", Descricao = "Revitalização total da Praça XV. ", DescricaoArea = Area.EDUCACAO, NomeResponsavel = "Carloz da Silva", OrcamentoPrevisto = 300000, CreateAt = DateTime.UtcNow};
                
                Pol1 = u1;
                Pol2 = u2;
                _context.PoliticaPublicas.AddRange(u1, u2);
                _context.SaveChanges();    
            }

            if (!_context.Campanha.Any())
            {
                CampanhaEntity c1 = new CampanhaEntity {Id = Guid.NewGuid(), Descricao = "Campanhas padrão", CreateAt = DateTime.UtcNow, DataFim = DateTime.UtcNow, DataInicio = DateTime.UtcNow};
                CampanhaEntity c2 = new CampanhaEntity {Id = Guid.NewGuid(), Descricao = "Campanhas de teste", CreateAt = DateTime.UtcNow, DataFim = DateTime.UtcNow, DataInicio = DateTime.UtcNow};

                Cam1 = c1;
                Cam2 = c2;
                _context.Campanha.AddRange(c1, c2);
                _context.SaveChanges();    
            }

            if (!_context.Votacao.Any())
            {
                VotacaoEntity v1 = new VotacaoEntity {Id = Guid.NewGuid(), CreateAt = DateTime.UtcNow, Votos = 0, PoliticaPublicaID = Pol1.Id, PoliticaTitulo = Pol1.Titulo, CampanhaID = Cam1.Id, CampanhaDescricao = Cam1.Descricao};
                VotacaoEntity v2 = new VotacaoEntity {Id = Guid.NewGuid(), CreateAt = DateTime.UtcNow, Votos = 0, PoliticaPublicaID = Pol2.Id, PoliticaTitulo = Pol2.Titulo, CampanhaID = Cam2.Id, CampanhaDescricao = Cam2.Descricao};
                
                _context.Votacao.AddRange(v1, v2);
                _context.SaveChanges();
            }
        }
    }
}    