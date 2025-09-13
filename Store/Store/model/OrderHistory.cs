// File: Store/OrderHistory.cs
namespace Store
{
    public class OrderHistory
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public System.DateTime CreatedAt { get; set; }

        // ✅ new
        public int? CustomerId { get; set; }

        public string CompanyName
        {
            get;
            set;
        }

        public string BranchName
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }
    }
}
