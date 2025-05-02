using AutoMapper;
using InventorySystem.Models;

namespace InventorySystem.DTO;

public class InventoryProfile : Profile
{
    public InventoryProfile()
    {
        CreateMap<Inventory, InventoryDto>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
             .ForMember(dest => dest.LowStockThreshold, opt => opt.MapFrom(src => src.LowStockThreshold))

            .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId));

        CreateMap<UpdateInventoryDto, Inventory>();

        CreateMap<Inventory, UpdateInventoryDto>()
          .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
          .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
           .ForMember(dest => dest.LowStockThreshold, opt => opt.MapFrom(src => src.LowStockThreshold))

          .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId));

        CreateMap<UpdateInventoryDto, Inventory>();
    }
}
