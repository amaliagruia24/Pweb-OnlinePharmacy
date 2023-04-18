using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Entities
{
    public class MedicineType : BaseEntity
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; } = default!;
        public Medicine Medicine { get; set; } = default!;
        //public Guid MedicineId { get; set; }
    }
}
