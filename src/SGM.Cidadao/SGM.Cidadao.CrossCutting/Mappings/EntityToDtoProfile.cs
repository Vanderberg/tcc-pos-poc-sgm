using AutoMapper;
using SGM.Cidadao.Domain.Dtos;
using SGM.Cidadao.Domain.Entities;

namespace SGM.Cidadao.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<PoliticaPublicaDtoCreate, PoliticaPublicaEntity>()
                .ReverseMap();
            CreateMap<PoliticaPublicaDtoUpdate, PoliticaPublicaEntity>()
                .ReverseMap();
            
            CreateMap<CampanhaDtoCreate, CampanhaEntity>()
                .ReverseMap();
            CreateMap<CampanhaDtoUpdate, CampanhaEntity>()
                .ReverseMap();
            
            CreateMap<VotacaoDtoCreate, VotacaoEntity>()
                .ReverseMap();
            CreateMap<VotacaoDtoUpdate, VotacaoEntity>()
                .ReverseMap();            
        }
    }
}