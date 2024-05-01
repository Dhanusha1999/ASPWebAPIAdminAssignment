using Microsoft.AspNetCore.Mvc;
using ProductSalesWebAPIAssignment.Models;

namespace ProductSalesWebAPIAssignment.Repository
{
    public interface IStoreRepository
    {
        public Task<ActionResult<IEnumerable<Store>>> GetStore();
    }
}
