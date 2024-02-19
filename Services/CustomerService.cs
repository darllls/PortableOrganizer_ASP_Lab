using AutoMapper;
using PortableOrganizer.Data.Repositories.Interfaces;
using PortableOrganizer.DTOs;
using PortableOrganizer.Models;
using PortableOrganizer.Services.Interfaces;

namespace PortableOrganizer.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDTO>> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetByConditionAsync(c => true, CancellationToken.None);
            return _mapper.Map<List<CustomerDTO>>(customers);
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByConditionAsync(c => c.CustomerId == id, CancellationToken.None);
            return _mapper.Map<CustomerDTO>(customer.FirstOrDefault());
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _customerRepository.CreateAsync(customer, CancellationToken.None);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer, CancellationToken.None);
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            await _customerRepository.DeleteAsync(customer, CancellationToken.None);
        }
    }
}
