using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class Medicine
{
    
    public Guid Id { get; set; }
    public string MedicineName { get; set; } = default!;
    public string MedicineDescription { get; set; } = default!;
    public double MedicinePrice { get; set; } = default!;
    public double MedicineMeasurement { get; set; } = default!;
    public int Quantity { get; set; } = default!;
    public DateTime ExpiryDate { get; set; } = default!;
    public string Image { get; set; } = default!;
    public MedicineTypeDTO MedicineType { get; set; } = default!;
    public MedicineCategoryDTO MedicineCategory { get; set; } = default!;


}

