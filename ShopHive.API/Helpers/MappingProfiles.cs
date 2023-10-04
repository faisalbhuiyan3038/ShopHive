using AutoMapper;
using ShopHive.API.Models;
using ShopHive.API.Models.DTO;
using ShopHive.API.Models.OrderAggregate;

namespace ShopHive.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Address>();
        }
    }
}
