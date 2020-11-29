using OrderAPI.DAL.Model;
using MediatR;

namespace OrderAPI.Services.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
}