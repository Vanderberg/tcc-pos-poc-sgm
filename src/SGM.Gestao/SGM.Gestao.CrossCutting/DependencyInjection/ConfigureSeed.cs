using System;
using System.Linq;
using SGM.Gestao.Data.Context;
using SGM.Gestao.Domain.Entities;
using SGM.Gestao.Domain.Entities.Enums;

namespace SGM.Gestao.CrossCutting.DependencyInjection
{
    public class ConfigureSeed
    {
        private readonly SgmContextGestao _context;
        
        public ConfigureSeed(SgmContextGestao context)
        {
            _context = context;
        }
        
        public void Seed()
        {
            Guid?  ColaboradorID = new Guid();
            Guid?  ColaboradorID2 = new Guid();

            Guid?  VagaID = new Guid();
            Guid?  VagaID2 = new Guid();
            
            if (!_context.Coloborador.Any())
            {
                ColaboradorEntity colaborador = new ColaboradorEntity{Id = Guid.NewGuid(), Genero = Genero.Masculino, Nome = "João", Sobrenome = "Silva", CPF = "39004208070", CreateAt = DateTime.UtcNow};
                ColaboradorID = colaborador.Id;
                ColaboradorEntity colaborador2 = new ColaboradorEntity{Id = Guid.NewGuid(), Genero = Genero.Feminino, Nome = "Maria", Sobrenome = "Alves", CPF = "64878502096", CreateAt = DateTime.UtcNow};
                ColaboradorID2 = colaborador2.Id;
                
                _context.Coloborador.AddRange(colaborador, colaborador2);
                _context.SaveChanges();
            }    

            if (!_context.Vaga.Any())
            {
                VagaEntity vaga = new VagaEntity{Id = Guid.NewGuid(), Descricao = "Criador de conteúdo", Status = Status.Aberto, DataInicio = DateTime.UtcNow, DataFim = DateTime.Today.AddDays(90),CreateAt = DateTime.UtcNow};
                VagaID = vaga.Id;
                VagaEntity vaga2 = new VagaEntity{Id = Guid.NewGuid(), Descricao = "Motorista", Status = Status.Aberto, DataInicio = DateTime.UtcNow, DataFim = DateTime.Today.AddDays(90),CreateAt = DateTime.UtcNow};
                VagaID2 = vaga2.Id;
                
                _context.Vaga.AddRange(vaga, vaga2);
                _context.SaveChanges();
            } 
            
            if (!_context.CandidatoVaga.Any())
            {
                CandidatoVagaEntity candidato = new CandidatoVagaEntity{Id = Guid.NewGuid(), StatusCandidato = StatusCandidato.Analise, ColaboradorId = ColaboradorID.Value, VagaId = VagaID.Value, CreateAt = DateTime.UtcNow};
                CandidatoVagaEntity candidato2 = new CandidatoVagaEntity{Id = Guid.NewGuid(), StatusCandidato = StatusCandidato.Analise, ColaboradorId = ColaboradorID2.Value, VagaId = VagaID2.Value, CreateAt = DateTime.UtcNow};
                
                _context.CandidatoVaga.AddRange(candidato, candidato2);
                _context.SaveChanges();
            }
            
            if (!_context.Treinamento.Any())
            {
                TreinamentoEntity treinamento = new TreinamentoEntity{Id = Guid.NewGuid(), Objetivo = "Treinamento criação de texto", Descricao = "Capaictação para praticas modernas de escrita para conteúdo", Cronogrmana = "Cronograma ainda não definido", Status = Status.Aberto, DataInicio = DateTime.Today.AddDays(30), DataFim = DateTime.Today.AddDays(90),CreateAt = DateTime.UtcNow};
                TreinamentoEntity treinamento2 = new TreinamentoEntity{Id = Guid.NewGuid(), Objetivo = "Treinamento direção defensiva", Descricao = "Capaictação de motoristas, praticas de direção defensiva", Cronogrmana = "Cronograma ainda não definido", Status = Status.Aberto, DataInicio = DateTime.Today.AddDays(30), DataFim = DateTime.Today.AddDays(90),CreateAt = DateTime.UtcNow};
                
                _context.Treinamento.AddRange(treinamento, treinamento2);
                _context.SaveChanges();
            }
        }
    }
}