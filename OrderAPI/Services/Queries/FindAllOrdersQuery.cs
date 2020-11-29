using System.Collections.Generic;
using MediatR;
using OrderAPI.Dtos;

namespace OrderAPI.Services.Queries
{
    public class FindAllOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
        
    }
}