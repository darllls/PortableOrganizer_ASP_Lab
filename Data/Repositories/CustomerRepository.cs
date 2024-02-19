using PortableOrganizer.Data.Repositories.Interfaces;
using PortableOrganizer.Models;

namespace PortableOrganizer.Data.Repositories
{
    public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OrganizerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
