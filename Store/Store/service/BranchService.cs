using System.Collections.Generic;
using Store.Repository;

namespace Store.Service
{
    public class BranchService
    {
        private readonly BranchRepository _branchRepo;

        public BranchService()
        {
            _branchRepo = new BranchRepository();
        }

        public int Create(Branch branch) => _branchRepo.Insert(branch);

        public int Update(Branch branch) => _branchRepo.Update(branch);

        public int Delete(int id) => _branchRepo.Delete(id);

        public List<Branch> GetByOutlet(int outletId) => _branchRepo.GetByOutlet(outletId);
    }
}
