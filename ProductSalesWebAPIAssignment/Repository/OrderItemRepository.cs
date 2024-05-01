using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Repository
{
    public class OrderItemRepository: IOrderItemRepository
    {
        //Database private variable
        private readonly ProductSalesDbContext _context;

        //Dependency Injection
        public OrderItemRepository(ProductSalesDbContext context)
        {
            _context = context;
        }

       
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItem()
        {
            if (_context != null)
            {
                return await _context.OrderItems
            .Include(o => o.Order)
            .Include(o => o.Product)
            .ToListAsync();
            }
            return null;
        }

       
        public async Task<ActionResult<IEnumerable<OrderItemViewModel>>> GetViewModelOrderItem()
        {
            if (_context != null)
            {
                return await (from o in _context.OrderItems
                              join or in _context.Orders on o.OrderId equals or.OrderId
                              join p in _context.Products on o.ProductId equals p.ProductId
                              select new OrderItemViewModel
                              {
                                  OrderId = or.OrderId,
                                  ItemId = o.ItemId,
                                  ProductId = p.ProductId,
                                  Quantity = (int)o.Quantity,
                                  ListPrice = (int)o.ListPrice,
                                  Discount = (int)o.Discount
                              }).ToListAsync();
            }
            return null;
        }
    }
}
