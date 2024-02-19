using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortableOrganizer.Models;

namespace PortableOrganizer.Data.Configurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.Phone)
                .IsRequired();

            builder.Property(c => c.OrderNumber)
                .IsRequired();
        }
    }
}
