using Microsoft.AspNetCore.Mvc;
using ProductSalesWebAPIAssignment.Models;

namespace ProductSalesWebAPIAssignment.Repository
{
    public interface IBrandRepository
    {
        public Task<ActionResult<IEnumerable<Brand>>> GetBrand();
    }
}
