using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobiliva.Business.Contracts;
using Mobiliva.Models;

namespace Mobiliva.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest orderRequest)
        {       
            var data = _orderRepository.CreateOrder(orderRequest);
            return Ok(data);
        }

    }
}
