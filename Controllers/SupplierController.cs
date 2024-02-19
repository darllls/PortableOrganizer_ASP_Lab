using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortableOrganizer.DTOs;
using PortableOrganizer.Models;
using PortableOrganizer.Services;
using PortableOrganizer.Services.Interfaces;

namespace PortableOrganizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/suppliers
        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = await _supplierService.GetSuppliersAsync();
            var supplierDTOs = _mapper.Map<List<SupplierDTO>>(suppliers);
            return Ok(supplierDTOs);
        }

        // GET: api/suppliers/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier != null)
            {
                var supplierDTO = _mapper.Map<SupplierDTO>(supplier);
                return Ok(supplierDTO);
            }
            return NotFound($"Supplier with id {id} not found");
        }

        // POST: api/suppliers
        [HttpPost]
        public async Task<IActionResult> PostSupplier(SupplierDTO supplierDto)
        {
            var supplierEntity = _mapper.Map<Supplier>(supplierDto);
            await _supplierService.CreateSupplierAsync(supplierEntity);
            var createdSupplierDto = _mapper.Map<SupplierDTO>(supplierEntity);
            return CreatedAtAction(nameof(GetSupplier), new { id = createdSupplierDto.SupplierId }, createdSupplierDto);
        }

        // PUT: api/suppliers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, SupplierDTO supplierDto)
        {
            var existingSupplier = await _supplierService.GetSupplierByIdAsync(id);
            if (existingSupplier != null)
            {
                var updatedSupplier = _mapper.Map<Supplier>(supplierDto);
                updatedSupplier.SupplierId = id;
                await _supplierService.UpdateSupplierAsync(updatedSupplier);
                return NoContent();
            }
            return NotFound($"Supplier with id {id} not found");
        }

        // DELETE: api/orders/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var existingSupplier = await _supplierService.GetSupplierByIdAsync(id);
                if (existingSupplier != null)
                {
                    var supplierToDelete = _mapper.Map<Supplier>(existingSupplier);
                    await _supplierService.DeleteSupplierAsync(supplierToDelete);
                    return NoContent();
                }
                return NotFound($"Supplier with id {id} not found");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
