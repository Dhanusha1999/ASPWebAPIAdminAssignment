using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSalesWebAPIAssignment.Models;

namespace ProductSalesWebAPIAssignment.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        //Database private variable
        private readonly ProductSalesDbContext _context;

        //Dependency Injection
        public CustomerRepository(ProductSalesDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            if (_context != null)
            {
                return await _context.Customers
            .ToListAsync();
            }
            return null;
        }
    }
}
