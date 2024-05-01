using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Repository
{
    public class OrderRepository: IOrderRepository
    {
        //Database private variable
        private readonly ProductSalesDbContext _context;

        //Dependency Injection
        public OrderRepository(ProductSalesDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            if (_context != null)
            {
                return await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Staff)
            .ToListAsync();
            }
            return null;
        }


        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetViewModelOrder()
        {
            if (_context != null)
            {
                return await (from o in _context.Orders
                              join c in _context.Customers on o.CustomerId equals c.CustomerId
                              join s in _context.StaffProducts on o.StaffId equals s.StaffId
                              select new OrderViewModel
                              {
                                 OrderId=o.OrderId,
                                 OrderStatus=o.OrderStatus, 
                                  OrderDate = (DateTime)o.OrderDate,
                                  RequiredDate = (DateTime)o.RequiredDate,
                                  ShippedDate= (DateTime)o.ShippedDate,
                                  StaffId =s.StaffId,
                                  CustomerId=c.CustomerId
                               }).ToListAsync();
            }
            return null;
        }
    }
}
