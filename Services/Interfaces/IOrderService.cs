using PortableOrganizer.DTOs;
using PortableOrganizer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortableOrganizer.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetOrdersAsync();
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
    }
}
