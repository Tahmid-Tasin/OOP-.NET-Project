// File: service/EmployeeService.cs
using System.Collections.Generic;

using Store.model;
using Store.repository;
using Store.Repository;

namespace Store.service
{
    internal class ReviewService
    {
        private readonly ReviewRepository _repo;

        public ReviewService() => _repo = new ReviewRepository();

        public int Register(Review r) => _repo.Insert(r);
        public List<Review> GetAll() => _repo.GetAll();
    }
}
