using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebAPI.Controllers
{
    [IgnoreAntiforgeryToken]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getOrder = await _orderService.Get();
            return Ok(getOrder);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getOrder = await _orderService.Get(id);

            if (getOrder == null)
                return NotFound("Not Found");

            return Ok(getOrder);
        }
        // vadim tomashevsky !!!!!!!!
        // POST api/<ItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            try
            {
                var dbOrder = await _orderService.Inseret(order);

                return Ok(dbOrder);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("orderHistory")]
        public async Task<IActionResult> Post([FromBody] string email)
        {
            try
            {
                var dbOrder = await _orderService.GetHistoryOrders(email);

                return Ok(dbOrder);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Order order)
        {

            try
            {
                var getOrder = await _orderService.Update(id, order);

                if (getOrder == null)
                    return NotFound("Not Found");

                return Ok(getOrder);

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _orderService.Delete(id);
                if (item == 0)
                    return NotFound("Not Found");

                return Ok("Order deleted");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }
    }
}
