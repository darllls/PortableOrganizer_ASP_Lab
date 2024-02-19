using AutoMapper;
using PortableOrganizer.Data.Repositories.Interfaces;
using PortableOrganizer.DTOs;
using PortableOrganizer.Models;
using PortableOrganizer.Services.Interfaces;

namespace PortableOrganizer.Services
{
    public class SupplierService: ISupplierService
    {
        private readonly IGenericRepository<Supplier> _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(IGenericRepository<Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<List<SupplierDTO>> GetSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetByConditionAsync(s => true, CancellationToken.None);
            return _mapper.Map<List<SupplierDTO>>(suppliers);
        }

        public async Task<SupplierDTO> GetSupplierByIdAsync(int id)
        {
            var supplier = await _supplierRepository.GetByConditionAsync(s => s.SupplierId == id, CancellationToken.None);
            return _mapper.Map<SupplierDTO>(supplier.FirstOrDefault());
        }

        public async Task CreateSupplierAsync(Supplier supplier)
        {
            await _supplierRepository.CreateAsync(supplier, CancellationToken.None);
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            await _supplierRepository.UpdateAsync(supplier, CancellationToken.None);
        }

        public async Task DeleteSupplierAsync(Supplier supplier)
        {
            await _supplierRepository.DeleteAsync(supplier, CancellationToken.None);
        }
    }
}
