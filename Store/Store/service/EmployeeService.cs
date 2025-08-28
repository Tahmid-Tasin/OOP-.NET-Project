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

        public int Register(Employee e)
        {
            return _repo.Insert(e);
        }

        public Employee GetById(int id)
        {
            return _repo.Get(id);
        }

        public bool VerifyLogin(string mobile, string password)
        {
            return _repo.Verify(mobile, password);
        }
    }
}
