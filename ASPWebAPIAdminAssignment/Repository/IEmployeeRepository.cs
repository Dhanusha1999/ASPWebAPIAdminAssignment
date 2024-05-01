using ASPWebAPIAdminAssignment.Model;
using ASPWebAPIAdminAssignment.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebAPIAdminAssignment.Repository
{
    public interface IEmployeeRepository
    {
        //Get all Employees------ Search All
        public Task<ActionResult<IEnumerable<Staff>>> GetStaff();

        //Get all using view model

        public Task<ActionResult<IEnumerable<StaffViewModel>>> GetViewModelStaffs();
    }
}
