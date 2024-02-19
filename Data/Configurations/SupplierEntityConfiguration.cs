using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortableOrganizer.Models;

namespace PortableOrganizer.Data.Configurations
{
    public class SupplierEntityConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(s => s.SupplierId);

            builder.Property(s => s.Name)
                .IsRequired();

            builder.Property(s => s.Email)
                .IsRequired();
        }
    }
}
