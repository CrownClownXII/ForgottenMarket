using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderAPI.DAL.Model;
using OrderAPI.Dtos;
using OrderAPI.Services.Commands;
using OrderAPI.Services.Queries;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {       
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody]CreateOrderDto order)
        {
            try 
            {
                return await _mediator.Send(new CreateOrderCommand()
                {
                    Order = _mapper.Map<Order>(order)
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            try 
            {
                return new JsonResult(
                    await _mediator.Send(new FindAllOrdersQuery())
                );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
