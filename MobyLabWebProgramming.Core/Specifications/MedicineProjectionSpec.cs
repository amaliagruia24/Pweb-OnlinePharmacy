using MobyLabWebProgramming.Core.DataTransferObjects;
using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;


namespace MobyLabWebProgramming.Core.Specifications
{
    public sealed class MedicineProjectionSpec : BaseSpec<MedicineProjectionSpec, Medicine, MedicineDTO>
    {
        protected override Expression<Func<Medicine, MedicineDTO>> Spec => e => new()
        {
            MedicineName = e.MedicineName,
            MedicineDescription = e.MedicineDescription,
            MedicinePrice = e.MedicinePrice,
            MedicineMeasurement = e.MedicineMeasurement,
            Quantity = e.Quantity
        };

        public MedicineProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
        {
        }

        public MedicineProjectionSpec(Guid id) : base(id)
        {
        }

        public MedicineProjectionSpec(string? search)
        {
            search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

            if (search == null)
            {
                return;
            }

            var searchExpr = $"%{search.Replace(" ", "%")}%";

            Query.Where(e => EF.Functions.ILike(e.MedicineName, searchExpr)); // This is an example on who database specific expressions can be used via C# expressions.
                                                                      // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
        }
    }
}
