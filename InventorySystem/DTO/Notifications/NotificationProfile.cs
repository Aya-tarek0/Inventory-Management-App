using AutoMapper;
using InventorySystem.DTO.Products;
using InventorySystem.Models;

namespace InventorySystem.DTO.Notifications
{
    public class NotificationProfile:Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDTO>()
               .ForMember(dest => dest.InventoryId, opt => opt.MapFrom(src => src.InventoryId))
               .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
               .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));



            CreateMap<NotificationDTO, Notification>();
        }
    }
}
