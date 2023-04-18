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
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(e => e.SupplierName)
                .HasMaxLength(255).IsRequired();
            builder.Property(e => e.CreatedAt)
                    .IsRequired();
            builder.Property(e => e.UpdatedAt)
                    .IsRequired();
        }
    }
}
