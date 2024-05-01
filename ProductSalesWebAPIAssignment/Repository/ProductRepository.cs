using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Repository
{
    public class ProductRepository: IProductRepository
    {
        //Database private variable
        private readonly ProductSalesDbContext _context;

        //Dependency Injection
        public ProductRepository(ProductSalesDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            if (_context != null)
            {
                return await _context.Products
            .Include(o => o.Brand)
            .Include(o => o.Category)
            .ToListAsync();
            }
            return null;
        }


        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetViewModelProduct()
        {
            if (_context != null)
            {
                return await (from o in _context.Products
                              join b in _context.Brands on o.BrandId equals b.BrandId
                              join c in _context.Categories on o.CategoryId equals c.CategoryId
                              select new ProductViewModel
                              {
                                  ProductId = o.ProductId,
                                  ProductName = o.ProductName,
                                  BrandId = (int)o.BrandId,
                                  CategoryId = (int)o.CategoryId,
                                  ModelYear = (int)o.ModelYear,
                                  ListPrice = (int)o.ListPrice
                              }).ToListAsync();
            }
            return null;
        }
    }
}
