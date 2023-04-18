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
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(e => e.MedicineName)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(e => e.MedicineDescription)
                .HasMaxLength(4095)
                .IsRequired();
            builder.Property(e => e.ExpiryDate)
                .IsRequired();  
            builder.Property(e => e.MedicinePrice)
                .IsRequired();
            builder.Property(e => e.MedicineMeasurement)
                .IsRequired();
            builder.Property(e => e.Quantity)
                .IsRequired();
            builder.HasOne(e => e.MedicineType).WithOne(a => a.Medicine).HasForeignKey<MedicineType>(m => m.MedicineId);
            builder.HasOne(e => e.MedicineCategory).WithOne(a => a.Medicine).HasForeignKey<MedicineCategory>(m => m.MedicineId);
            builder.HasOne(e => e.Supplier).WithOne(a => a.Medicine).HasForeignKey<Medicine>(m => m.SupplierId);

        }
    }
}
