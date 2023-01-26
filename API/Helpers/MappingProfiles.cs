using System.Linq.Expressions;
using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(p => p.ProductBrand, mc => mc.MapFrom(s => s.ProductBrand.Name))
            .ForMember(p => p.ProductType, mc => mc.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
    }
}