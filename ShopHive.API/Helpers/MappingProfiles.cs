using AutoMapper;
using ShopHive.API.Models;
using ShopHive.API.Models.DTO;

namespace ShopHive.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}
