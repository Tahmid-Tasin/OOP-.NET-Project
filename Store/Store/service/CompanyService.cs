using System.Collections.Generic;
using Store.Repository;

namespace Store.service
{
    public class CompanyService
    {
        private readonly CompanyRepository _repo;

        public CompanyService()
        {
            _repo = new CompanyRepository();
        }

        // Create new company
        public int Register(Company c)
        {
            return _repo.Insert(c);
        }

        // Get company by ID
        public Company GetById(int id)
        {
            return _repo.Get(id);
        }

        // Get all companies
        public List<Company> GetAll()
        {
            return _repo.GetAll();
        }

        // Update company
        public int Update(Company c)
        {
            return _repo.Update(c);
        }

        // Delete company
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }

        // Search companies by optional filters
        public List<Company> Search(string name, string phone, string address, string city, string postalCode, string contactName)
        {
            return _repo.Search(name, phone, address, city, postalCode, contactName);
        }
    }
}
