using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Order : BaseEntity
    {
        public Guid Id { get; set; }
        public User User { get; set; } = default!;
        public Guid UserId { get; set; }
        public double OrderAmount { get; set; } = default!;
        public ICollection<OrderItem> Items { get; set; } = default!;
    }
}
