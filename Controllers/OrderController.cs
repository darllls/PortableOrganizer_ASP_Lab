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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();
            var orderDTOs = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(orderDTOs);
        }

        // GET: api/orders/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order != null)
            {
                var orderDTO = _mapper.Map<OrderDTO>(order);
                return Ok(orderDTO);
            }
            return NotFound($"Order with id {id} not found");
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> PostOrder(OrderDTO orderDto)
        {
            var orderEntity = _mapper.Map<Order>(orderDto);
            await _orderService.CreateOrderAsync(orderEntity);
            var createdOrderDto = _mapper.Map<OrderDTO>(orderEntity);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrderDto.OrderId }, createdOrderDto);
        }

        // PUT: api/orders/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDTO orderDto)
        {
            var existingOrder = await _orderService.GetOrderByIdAsync(id);
            if (existingOrder != null)
            {
                var updatedOrder = _mapper.Map<Order>(orderDto);
                updatedOrder.OrderId = id;
                await _orderService.UpdateOrderAsync(updatedOrder);
                return NoContent();
            }
            return NotFound($"Order with id {id} not found");
        }

        // DELETE: api/orders/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var existingOrder = await _orderService.GetOrderByIdAsync(id);
                if (existingOrder != null)
                {
                    var orderToDelete = _mapper.Map<Order>(existingOrder);
                    await _orderService.DeleteOrderAsync(orderToDelete);
                    return NoContent();
                }
                return NotFound($"Order with id {id} not found");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
