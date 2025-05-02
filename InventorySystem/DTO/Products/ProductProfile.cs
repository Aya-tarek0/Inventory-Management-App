using AutoMapper;
using InventorySystem.Models;

namespace InventorySystem.DTO.Products
{

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));


            CreateMap<ProductDto, Product>();
        }
    }
}

