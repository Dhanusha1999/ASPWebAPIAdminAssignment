using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSalesWebAPIAssignment.Models;

namespace ProductSalesWebAPIAssignment.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        //Database private variable
        private readonly ProductSalesDbContext _context;

        //Dependency Injection
        public CategoryRepository(ProductSalesDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            if (_context != null)
            {
                return await _context.Categories
            .ToListAsync();
            }
            return null;
        }
    }
}
