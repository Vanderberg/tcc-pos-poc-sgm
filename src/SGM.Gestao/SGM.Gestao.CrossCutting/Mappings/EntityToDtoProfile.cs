using AutoMapper;
using SGM.Gestao.Domain.Dtos;
using SGM.Gestao.Domain.Entities;

namespace SGM.Gestao.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<VagaDtoCreate, VagaEntity>()
                .ReverseMap();
            CreateMap<VagaDtoUpdate, VagaEntity>()
                .ReverseMap();
            
            CreateMap<ColaboradorDtoCreate, ColaboradorEntity>()
                .ReverseMap();
            CreateMap<ColaboradorDtoUpdate, ColaboradorEntity>()
                .ReverseMap();
            
            CreateMap<TreinamentoDtoCreate, TreinamentoEntity>()
                .ReverseMap();
            CreateMap<TreinamentoDtoUpdate, TreinamentoEntity>()
                .ReverseMap();             
            
        }
    }
}