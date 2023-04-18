using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities;

public class Medicine : BaseEntity
{
    
    public Guid Id { get; set; }
    public string MedicineName { get; set; } = default!;
    public string MedicineDescription { get; set; } = default!;
    public double MedicinePrice { get; set; } = default!;
    public double MedicineMeasurement { get; set; } = default!;
    public int Quantity { get; set; } = default!;
    public Guid MedicineTypeId { get; set; }
    public Guid MedicineCategoryId { get; set; }
    public Guid SupplierId { get; set; }
    public MedicineCategory MedicineCategory { get; set; } = default!;
    public MedicineType MedicineType { get; set; } = default!;
    public Supplier Supplier { get; set; } = default!;
    public DateTime ExpiryDate { get; set; } = default!;
    public string Image { get; set; } = default!;
    public OrderItem OrderItem { get; set; } = default!;
    //public Guid OrderItemId { get; set; } = default!;
}

