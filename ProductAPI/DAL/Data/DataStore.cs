using System.Threading.Tasks;
using ProductAPI.DAL.Repository;
using Marten;
using System;

namespace ProductAPI.DAL.Data
{
    public class DataStore : IDataStore
    {
        private readonly IDocumentSession _session;
        public IProductRepository ProductRepository { get; }
		
        public DataStore(IDocumentStore documentStore)
        {
            _session = documentStore.LightweightSession();
            ProductRepository = new ProductRepository(_session);
        }

        public async Task CommitChanges()
        {
            await _session.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
			{
				_session.Dispose();
			}
        }

        public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
    }
}