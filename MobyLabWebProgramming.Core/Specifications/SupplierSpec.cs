using Ardalis.Specification;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class SupplierSpec : BaseSpec<SupplierSpec, Supplier>
    {
        public SupplierSpec(Guid id) : base(id)
        {

        }

        public SupplierSpec(string name)
        {
            Query.Where(e => e.SupplierName == name);
        }
    }
}
