using System.Collections.Generic;
using Store.Repository;

namespace Store.service
{
    public class BranchService
    {
        private readonly BranchRepository _repo;

        public BranchService()
        {
            _repo = new BranchRepository();
        }

        // Create new branch
        public int Register(Branch b)
        {
            return _repo.Insert(b);
        }

        // Get branch by ID
        public Branch GetById(int id)
        {
            return _repo.Get(id);
        }

        // Get all branches
        public List<Branch> GetAll()
        {
            return _repo.GetAll();
        }

        // Get all branches for a specific company
        public List<Branch> GetByCompany(int companyId)
        {
            return _repo.GetByCompany(companyId);
        }

        // Update branch
        public int Update(Branch b)
        {
            return _repo.Update(b);
        }

        // Delete branch
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }

        // Search branches by optional filters
        public List<Branch> Search(string name, string city, string phone, string postalCode, int? companyId = null)
        {
            return _repo.Search(name, city, phone, postalCode, companyId);
        }
    }
}
