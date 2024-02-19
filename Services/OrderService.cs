using AutoMapper;
using PortableOrganizer.Data.Repositories.Interfaces;
using PortableOrganizer.DTOs;
using PortableOrganizer.Models;
using PortableOrganizer.Services.Interfaces;

namespace PortableOrganizer.Services
{
    public class OrderService: IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IGenericRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetByConditionAsync(o => true, CancellationToken.None);
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByConditionAsync(o => o.OrderId == id, CancellationToken.None);
            return _mapper.Map<OrderDTO>(order.FirstOrDefault());
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _orderRepository.CreateAsync(order, CancellationToken.None);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order, CancellationToken.None);
        }

        public async Task DeleteOrderAsync(Order order)
        {
            await _orderRepository.DeleteAsync(order, CancellationToken.None);
        }
    }
}
