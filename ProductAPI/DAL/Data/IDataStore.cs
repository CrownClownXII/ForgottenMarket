using System;
using System.Threading.Tasks;
using ProductAPI.DAL.Repository;

namespace ProductAPI.DAL.Data
{
    public interface IDataStore : IDisposable
    {      
		IProductRepository ProductRepository { get; }
		Task CommitChanges();
    }
}