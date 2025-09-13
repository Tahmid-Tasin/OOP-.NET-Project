// File: service/CustomerService.cs
using Store.Repository;

namespace Store.service
{
    public class CustomerService
    {
        private readonly CustomerRepository _repo;

        public CustomerService() => _repo = new CustomerRepository();

        public bool VerifyLogin(string userOrEmail, string password)
            => _repo.VerifyFlexible(userOrEmail?.Trim(), password?.Trim());

        public Customer GetByLoginKey(string userOrEmail)
            => _repo.GetByLoginKey(userOrEmail?.Trim());

        // Legacy (kept if other screens depend on it)
        public Customer GetByUserName(string full_name) => _repo.GetByFullName(full_name);

        public int Register(Customer a) => _repo.Insert(a);
    }
}
