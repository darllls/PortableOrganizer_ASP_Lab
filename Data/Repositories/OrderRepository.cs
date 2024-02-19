using PortableOrganizer.Data.Repositories.Interfaces;
using PortableOrganizer.Models;

namespace PortableOrganizer.Data.Repositories
{
    public class OrderRepository: GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrganizerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
