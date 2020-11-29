using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductAPI.DAL.Data;
using ProductAPI.DAL.Model;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IDataStore _dataSource;
        
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IDataStore dataSource)
        {
            _logger = logger;
            _dataSource = dataSource;
        }

        [HttpGet("read")]
        public async Task<IReadOnlyList<Product>> Get()
        {
            var result = await _dataSource.ProductRepository.FindById(Guid.NewGuid());

            return result;
        }

        [HttpGet("put")]
        public async Task<string> Get2()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test No. 1"
            };

            _dataSource.ProductRepository.Add(product);
            await _dataSource.CommitChanges();

            return "Ok";
        }
    }
}
