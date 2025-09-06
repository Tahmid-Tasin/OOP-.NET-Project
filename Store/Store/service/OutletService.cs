using System.Collections.Generic;
using Store.Repository;

namespace Store.Service
{
    public class OutletService
    {
        private readonly OutletRepository _outletRepo;
        private readonly BranchRepository _branchRepo;

        public OutletService()
        {
            _outletRepo = new OutletRepository();
            _branchRepo = new BranchRepository();
        }

        // Create new outlet with multiple branches
        public int Create(Outlet outlet, List<Branch> branches)
        {
            int rows = _outletRepo.Insert(outlet);
            if (rows > 0 && branches != null)
            {
                // fetch the latest inserted outlet to get ID
                var outlets = _outletRepo.GetAll();
                int newOutletId = outlets[0].ID; // since GetAll is ordered DESC

                foreach (var b in branches)
                {
                    b.OutletID = newOutletId;
                    _branchRepo.Insert(b);
                }
            }
            return rows;
        }

        // Update outlet + replace its branches
        public int Update(Outlet outlet, List<Branch> branches)
        {
            int rows = _outletRepo.Update(outlet);

            if (rows > 0 && branches != null)
            {
                // remove all existing branches
                var oldBranches = _branchRepo.GetByOutlet(outlet.ID);
                foreach (var ob in oldBranches)
                {
                    _branchRepo.Delete(ob.ID);
                }

                // add new branch list
                foreach (var b in branches)
                {
                    b.OutletID = outlet.ID;
                    _branchRepo.Insert(b);
                }
            }
            return rows;
        }

        // Delete outlet (cascade will remove its branches)
        public int Delete(int outletId)
        {
            return _outletRepo.Delete(outletId);
        }

        // Get single outlet + its branches
        public Outlet Get(int outletId)
        {
            var outlet = _outletRepo.Get(outletId);
            if (outlet != null)
            {
                outlet.Branches = _branchRepo.GetByOutlet(outlet.ID);
            }
            return outlet;
        }

        // Get all outlets (without branches)
        public List<Outlet> GetAll()
        {
            return _outletRepo.GetAll();
        }

        // Get branches of an outlet
        public List<Branch> GetBranches(int outletId)
        {
            return _branchRepo.GetByOutlet(outletId);
        }
    }
}
