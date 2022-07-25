using AutoMapper;

using Mobiliva.Common;
using Mobiliva.DataAccess.Data;
using Mobiliva.Models;

namespace Mobiliva.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap(); 

            CreateMap<CreateOrderRequest, Order>().ReverseMap();
        }
    }
}
