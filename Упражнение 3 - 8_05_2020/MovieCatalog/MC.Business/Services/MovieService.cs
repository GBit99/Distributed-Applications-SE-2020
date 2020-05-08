using System;
using System.Collections.Generic;
using System.Linq;
using MC.Business.DTOs;
using MC.Data;
using MC.Models.Entities;

namespace MC.Business.Services
{
    public class MovieService
    {
        public IEnumerable<MovieDto> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var movies = unitOfWork.MovieRepository.GetAll();

                var result = movies.Select(movie => new MovieDto
                {
                    Id = movie.Id,
                    Rating = movie.Rating,
                    Title = movie.Title,
                    Director = new DirectorDto
                    {
                        Id = movie.DirectorId,
                        FirstName = movie.Director.FirstName,
                        LastName = movie.Director.LastName
                    },
                    Genre = new GenreDto
                    {
                        Id = movie.GenreId,
                        Name = movie.Genre.Name
                    }
                }).ToList();

                return result;
            }
        }

        public MovieDto GetById(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var movie = unitOfWork.MovieRepository.GetById(id);

                return movie == null ? null : new MovieDto
                {
                    Id = movie.Id,
                    Rating = movie.Rating,
                    Title = movie.Title,
                    Director = new DirectorDto
                    {
                        Id = movie.DirectorId,
                        FirstName = movie.Director.FirstName,
                        LastName = movie.Director.LastName
                    },
                    Genre = new GenreDto
                    {
                        Id = movie.GenreId,
                        Name = movie.Genre.Name
                    }
                };
            }
        }

        public bool Create(MovieDto movieDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var movie = new Movie()
                {
                    Rating = movieDto.Rating,
                    GenreId = movieDto.Genre.Id,
                    DirectorId = movieDto.Director.Id,
                    Title = movieDto.Title,
                    CreatedOn = DateTime.Now
                };

                unitOfWork.MovieRepository.Create(movie);

                return unitOfWork.Save();
            }
        }

        public bool Update(MovieDto movieDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.MovieRepository.GetById(movieDto.Id);

                if (result == null)
                {
                    return false;
                }

                result.GenreId = movieDto.Genre.Id;
                result.DirectorId = movieDto.Director.Id;
                result.Rating = movieDto.Rating;
                result.Title = movieDto.Title;
                result.UpdatedOn = DateTime.Now;

                unitOfWork.MovieRepository.Update(result);

                return unitOfWork.Save();
            }
        }

        public bool Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Movie result = unitOfWork.MovieRepository.GetById(id);

                if (result == null)
                {
                    return false;
                }

                unitOfWork.MovieRepository.Delete(result);

                return unitOfWork.Save();
            }
        }
    }
}
