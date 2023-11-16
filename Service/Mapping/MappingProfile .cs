using AutoMapper;
using Domain.Dto.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Mapping
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
