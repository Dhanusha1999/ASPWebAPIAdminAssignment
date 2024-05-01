using Microsoft.AspNetCore.Mvc;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Repository
{
    public interface IOrderRepository
    {
        public Task<ActionResult<IEnumerable<Order>>> GetOrder();
        public Task<ActionResult<IEnumerable<OrderViewModel>>> GetViewModelOrder();
    }
}
