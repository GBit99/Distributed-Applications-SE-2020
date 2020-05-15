using System;
using System.Collections.Generic;
using System.Linq;
using MC.Business.DTOs;
using MC.Data;
using MC.Models.Entities;

namespace MC.Business.Services
{
    public class DirectorService
    {
        public IEnumerable<DirectorDto> GetAllByFirstName(string firstName)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var directors = unitOfWork.DirectorRepository.GetAll(d => d.FirstName == firstName);

                return directors.Select(director => new DirectorDto
                {
                    Id = director.Id,
                    FirstName = director.FirstName,
                    LastName = director.LastName
                });
            }
        }

        public IEnumerable<DirectorDto> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var directors = unitOfWork.DirectorRepository.GetAll();

                return directors.Select(director => new DirectorDto
                {
                    Id = director.Id,
                    FirstName = director.FirstName,
                    LastName = director.LastName
                });
            }
        }

        public DirectorDto GetById(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var director = unitOfWork.DirectorRepository.GetById(id);

                return director == null ? null : new DirectorDto
                {
                    Id = director.Id,
                    FirstName = director.FirstName,
                    LastName = director.LastName
                };
            }
        }

        public bool Create(DirectorDto directorDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var director = new Director()
                {
                    FirstName = directorDto.FirstName,
                    LastName = directorDto.LastName,
                    CreatedOn = DateTime.Now
                };

                unitOfWork.DirectorRepository.Create(director);

                return unitOfWork.Save();
            }
        }

        public bool Update(DirectorDto directorDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.DirectorRepository.GetById(directorDto.Id);

                if (result == null)
                {
                    return false;
                }

                result.FirstName = directorDto.FirstName;
                result.LastName = directorDto.LastName;
                result.UpdatedOn = DateTime.Now;

                unitOfWork.DirectorRepository.Update(result);

                return unitOfWork.Save();
            }
        }

        public bool Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Director result = unitOfWork.DirectorRepository.GetById(id);

                if (result == null)
                {
                    return false;
                }

                unitOfWork.DirectorRepository.Delete(result);

                return unitOfWork.Save();
            }
        }
    }
}
