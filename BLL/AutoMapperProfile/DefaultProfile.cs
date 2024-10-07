using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.DAL.Entities;

namespace Cafe_Delight.BLL.AutoMapperProfile
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {

            CreateMap<AddressRequestDTO, Address>();
            CreateMap<Address, AddressResponseDTO>();

            CreateMap<CartRequestDTO, Cart>();
            CreateMap<Cart, CartResponseDTO>();

            CreateMap<CategoryRequestDTO, Category>();
            CreateMap<Category, CategoryResponseDTO>();

            CreateMap<CustomerRequestDTO, Customer>();  
            CreateMap<Customer, CustomerResponseDTO>();

            CreateMap<FoodItemRequestDTO, FoodItem>();
            CreateMap<FoodItem, FoodItemResponseDTO>();

            CreateMap<OrderRequestDTO, Order>();
            CreateMap<Order, OrderResponseDTO>();

            CreateMap<OrderDetailRequestDTO, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailResponseDTO>();

            CreateMap<LogInRequestDTO, Customer>();
            CreateMap<Customer, LogInResponseDTO>();







        }
    }
}
