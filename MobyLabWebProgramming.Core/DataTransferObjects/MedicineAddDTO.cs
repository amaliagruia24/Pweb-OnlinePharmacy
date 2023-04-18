using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects
{
    public class MedicineAddDTO
    {
        public string MedicineName { get; set; } = default!;
        public string MedicineDescription { get; set; } = default!;
        public double MedicinePrice { get; set; } = default!;
        public double MedicineMeasurement { get; set; } = default!;
        public int Quantity { get; set; } = default!;
        public DateTime ExpiryDate { get; set; } = default!;
        public string Image { get; set; } = default!;
        public Guid MedicineTypeId { get; set; }
        public Guid MedicineCategoryId { get; set; }
        public Guid SupplierId { get; set; }
        
    }
}
