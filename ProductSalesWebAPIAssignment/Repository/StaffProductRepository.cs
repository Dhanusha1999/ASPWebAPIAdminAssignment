using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Repository
{
    public class StaffProductRepository: IStaffProductRepository
    {
        //Database private variable
        private readonly ProductSalesDbContext _context;

        //Dependency Injection
        public StaffProductRepository(ProductSalesDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<StaffProduct>>> GetStaffProduct()
        {
            if (_context != null)
            {
                return await _context.StaffProducts
            .Include(o => o.Store)
            .ToListAsync();
            }
            return null;
        }


        public async Task<ActionResult<IEnumerable<StaffProductViewModel>>> GetViewModelStaffProduct()
        {
            if (_context != null)
            {
                return await (from sp in _context.StaffProducts
                              join s in _context.Stores on sp.StoreId equals s.StoreId
                              select new StaffProductViewModel
                              {
                                  StaffId = sp.StaffId,
                                  FirstName = sp.FirstName,
                                  LastName = sp.LastName,
                                  Email = sp.Email,
                                  PhoneNumber = sp.PhoneNumber,
                                  Active = sp.Active,
                                  StoreId = (int)sp.StoreId
                              }).ToListAsync();
            }
            return null;
        }
    }
}
