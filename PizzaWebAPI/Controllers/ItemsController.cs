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
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getItem = await _itemService.Get();
            return Ok(getItem);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getItem = await _itemService.Get(id);

            if (getItem == null)
                return NotFound("Not Found");

            return Ok(getItem);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            try
            {
                if (item.Title == null)
                    return BadRequest("Please inseret name");

                var dbItem = await _itemService.Inseret(item);

                return Ok(dbItem);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Item item)
        {

            try
            {
                var getItem = await _itemService.Update(id, item);

                if (getItem == null)
                    return NotFound("Not Found");

                return Ok(getItem);

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
                var item = await _itemService.Delete(id);
                if (item == 0)
                    return NotFound("Not Found");

                return Ok("Item deleted");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }
    }
}
