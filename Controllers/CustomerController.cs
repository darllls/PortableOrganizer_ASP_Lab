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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        // GET: api/customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();
            var customerDTOs = _mapper.Map<List<CustomerDTO>>(customers);
            return Ok(customerDTOs);
        }

        // GET: api/customers/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer != null)
            {
                var customerDTO = _mapper.Map<CustomerDTO>(customer);
                return Ok(customerDTO);
            }
            return NotFound($"Customer with id {id} not found");
        }

        // POST: api/customers
        [HttpPost]
        public async Task<IActionResult> PostCustomer(CustomerDTO customerDto)
        {
            try
            {
                var customerEntity = _mapper.Map<Customer>(customerDto);
                await _customerService.CreateCustomerAsync(customerEntity);
                var createdCustomerDto = _mapper.Map<CustomerDTO>(customerEntity);
                return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomerDto.CustomerId }, createdCustomerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/customers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDTO customerDto)
        {
            try
            {
                var existingCustomer = await _customerService.GetCustomerByIdAsync(id);
                if (existingCustomer != null)
                {
                    var updatedCustomer = _mapper.Map<Customer>(customerDto); 
                    updatedCustomer.CustomerId = id; 
                    await _customerService.UpdateCustomerAsync(updatedCustomer);
                    return NoContent();
                }
                return NotFound($"Customer with id {id} not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        // DELETE: api/customers/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var existingCustomer = await _customerService.GetCustomerByIdAsync(id);
                if (existingCustomer != null)
                {
                    var customerToDelete = _mapper.Map<Customer>(existingCustomer);
                    await _customerService.DeleteCustomerAsync(customerToDelete);
                    return NoContent();
                }
                return NotFound($"Customer with id {id} not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
