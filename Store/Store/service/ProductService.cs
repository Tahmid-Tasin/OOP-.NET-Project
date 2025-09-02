using System.Collections.Generic;
using Store.Repository;



namespace Store.service
{
    public class ProductService
    {
        private readonly ProductRepository _repo;

        public ProductService()
        {
            _repo = new ProductRepository();
        }

        public int Register(Product p) => _repo.Insert(p);

        public int Update(Product p) => _repo.Update(p);

        public int Delete(int id) => _repo.Delete(id);

        public Product GetById(int id) => _repo.Get(id);

        public List<Product> GetAll() => _repo.GetAll();
    }
}

