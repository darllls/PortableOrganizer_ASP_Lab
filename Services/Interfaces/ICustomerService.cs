using PortableOrganizer.DTOs;
using PortableOrganizer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortableOrganizer.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
    }
}
