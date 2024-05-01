using ProductSalesWebAPIAssignment.Models;

namespace ProductSalesWebAPIAssignment.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public string OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public int StaffId { get; set; }

        public int CustomerId { get; set; }
    }
}
