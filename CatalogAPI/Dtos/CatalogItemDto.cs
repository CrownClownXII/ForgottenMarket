using Microsoft.AspNetCore.Http;

namespace CatalogAPI.Dtos
{
    public class CatalogItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}