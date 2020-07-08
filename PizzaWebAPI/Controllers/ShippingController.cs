using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ShippingController : ControllerBase
        {
            private readonly IShippingService _shippingService;
            public ShippingController(IShippingService shippingService)
            {
                _shippingService = shippingService;
            }

            // GET: api/<ItemsController>
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var getShipping = await _shippingService.Get();
                return Ok(getShipping);
            }

            // GET api/<ItemsController>/5
            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                var getShipping = await _shippingService.Get(id);

                if (getShipping == null)
                    return NotFound("Not Found");

                return Ok(getShipping);
            }

            // POST api/<ItemsController>
            [HttpPost]
            public async Task<IActionResult> Post([FromBody] Shipping shipping)
            {
                try
                {
                    if (shipping.Title == null)
                        return BadRequest("Please inseret title");

                    var dbShipping = await _shippingService.Inseret(shipping);

                    return Ok(dbShipping);
                }
                catch (Exception exception)
                {
                    return BadRequest(exception.Message);
                }
            }

            // PUT api/<ItemsController>/5
            [HttpPut("{id}")]
            public async Task<IActionResult> Put(int id, [FromBody] Shipping shipping)
            { 

                try
                {
                    var getShipping = await _shippingService.Update(id, shipping);

                    if (getShipping == null)
                        return NotFound("Not Found");

                    return Ok(getShipping);
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
                    var item = await _shippingService.Delete(id);
                    if (item == 0)
                        return NotFound("Not Found");

                    return Ok("Shipping deleted");
                }
                catch (Exception exception)
                {
                    return BadRequest(exception.Message);

                }
            }
        }
    }


