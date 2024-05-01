using Microsoft.AspNetCore.Mvc;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Repository
{
    public interface IProductRepository
    {
        public Task<ActionResult<IEnumerable<Product>>> GetProduct();
        public Task<ActionResult<IEnumerable<ProductViewModel>>> GetViewModelProduct();
    }
}
