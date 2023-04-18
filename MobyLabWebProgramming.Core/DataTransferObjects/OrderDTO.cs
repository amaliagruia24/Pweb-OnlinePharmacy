using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class OrderDTO
{
    
    public Guid Id { get; set; }
    public double OrderAmount { get; set; } = default!;
    public UserDTO User { get; set; } = default!;

}

