using Microsoft.AspNetCore.Mvc;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Repository
{
    public interface IOrderItemRepository
    {
        
        public Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItem();
        public Task<ActionResult<IEnumerable<OrderItemViewModel>>> GetViewModelOrderItem();
    }
}
