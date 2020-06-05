using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MC.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MC.Website.Controllers
{
    public class MoviesController : Controller
    {
        private const string JSON_MEDIA_TYPE = "application/json";
        private const string AUTHORIZATION_HEADER_NAME = "Authorization";
        private readonly Uri tokenUri = new Uri("https://localhost:44376/api/login");
        private readonly Uri moviesUri = new Uri("https://localhost:44376/api/movies");
        private readonly Uri genresUri = new Uri("https://localhost:44376/api/genres");
        private readonly Uri directorsUri = new Uri("https://localhost:44376/api/directors");

        // GET: Movies
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage response = await client.GetAsync(moviesUri);

                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Error), "Home");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var responseData = JsonConvert.DeserializeObject<IEnumerable<MovieViewModel>>(jsonResponse);

                return View(responseData);
            }
        }

        // GET: Movies/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage response = await client.GetAsync($"{moviesUri}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Error), "Home");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var responseData = JsonConvert.DeserializeObject<MovieViewModel>(jsonResponse);

                return View(responseData);
            }
        }

        // GET: Movies/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.Genres = await GetGenresDropdownItemsAsync();
            ViewBag.Directors = await GetDirectorsDropdownItemsAsync();

            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public async Task<ActionResult> Create(MovieViewModel movie)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var token = await GetAccessToken();
                    client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                    var serializedContent = JsonConvert.SerializeObject(movie);
                    var stringContent = new StringContent(serializedContent, Encoding.UTF8, JSON_MEDIA_TYPE);

                    HttpResponseMessage response = await client.PostAsync(moviesUri, stringContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(HomeController.Error), "Home");
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
        }

        // GET: Movies/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage response = await client.GetAsync($"{moviesUri}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Error), "Home");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var responseData = JsonConvert.DeserializeObject<MovieViewModel>(jsonResponse);

                ViewBag.Genres = await GetGenresDropdownItemsAsync();
                ViewBag.Directors = await GetDirectorsDropdownItemsAsync();

                return View(responseData);
            }
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, MovieViewModel movie)
        {
            movie.Id = id;

            try
            {
                using (var client = new HttpClient())
                {
                    var token = await GetAccessToken();
                    client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                    var serializedContent = JsonConvert.SerializeObject(movie);
                    var stringContent = new StringContent(serializedContent, Encoding.UTF8, JSON_MEDIA_TYPE);

                    HttpResponseMessage response = await client.PutAsync($"{moviesUri}/{id}", stringContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(HomeController.Error), "Home");
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
        }

        // GET: Movies/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage response = await client.GetAsync($"{moviesUri}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Error), "Home");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var responseData = JsonConvert.DeserializeObject<MovieViewModel>(jsonResponse);

                return View(responseData);
            }
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var token = await GetAccessToken();
                    client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                    HttpResponseMessage response = await client.DeleteAsync($"{moviesUri}/{id}");

                    if (!response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(HomeController.Error), "Home");
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
        }


        private async Task<IEnumerable<SelectListItem>> GetGenresDropdownItemsAsync()
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage genresResponse = await client.GetAsync(genresUri);

                if (!genresResponse.IsSuccessStatusCode)
                {
                    return Enumerable.Empty<SelectListItem>();
                }

                string genresJsonResponse = await genresResponse.Content.ReadAsStringAsync();

                var genres = JsonConvert.DeserializeObject<IEnumerable<GenreViewModel>>(genresJsonResponse);

                return genres.Select(genre => new SelectListItem(genre.Name, genre.Id.ToString()));
            }
        }

        private async Task<IEnumerable<SelectListItem>> GetDirectorsDropdownItemsAsync()
        {
            using (var client = new HttpClient())
            {
                var token = await GetAccessToken();
                client.DefaultRequestHeaders.Add(AUTHORIZATION_HEADER_NAME, token);

                HttpResponseMessage directorsResponse = await client.GetAsync(directorsUri);

                if (!directorsResponse.IsSuccessStatusCode)
                {
                    return Enumerable.Empty<SelectListItem>();
                }

                string directorsJsonResponse = await directorsResponse.Content.ReadAsStringAsync();

                var directors = JsonConvert.DeserializeObject<IEnumerable<DirectorViewModel>>(directorsJsonResponse);

                return directors.Select(director => new SelectListItem($"{director.FirstName} {director.LastName}", director.Id.ToString()));
            }
        }

        private async Task<string> GetAccessToken()
        {
            using (var client = new HttpClient())
            {
                var serializedContent = JsonConvert.SerializeObject(new { Username = "test1Username", Password = "test1Password" });
                var stringContent = new StringContent(serializedContent, Encoding.UTF8, JSON_MEDIA_TYPE);

                HttpResponseMessage response = await client.PostAsync(tokenUri, stringContent);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                return $"Bearer {await response.Content.ReadAsStringAsync()}";
            }
        }
    }
}