using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderAPI.DAL.Data;
using OrderAPI.DAL.Model;
using OrderAPI.Dtos;

namespace OrderAPI.Services.Queries
{
    public class FindAllOrdersQueryHandler :  IRequestHandler<FindAllOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly OrderContext _context;
        private readonly IMapper _mapper;

        public FindAllOrdersQueryHandler(OrderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(FindAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Orders.ToListAsync();

            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(result);
        }
    }
}