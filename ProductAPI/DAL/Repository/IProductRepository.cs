using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductAPI.DAL.Model;

namespace ProductAPI.DAL.Repository
{
    public interface IProductRepository
    {
         void Add(Product product);
         void Update(Product product);
         Task<IReadOnlyList<Product>> FindById(Guid productId);
    }
}