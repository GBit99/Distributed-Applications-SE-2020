using System;
using System.Collections.Generic;
using System.Linq;
using MC.Business.DTOs;
using MC.Data;
using MC.Models.Entities;

namespace MC.Business.Services
{
    public class GenreService
    {
        public IEnumerable<GenreDto> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var genres = unitOfWork.GenreRepository.GetAll();

                return genres.Select(genre => new GenreDto
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
        }

        public GenreDto GetById(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var genre = unitOfWork.GenreRepository.GetById(id);

                return genre == null ? null : new GenreDto
                {
                    Id = genre.Id,
                    Name = genre.Name
                };
            }
        }

        public bool Create(GenreDto genreDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var genre = new Genre()
                {
                    Id = genreDto.Id,
                    Name = genreDto.Name,
                    CreatedOn = DateTime.Now
                };

                unitOfWork.GenreRepository.Create(genre);

                return unitOfWork.Save();
            }
        }

        public bool Update(GenreDto genreDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.GenreRepository.GetById(genreDto.Id);

                if (result == null)
                {
                    return false;
                }

                result.Name = genreDto.Name;
                result.UpdatedOn = DateTime.Now;

                unitOfWork.GenreRepository.Update(result);

                return unitOfWork.Save();
            }
        }

        public bool Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Genre result = unitOfWork.GenreRepository.GetById(id);

                if (result == null)
                {
                    return false;
                }

                unitOfWork.GenreRepository.Delete(result);

                return unitOfWork.Save();
            }
        }
    }
}
