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
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryItemsController : ControllerBase
    {
        private readonly ICategoryItemsService _categoryItemsService;
        public CategoryItemsController(ICategoryItemsService categoryItemsService)
        {
            _categoryItemsService = categoryItemsService;
        }

        // GET: api/<CategoryItemsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getCategoryItems = await _categoryItemsService.Get();
            return Ok(getCategoryItems);
        }

        // GET api/<CategoryItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getCategoryItems = await _categoryItemsService.Get(id);

            if (getCategoryItems == null)
                return NotFound("Not Found");

            return Ok(getCategoryItems);
        }

        // POST api/<CategoryItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryItems categoryItems)
        {
            try
            {
                if (categoryItems.ItemId == 0 && categoryItems.CategoryId == 0)
                    return BadRequest("Please inseret valid Id");

                var dbCategoryItems = await _categoryItemsService.Inseret(categoryItems);

                return Ok(dbCategoryItems);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/<CategoryItemsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryItems categoryItems)
        {

            try
            {
                var getCategoryItems = await _categoryItemsService.Update(id, categoryItems);

                if (getCategoryItems == null)
                    return NotFound("Not Found");

                return Ok(getCategoryItems);

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // DELETE api/<CategoryItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoryItems = await _categoryItemsService.Delete(id);
                if (categoryItems == 0)
                    return NotFound("Not Found");

                return Ok("CategoryItems deleted");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }
    }
}
