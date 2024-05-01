using Microsoft.AspNetCore.Mvc;
using ProductSalesWebAPIAssignment.Models;

namespace ProductSalesWebAPIAssignment.Repository
{
    public interface ICustomerRepository
    {
        public Task<ActionResult<IEnumerable<Customer>>> GetCustomer();
    }
}
