using System.Collections.Generic;
using Store.Repository;

namespace Store.service
{
    public class OutletService
    {
        private readonly OutletRepository _repo;

        public OutletService()
        {
            _repo = new OutletRepository();
        }

        // Create new outlet
        public int Register(Outlet o)
        {
            return _repo.Insert(o);
        }

        // Get outlet by ID
        public Outlet GetById(int id)
        {
            return _repo.Get(id);
        }

        // Get all outlets
        public List<Outlet> GetAll()
        {
            return _repo.GetAll();
        }

        // Update outlet
        public int Update(Outlet o)
        {
            return _repo.Update(o);
        }

        // Delete outlet
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }

        // Search outlets by optional filters
        public List<Outlet> Search(string name, string phone, string address, string city, string postalCode, string contactName)
        {
            return _repo.Search(name, phone, address, city, postalCode, contactName);
        }
    }
}
