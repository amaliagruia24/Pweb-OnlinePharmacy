using Ardalis.Specification;
using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class MedicineCategorySpec : BaseSpec<MedicineCategorySpec, MedicineCategory>
    {
        public MedicineCategorySpec(Guid id) : base(id)
        {

        }

        public MedicineCategorySpec(string name)
        {
            Query.Where(e => e.CategoryName == name);
        }
    }
}
