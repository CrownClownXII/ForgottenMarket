using System;

namespace CatalogAPI.DAL.Model
{
    public class CatalogItem
    {
        public long Id { get; set; }
        public string MainImageName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}