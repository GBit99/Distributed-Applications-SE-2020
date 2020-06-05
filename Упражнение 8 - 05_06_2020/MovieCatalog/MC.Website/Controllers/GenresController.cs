using System;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using GenresReference;
using MC.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace MC.Website.Controllers
{
    public class GenresController : Controller
    {
        // GET: Genres
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            GenresClient genresClient = new GenresClient();

            var genres = await genresClient.GetAllAsync();

            var result = genres
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToArray();

            await genresClient.CloseAsync();

            return View(result);
        }

        // GET: Genres/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            GenresClient genresClient = new GenresClient();

            var genre = await genresClient.GetByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            var result = new GenreViewModel
            {
                Id = genre.Id,
                Name = genre.Name
            };

            await genresClient.CloseAsync();

            return View(result);
        }

        // GET: Genres/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        public async Task<ActionResult> Create(GenreViewModel genre)
        {
            try
            {
                GenresClient genresClient = new GenresClient();

                var genreDto = new GenreDto
                {
                    Id = genre.Id,
                    Name = genre.Name
                };

                await genresClient.CreateAsync(genreDto);

                await genresClient.CloseAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Genres/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            GenresClient genresClient = new GenresClient();

            var genre = await genresClient.GetByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            var result = new GenreViewModel
            {
                Id = genre.Id,
                Name = genre.Name
            };

            await genresClient.CloseAsync();

            return View(result);
        }

        // POST: Genres/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, GenreViewModel genre)
        {
            genre.Id = id;

            try
            {
                GenresClient genresClient = new GenresClient();

                var genreDto = new GenreDto
                {
                    Id = genre.Id,
                    Name = genre.Name
                };

                await genresClient.UpdateAsync(genreDto);

                await genresClient.CloseAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Genres/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            GenresClient genresClient = new GenresClient();

            var genre = await genresClient.GetByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            var result = new GenreViewModel
            {
                Id = genre.Id,
                Name = genre.Name
            };

            await genresClient.CloseAsync();

            return View(result);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                GenresClient genresClient = new GenresClient();

                await genresClient.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}