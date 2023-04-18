using Ardalis.Specification;
using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class MedicineTypeSpec : BaseSpec<MedicineTypeSpec, MedicineType>
    {
        public MedicineTypeSpec(Guid id) : base(id)
        {

        }

        public MedicineTypeSpec(string name)
        {
            Query.Where(e => e.TypeName == name);
        }
    }
}
