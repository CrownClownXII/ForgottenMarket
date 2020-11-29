using System.Collections.Generic;
using ProductAPI.DAL.Model;
using System.Threading.Tasks;
using Marten;
using System;
using System.Linq;

namespace ProductAPI.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
		private readonly IDocumentSession _documentSession;

        
        public ProductRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }
        
        public void Add(Product product)
        {
	        _documentSession.Insert(product);
        }
        
        public void Update(Product product) 
        {
            _documentSession.Update(product);
        }

        public async Task<IReadOnlyList<Product>> FindById(Guid productId)
        {
            return await _documentSession.Query<Product>().ToListAsync();

            // return await _documentSession.Query<Product>()
            //     .FirstOrDefaultAsync(p => p.Id == productId);
        }
    }
}