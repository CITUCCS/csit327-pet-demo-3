using Pets.Dto;
using Pets.Models;
using Pets.Repositories;

namespace Pets.Services
{
    public class PetService : IPetService
    {
        private readonly IRepository<Pet> _repository;

        public PetService(IRepository<Pet> repository)
        {
            _repository = repository;
        }
        public void AddPet(CreatePetDto petDto)
        {
            var petHasSameName = _repository
                .GetAll()
                .Where(p => p.Name!.Equals(petDto.Name))
                .FirstOrDefault() != null;

            if (petHasSameName) 
                throw new Exception("Pet name already exists!");

            var petModel = new Pet
            {
                Name = petDto.Name,
                Age = petDto.Age,
                Details = new PetDetails
                {
                    Type = petDto.Type,
                    Biography = petDto.Biography
                }
            };

            _repository.Add(petModel);
        }

        public void Delete(int id)
        {
            var desiredPet = _repository.Get(id);
            
            if (desiredPet == null)
            {
                throw new Exception($"No pet with id {id} exists.");
            }

            _repository.Delete(desiredPet);
        }

        public IEnumerable<PetDto> GetAllPets()
        {
            var pets = _repository.GetAll();
            return pets.Select(p => new PetDto {
                Id = p.Id,
                Age = p.Age,
                Name = p.Name,
                Biography = p.Details.Biography,
                Type = p.Details.Type
            });
        }

        public PetDto GetPetById(int id)
        {
            var petModel = _repository.Get(id);
            return new PetDto
            {
                Id = petModel.Id,
                Name = petModel.Name,
                Age = petModel.Age,
                Biography = petModel.Details.Biography,
                Type = petModel.Details.Type
            };
        }

        public PetDto Update(PetDto petDto)
        {
            var desiredPet = _repository.Get(petDto.Id);

            if (desiredPet == null)
            {
                _repository.Add(new Pet {
                    Name = petDto.Name,
                    Id = petDto.Id,
                    Age = petDto.Age,
                    Details = new PetDetails
                    {
                        Type = petDto.Type,
                        Biography = petDto.Biography
                    }
                });
                return petDto;
            }
            else
            {
                _repository.Update(desiredPet, new Pet {
                    Name = petDto.Name,
                    Id = petDto.Id,
                    Age = petDto.Age,
                    Details = new PetDetails
                    {
                        Type = petDto.Type,
                        Biography = petDto.Biography
                    }
                });
                
                return new PetDto 
                {
                    Id = desiredPet.Id,
                    Name = desiredPet.Name,
                    Age = desiredPet.Age,
                    Biography = desiredPet.Details.Biography,
                    Type = desiredPet.Details.Type
                };
            }
        }
    }
}
