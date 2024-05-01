using ASPWebAPIAdminAssignment.Model;
using ASPWebAPIAdminAssignment.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPWebAPIAdminAssignment.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        //Database private variable
        private readonly AdminDbContext _context;

        //Dependency Injection
        public EmployeeRepository(AdminDbContext context)
        {
            _context = context;
        }

        //1-- Get All Employees 
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            if (_context != null)
            {
                return await _context.Staff.Include(e => e.Designation).ToListAsync();
            }
            return null;
        }

        //2--Get All Employee Using ViewModel
        public async Task<ActionResult<IEnumerable<StaffViewModel>>> GetViewModelStaffs()
        {
            if (_context != null)
            {
                return await (from e in _context.Staff
                              from d in _context.Designations
                              where e.DesignationId == d.DesignationId
                              select new StaffViewModel
                              {
                                  StaffId = e.StaffId,
                                  Name = e.Name,
                                  DateOfBirth = (DateTime)e.DateOfBirth,
                                  PhoneNumber = e.PhoneNumber,
                                  Address=e.Address,
                                  DesignationId = d.DesignationId
                              }).ToListAsync();
            }
            return null;
        }
    }
}
