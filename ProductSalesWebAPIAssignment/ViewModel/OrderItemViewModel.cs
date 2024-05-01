using ProductSalesWebAPIAssignment.Models;

namespace ProductSalesWebAPIAssignment.ViewModel
{
    public class OrderItemViewModel
    {
        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int ListPrice { get; set; }

        public int Discount { get; set; }
    }
}
