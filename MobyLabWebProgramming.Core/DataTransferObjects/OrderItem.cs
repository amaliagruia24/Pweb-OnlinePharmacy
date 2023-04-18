using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects;
public class OrderItem
{
    public Guid Id { get; set; }
    public MedicineDTO Medicine { get; set; } = default!;
    public OrderDTO OrderDTO { get; set; } = default!;
    public int Quantity { get; set; } = default!;


}

