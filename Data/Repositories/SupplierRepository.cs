using PortableOrganizer.Data.Repositories.Interfaces;
using PortableOrganizer.Models;

namespace PortableOrganizer.Data.Repositories
{
    public class SupplierRepository: GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(OrganizerDbContext dbContext) : base(dbContext)
        {
        }

    }
}
