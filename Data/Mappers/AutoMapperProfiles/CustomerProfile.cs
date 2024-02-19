using AutoMapper;
using PortableOrganizer.DTOs;
using PortableOrganizer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortableOrganizer.Data.Mappers.AutoMapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
