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
    public class MedicineCategoryConfiguration : IEntityTypeConfiguration<MedicineCategory>
    {
        public void Configure(EntityTypeBuilder<MedicineCategory> builder)
        {
            builder.Property(e => e.Id)
            .IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(e => e.CategoryName)
                .HasMaxLength(255).IsRequired();
            builder.Property(e => e.CreatedAt)
                 .IsRequired();
            builder.Property(e => e.UpdatedAt)
                 .IsRequired();

        }
    }
}
