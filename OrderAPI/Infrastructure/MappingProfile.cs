using AutoMapper;
using OrderAPI.DAL.Model;
using OrderAPI.Dtos;

namespace OrderAPI.Infrastructure
{
  public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderDto, Order>();
            CreateMap<Order, OrderDto>();
        }
    }
}