using Pets.Dto;
using Pets.Models;
using Pets.Repositories;

namespace Pets.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository<Owner> _repository;
        private readonly IRepository<Pet> _petRepository;

        public OwnerService(IRepository<Owner> repository, IRepository<Pet> petRepository)
        {
            _repository = repository;
            _petRepository = petRepository;
        }

        public void AddOwner(CreateOwnerDto owner)
        {
            // Get all provided pets from DB
            var pets = owner.PetIds.Select(id => _petRepository.Get(id)).ToList();
            _repository.Add(new Owner
            {
                Name = owner.Name,
                Address = owner.Address,
                ContactInfo = owner.ContactInfo,
                Pets = pets // Assign pets here
            });
        }

        public void Delete(int id)
        {
            var desiredOwner = _repository.Get(id);

            if (desiredOwner == null)
            {
                throw new Exception($"No owner with id {id} exists.");
            }

            _repository.Delete(desiredOwner);
        }

        public IEnumerable<OwnerDto> GetAllOwners()
        {
            var owners = _repository.GetAll();
            return owners.Select(o => new OwnerDto
            {
                Id = o.Id,
                Name = o.Name,
                Address = o.Address,
                ContactInfo = o.ContactInfo,
                Pets = o.Pets.Select(petModel => new PetDto
                {
                    Id = petModel.Id,
                    Name = petModel.Name,
                    Age = petModel.Age,
                    Biography = petModel.Details?.Biography ?? String.Empty,
                    Type = petModel.Details?.Type ?? String.Empty,
                    Owner = petModel.Owner?.Name ?? String.Empty
                }).ToList()
            });
        }

        public OwnerDto GetOwnerById(int id)
        {
            var o = _repository.Get(id);
            return new OwnerDto
            {
                Id = o.Id,
                Name = o.Name,
                Address = o.Address,
                ContactInfo = o.ContactInfo,
                Pets = o.Pets.Select(petModel => new PetDto
                {
                    Id = petModel.Id,
                    Name = petModel.Name,
                    Age = petModel.Age,
                    Biography = petModel.Details?.Biography ?? String.Empty,
                    Type = petModel.Details?.Type ?? String.Empty,
                    Owner = petModel.Owner?.Name ?? String.Empty
                }).ToList()
            };
        }

        public OwnerDto Update(OwnerDto owner)
        {
            var desiredOwner = _repository.Get(owner.Id);
            
            // Get all provided pets from DB
            var pets = owner.Pets.Select(pet => _petRepository.Get(pet.Id)).ToList();
            
            if (desiredOwner == null)
            {
                _repository.Add(new Owner
                {
                    Name = owner.Name,
                    Address = owner.Address,
                    ContactInfo = owner.ContactInfo,
                    Pets = pets // Assign pets here
                });
                return owner;
            }
            else
            {
                _repository.Update(desiredOwner, new Owner
                {
                    Name = owner.Name,
                    Address = owner.Address,
                    ContactInfo = owner.ContactInfo,
                    Pets = pets
                });
            }

            return new OwnerDto
            {
                Id = desiredOwner.Id,
                Name = desiredOwner.Name,
                Address = desiredOwner.Address,
                ContactInfo = desiredOwner.ContactInfo,
                Pets = desiredOwner.Pets.Select(petModel => new PetDto
                {
                    Id = petModel.Id,
                    Name = petModel.Name,
                    Age = petModel.Age,
                    Biography = petModel.Details?.Biography ?? String.Empty,
                    Type = petModel.Details?.Type ?? String.Empty,
                    Owner = petModel.Owner?.Name ?? String.Empty
                }).ToList()
            };

        }
    }
}
