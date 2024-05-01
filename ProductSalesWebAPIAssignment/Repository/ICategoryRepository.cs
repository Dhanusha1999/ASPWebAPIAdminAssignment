using Microsoft.AspNetCore.Mvc;
using ProductSalesWebAPIAssignment.Models;

namespace ProductSalesWebAPIAssignment.Repository
{
    public interface ICategoryRepository
    {
        public Task<ActionResult<IEnumerable<Category>>> GetCategory();
    }
}
