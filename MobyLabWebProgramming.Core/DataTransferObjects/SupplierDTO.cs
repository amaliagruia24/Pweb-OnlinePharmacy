using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class SupplierDTO
{

    public Guid Id { get; set; }
    public string SupplierName { get; set; } = default!;
    public MedicineDTO Medicine { get; set; } = default!;

}

