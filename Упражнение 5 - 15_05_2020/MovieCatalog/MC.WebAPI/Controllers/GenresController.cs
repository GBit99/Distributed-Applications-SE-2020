﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MC.Business.DTOs;
using MC.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GenreService genreService;

        public GenresController()
        {
            this.genreService = new GenreService();
        }

        // GET: api/Genres
        [HttpGet]
        public IEnumerable<GenreDto> GetAll()
        {
            return genreService.GetAll();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public ActionResult<GenreDto> Get([FromRoute] int id)
        {
            var result = genreService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Genres
        [HttpPost]
        public IActionResult Create([FromBody] GenreDto genre)
        {
            if (!genre.IsValid())
            {
                return BadRequest();
            }

            if (genreService.Create(genre))
            {
                return NoContent();
            }

            return BadRequest();
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] GenreDto genre)
        {
            if (!genre.IsValid())
            {
                return BadRequest();
            }

            genre.Id = id;

            if (genreService.Update(genre))
            {
                return NoContent();
            }

            return BadRequest();
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (genreService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
