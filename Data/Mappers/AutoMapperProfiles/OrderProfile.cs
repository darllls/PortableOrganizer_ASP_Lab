using AutoMapper;
using PortableOrganizer.DTOs;
using PortableOrganizer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortableOrganizer.Data.Mappers.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
