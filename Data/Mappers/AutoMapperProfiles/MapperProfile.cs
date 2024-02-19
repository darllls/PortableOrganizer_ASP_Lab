using AutoMapper;
using PortableOrganizer.DTOs;
using PortableOrganizer.Models;

namespace PortableOrganizer.Data.Mappers.AutoMapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<SupplierDTO, Supplier>().ReverseMap();
        }
    }
}
