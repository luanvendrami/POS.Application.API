using AutoMapper;
using Domain.Dto.Request;
using Domain.Entities;

namespace IoC.infra.MappingAutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DrinkOrder, DrinkOrderDto>();
            CreateMap<GrillOrder, GrillOrderDto>();
            CreateMap<FriesOrder, OrderFriesDto>();
            CreateMap<SaladOrder, DrinkOrderDto>();
        }
    }
}
