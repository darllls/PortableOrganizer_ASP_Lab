using PortableOrganizer.Models;

namespace PortableOrganizer.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
    }
}
