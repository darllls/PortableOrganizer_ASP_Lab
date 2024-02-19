using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortableOrganizer.Models;

namespace PortableOrganizer.Data.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.Number)
                .IsRequired();

            builder.Property(o => o.Date)
                .IsRequired();

            builder.Property(o => o.Status)
                .IsRequired()
                .HasColumnType("INT");
        }
    }
}
