using AutoMapper;
using PortableOrganizer.DTOs;
using PortableOrganizer.Models;

namespace PortableOrganizer.Data.Mappers.AutoMapperProfiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierDTO, Supplier>();
        }
    }
}
