using AutoMapper;
using InventorySystem.Models;

namespace InventorySystem.DTO.Transactions
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<InventoryTransaction, TransactionDto>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.InventoryId, opt => opt.MapFrom(src => src.InventoryId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));


            CreateMap<TransactionDto, InventoryTransaction>()
           .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
           .ForMember(dest => dest.InventoryId, opt => opt.MapFrom(src => src.InventoryId))
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
           .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType))
           .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));



            CreateMap<InventoryTransaction, AddTransferTransactionDTO>()
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.InventoryId, opt => opt.MapFrom(src => src.InventoryId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.FromId, opt => opt.MapFrom(src => src.FromWarehouseId))
                .ForMember(dest => dest.ToId, opt => opt.MapFrom(src => src.ToWarehouseId));



            CreateMap<AddTransferTransactionDTO, InventoryTransaction>()
              .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Stock))
              .ForMember(dest => dest.InventoryId, opt => opt.MapFrom(src => src.InventoryId))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
              .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType))
              .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
              .ForMember(dest => dest.FromWarehouseId, opt => opt.MapFrom(src => src.FromId))
              .ForMember(dest => dest.ToWarehouseId, opt => opt.MapFrom(src => src.ToId));
        }
    }
}
