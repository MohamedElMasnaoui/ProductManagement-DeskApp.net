using ProductManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.IRepository
{
    public interface IProductRepository
    {
        void Add(Product p);
        IReadOnlyList<Product> GetAll();
        IReadOnlyList<Product> SearchByName(string text);

        //
        void Update(Product p);
        bool RemoveById(Guid id);
    }
}