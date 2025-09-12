using Store.Repository;
using System.Collections.Generic;

namespace Store.service
{
    public class InventoryService
    {
        private readonly InventoryRepository _repo;

        public InventoryService()
        {
            _repo = new InventoryRepository();
        }

        /// <summary>
        /// Add or update inventory for a product in a branch of a company.
        /// If already exists, update the quantity. Otherwise, insert new.
        /// </summary>
        public int AddOrUpdate(Inventory inv)
        {
            // Upsert method in repository already handles both insert & update
            return _repo.Upsert(inv);
        }

        /// <summary>
        /// Remove inventory record by ID
        /// </summary>
        public int Remove(int id)
        {
            return _repo.Delete(id);
        }

        /// <summary>
        /// Get single inventory item (with eager-loaded Company, Branch, Product)
        /// </summary>
        public Inventory GetById(int id)
        {
            return _repo.Get(id);
        }

        /// <summary>
        /// Get all inventory records
        /// </summary>
        public List<Inventory> GetAll()
        {
            return _repo.GetAll();
        }

        /// <summary>
        /// Search inventory with optional filters
        /// </summary>
        public List<Inventory> Search(int? companyId = null, int? branchId = null,
            int? productId = null, decimal? minQty = null, decimal? maxQty = null)
        {
            return _repo.Search(companyId, branchId, productId, minQty, maxQty);
        }
    }
}
