using Store.Repository;

namespace Store.service
{
    public class AdminService
    {
        private readonly AdminRepository _repo;

        public AdminService()
        {
            _repo = new AdminRepository();
        }

        public bool VerifyLogin(string userName, string password)
        {
            return _repo.Verify(userName, password);
        }

        public Admin GetByUserName(string userName)
        {
            return _repo.Get(userName);
        }

        public int Register(Admin a)
        {
            return _repo.Insert(a);
        }
    }
}
