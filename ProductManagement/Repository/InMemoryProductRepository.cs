using ProductManagement.Entity;
using ProductManagement.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _items = new List<Product>();

        public void Add(Product p) => _items.Add(p);

        public IReadOnlyList<Product> GetAll() => _items.AsReadOnly();

        public IReadOnlyList<Product> SearchByName(string text) =>
            _items
              .Where(p => p.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
              .ToList();

        //
        public void Update(Product p)
        {
            var existing = _items.FirstOrDefault(x => x.Id == p.Id) ?? throw new InvalidOperationException("Product not found");
            existing.Name = p.Name;
            existing.Price = p.Price;
        }

        public bool RemoveById(Guid id)
        {
            var p = _items.FirstOrDefault(x => x.Id == id);
            if (p == null) return false;
            _items.Remove(p);
            return true;
        }
    }
}