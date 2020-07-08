using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BL;
using Common;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly ImagesService _imagesService;
        public ImagesController(ImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        //GET: api/<ImagesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getImages = await _imagesService.Get();
            return Ok(getImages);
        }

        // GET api/<ImagesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getImage = await _imagesService.Get(id);

            if (getImage == null)
                return NotFound("Not Found");

            return Ok(getImage);
        }

        // POST api/<ImagesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Image image)
        {
            try
            {
                //if (image.UrlImage == null || image.UploudImage == null)
                //    return BadRequest("Upload image");

                var dbImage = await _imagesService.Inseret(image);

                return Ok(dbImage);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/<ImagesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Image image)
        {

            try
            {
                var getImage = await _imagesService.Update(id, image);

                if (getImage == null)
                    return NotFound("Not Found");

                return Ok(getImage);

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // DELETE api/<ImagesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var images = await _imagesService.Delete(id);
                if (images == 0)
                    return NotFound("Not Found");

                return Ok("Image deleted");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }
    }
}
