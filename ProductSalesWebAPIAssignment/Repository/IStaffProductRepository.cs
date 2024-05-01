using Microsoft.AspNetCore.Mvc;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Repository
{
    public interface IStaffProductRepository
    {
        public Task<ActionResult<IEnumerable<StaffProduct>>> GetStaffProduct();
        public Task<ActionResult<IEnumerable<StaffProductViewModel>>> GetViewModelStaffProduct();
    }
}
