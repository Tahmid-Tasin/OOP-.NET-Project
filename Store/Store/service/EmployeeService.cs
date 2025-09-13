// File: service/EmployeeService.cs
using System.Collections.Generic;
using Store.Repository;

namespace Store.service
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repo;

        public EmployeeService() => _repo = new EmployeeRepository();

        public int Register(Employee e) => _repo.Insert(e);
        public Employee GetById(int id) => _repo.Get(id);

        public Employee GetByEmail(string email) => _repo.GetByEmail(email);
        public Employee GetByName(string name) => _repo.GetByName(name);
        public Employee GetByLoginKey(string userOrEmail) => _repo.GetByLoginKey(userOrEmail?.Trim());

        public bool VerifyLoginFlexible(string userOrEmail, string password)
            => _repo.VerifyFlexible(userOrEmail?.Trim(), password?.Trim());

        // Kept for compatibility (email-only)
        public bool VerifyLogin(string email, string password) => _repo.VerifyByEmail(email?.Trim(), password?.Trim());

        public List<Employee> GetAll() => _repo.GetAll();
        public List<Employee> Search(string name, string mobile, int? companyId = null)
            => _repo.Search(name, mobile, companyId);
        public int Update(Employee e) => _repo.UpdateNoPassword(e);
        public int Delete(int id) => _repo.Delete(id);
    }
}
