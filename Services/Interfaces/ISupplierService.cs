using PortableOrganizer.DTOs;
using PortableOrganizer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortableOrganizer.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<List<SupplierDTO>> GetSuppliersAsync();
        Task<SupplierDTO> GetSupplierByIdAsync(int id);
        Task CreateSupplierAsync(Supplier supplier);
        Task UpdateSupplierAsync(Supplier supplier);
        Task DeleteSupplierAsync(Supplier supplier);
    }
}
