using ProductSalesWebAPIAssignment.Models;

namespace ProductSalesWebAPIAssignment.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int ModelYear { get; set; }

        public int ListPrice { get; set; }
    
    }
}

