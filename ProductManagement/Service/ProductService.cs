using ProductManagement.Entity;
using ProductManagement.Repository.IRepository;
using ProductManagement.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public void AddProduct(string name, decimal price)
        {
            var p = new Product(name, price);
            _repo.Add(p);
        }

        public IReadOnlyList<Product> GetAll() => _repo.GetAll();
        public IReadOnlyList<Product> Search(string term) => _repo.SearchByName(term);

        //
        public void UpdateProduct(Guid id, string newName, decimal newPrice)
        {
            var p = _repo.GetAll().FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException("Product not found");
            p.Name = newName;
            p.Price = newPrice;
            _repo.Update(p);
        }

        public bool DeleteProduct(Guid id)
        {
            return _repo.RemoveById(id);
        }

    }
}