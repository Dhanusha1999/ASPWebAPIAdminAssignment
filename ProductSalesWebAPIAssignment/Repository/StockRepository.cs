using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Repository
{
    public class StockRepository : IStockRepository
    {
        //Database private variable
        private readonly ProductSalesDbContext _context;

        //Dependency Injection
        public StockRepository(ProductSalesDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<Stock>>> GetStock()
        {
            if (_context != null)
            {
                return await _context.Stocks
            .Include(o => o.Store)
             .Include(o => o.Product)
            .ToListAsync();
            }
            return null;
        }


        public async Task<ActionResult<IEnumerable<StockViewModel>>> GetViewModelStock()
        {
            if (_context != null)
            {
                return await (from sp in _context.Stocks
                              join s in _context.Stores on sp.StoreId equals s.StoreId
                              join p in _context.Products on sp.ProductId equals p.ProductId
                              select new StockViewModel
                              {
                                  StoreId = (int)s.StoreId,
                                  ProductId=p.ProductId,
                                  Quantity= (int)sp.Quantity
                              }).ToListAsync();
            }
            return null;
        }
    }
}
