using ProductManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Service.IService
{
    public interface IProductService
    {
        void AddProduct(string name, decimal price);
        IReadOnlyList<Product> GetAll();
        IReadOnlyList<Product> Search(string term);

        //
        void UpdateProduct(Guid id, string newName, decimal newPrice);
        bool DeleteProduct(Guid id);

    }
}