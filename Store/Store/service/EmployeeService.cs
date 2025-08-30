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

        public bool VerifyLogin(string mobile, string password) => _repo.Verify(mobile, password);

        public List<Employee> GetAll() => _repo.GetAll();
        
        public List<Employee> Search(string name, string mobile) => _repo.Search(name, mobile);
        
        public int Update(Employee e)
        {
            return _repo.UpdateNoPassword(e);
        }

        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
