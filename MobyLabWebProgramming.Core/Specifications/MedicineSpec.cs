using Ardalis.Specification;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Core.Specifications
{
    public class MedicineSpec : BaseSpec<MedicineSpec, Medicine, MedicineDTO>
    {
        protected override Expression<Func<Medicine, MedicineDTO>> Spec => e => new()
        {
            Id = e.Id,
            MedicineName = e.MedicineName,
            MedicineDescription = e.MedicineDescription,
            MedicinePrice = e.MedicinePrice,
            MedicineMeasurement = e.MedicineMeasurement,
            Quantity = e.Quantity,
            ExpiryDate = e.ExpiryDate,
            Image = e.Image,
            MedicineCategory = new()
            {
                Id = e.MedicineCategory.Id,
                CategoryName = e.MedicineCategory.CategoryName,
            },
            MedicineType = new()
            {
                Id = e.MedicineType.Id,
                TypeName = e.MedicineType.TypeName,
            },
            Supplier = new()
            {
                Id = e.Supplier.Id,
                SupplierName = e.Supplier.SupplierName,
            }
        };
        public MedicineSpec(Guid id) : base(id)
        {

        }

        public MedicineSpec(string name)
        {
            Query.Where(e => e.MedicineName == name);
        }
    }
}
