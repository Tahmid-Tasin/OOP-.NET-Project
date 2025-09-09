using System.Collections.Generic;
using Store.Repository;

namespace Store.service
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repo;

        public EmployeeService()
        {
            _repo = new EmployeeRepository();
        }

        public int Register(Employee e) => _repo.Insert(e);

        public Employee GetById(int id) => _repo.Get(id);
        
        public bool VerifyLogin(string email, string password) => _repo.Verify(email, password);

        public List<Employee> GetAll() => _repo.GetAll();
        
        public List<Employee> Search(string name, string mobile, int? outletId = null) 
            => _repo.Search(name, mobile, outletId);

        public int Update(Employee e) => _repo.UpdateNoPassword(e);

        public int Delete(int id) => _repo.Delete(id);
    }
}
