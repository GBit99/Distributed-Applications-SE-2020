using System.Collections.Generic;
using MC.Business.DTOs;
using MC.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService movieService;

        public MoviesController()
        {
            this.movieService = new MovieService();
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<MovieDto> GetAll()
        {
            return movieService.GetAll();
        }
         
        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<MovieDto> Get([FromRoute] int id)
        {
            var result = movieService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult Create([FromBody] MovieDto movie)
        {
            if (movieService.Create(movie))
            {
                return NoContent();
            }

            return BadRequest();
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] MovieDto movie)
        {
            movie.Id = id;

            if (movieService.Update(movie))
            {
                return NoContent();
            }

            return BadRequest();
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (movieService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
