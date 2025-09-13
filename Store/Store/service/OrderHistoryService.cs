// NEW: Store/service/OrderHistoryService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Store.Repository;

namespace Store.service
{
    public class OrderHistoryService
    {
        private readonly OrderHistoryRepository _repo;
        private readonly ProductService _productService;

        public OrderHistoryService()
        {
            _repo = new OrderHistoryRepository();
            _productService = new ProductService();
        }

        /// <summary>
        /// Saves the provided cart snapshot into dbo.order_history.
        /// </summary>
        public void SaveCartSnapshot(Dictionary<Tuple<int,int,int>, int> cart)
        {
            if (cart == null || cart.Count == 0) return;

            var rows = new List<OrderHistory>();
            var currentUser = UserSession.Current;

            foreach (var kv in cart)
            {
                var companyId = kv.Key.Item1;
                var branchId  = kv.Key.Item2;
                var productId = kv.Key.Item3;
                var qty       = kv.Value;

                var p = _productService.GetById(productId);
                if (p == null || qty <= 0) continue;

                rows.Add(new OrderHistory
                {
                    CompanyId   = companyId,
                    BranchId    = branchId,
                    ProductId   = productId,
                    ProductName = p.NAME,
                    Quantity    = qty,
                    UnitPrice   = p.PRICE,
                    CreatedAt   = DateTime.UtcNow,
                    CustomerId  = currentUser?.UserId   // ✅ logged in customer
                });
            }

            if (rows.Count > 0)
                _repo.InsertBulk(rows);
        }

        
        // File: Store/service/OrderHistoryService.cs
        public List<OrderHistory> GetHistoryForCustomer(int customerId)
        {
            return _repo.GetByCustomer(customerId);
        }

        
        
    }
}
