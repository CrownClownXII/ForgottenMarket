using System;

namespace OrderAPI.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}