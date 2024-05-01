using Microsoft.AspNetCore.Mvc;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Repository
{
    public interface IStockRepository
    {
        public Task<ActionResult<IEnumerable<Stock>>> GetStock();
        public Task<ActionResult<IEnumerable<StockViewModel>>> GetViewModelStock();
    }
}
