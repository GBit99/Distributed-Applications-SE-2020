using System.Collections.Generic;
using MC.Business.DTOs;
using MC.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly DirectorService directorService;

        public DirectorsController()
        {
            this.directorService = new DirectorService();
        }

        // GET: api/Directors
        [HttpGet]
        public IEnumerable<DirectorDto> GetAll([FromQuery] string firstName)
        {
            return directorService.GetAll(firstName);
        }

        // GET: api/Directors/5
        [HttpGet("{id}")]
        public ActionResult<DirectorDto> Get([FromRoute] int id)
        {
            var result = directorService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Directors
        [HttpPost]
        public IActionResult Create([FromBody] DirectorDto directorDto)
        {
            if (directorService.Create(directorDto))
            {
                return NoContent();
            }

            return BadRequest();
        }

        // PUT: api/Directors/5
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] DirectorDto directorDto)
        {
            directorDto.Id = id;

            if (directorService.Update(directorDto))
            {
                return NoContent();
            }

            return BadRequest();
        }

        // DELETE: api/Directors/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (directorService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
