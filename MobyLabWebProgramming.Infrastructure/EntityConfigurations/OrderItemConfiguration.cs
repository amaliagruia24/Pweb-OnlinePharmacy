using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(e => e.Order).WithMany(e => e.Items) // This provides the reverse mapping for the one-to-many relation. 
                .HasForeignKey(e => e.OrderId) // Here the foreign key column is specified.
                .HasPrincipalKey(e => e.Id) // This specifies the referenced key in the referenced table.
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // This specifies the delete behavior when the referenced entity is removed.
            builder.HasOne(e => e.Medicine).WithOne(a => a.OrderItem).HasForeignKey<Medicine>(m => m.OrderItemId);
        }
    }
}
