using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesItemController : ControllerBase
    {
        private readonly IImagesItemService _imagesItemService;
        public ImagesItemController(IImagesItemService imagesItemService)
        {
            _imagesItemService = imagesItemService;
        }

        // GET: api/<ImagesItemController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getImagesItem = await _imagesItemService.Get();
            return Ok(getImagesItem);
        }

        // GET api/<ImagesItemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getImagesItem = await _imagesItemService.Get(id);

            if (getImagesItem == null)
                return NotFound("Not Found");

            return Ok(getImagesItem);
        }

        // POST api/<ImagesItemController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ImagesItem imagesItem)
        {
            try
            {
                //if (imagesItem.ImageId == 0 && imagesItem.ItemId == 0)
                    //return BadRequest("Upload pizza");

                //else if (pizzaImages.Image == null && pizzaImages.ImageId == 0)
                //    return BadRequest("Upload image");

                var dbImagesItem = await _imagesItemService.Inseret(imagesItem);

                return Ok(dbImagesItem);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/<ImagesItemController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ImagesItem imagesItem)
        {

            try
            {
                var getImagesItem = await _imagesItemService.Update(id, imagesItem);

                if (getImagesItem == null)
                    return NotFound("Not Found");

                return Ok(getImagesItem);

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // DELETE api/<ImagesItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pizzaImages = await _imagesItemService.Delete(id);
                if (pizzaImages == 0)
                    return NotFound("Not Found");

                return Ok("ImagesItem deleted");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }
    }
}
