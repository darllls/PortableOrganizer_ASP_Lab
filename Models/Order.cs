using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortableOrganizer.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        New = 0,
        InProgress = 1,
        Closed = 2
    }
}
