using System;

namespace OrderAPI.Dtos
{
    public class CreateOrderDto
    {
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}