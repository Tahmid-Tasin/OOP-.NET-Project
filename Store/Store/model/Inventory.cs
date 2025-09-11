using System;

namespace Store
{
    public class Inventory
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public Company Company { get; set; }
        public Branch Branch { get; set; }
        public Product Product { get; set; }
    }
}
