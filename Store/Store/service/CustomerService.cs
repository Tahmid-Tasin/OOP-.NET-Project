using Store.Repository;

namespace Store.service
{
    public class CustomerService
    {
        private readonly CustomerRepository _repo;

        public CustomerService()
        {
            _repo = new CustomerRepository();
        }

        public bool VerifyLogin(string fullName, string password)
        {
            return _repo.Verify(fullName, password);
        }

        public Customer GetByUserName(string full_name)
        {
            return _repo.Get(full_name);
        }


        public int Register(Customer a)
        {
            return _repo.Insert(a);
        }
    }
}
