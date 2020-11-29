using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderAPI.DAL.Data;
using OrderAPI.DAL.Model;

namespace OrderAPI.Services.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly OrderContext _context;

        public CreateOrderCommandHandler(OrderContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _context.Orders.AddAsync(request.Order);
            await _context.SaveChangesAsync();

            return request.Order;
        }
    }
}