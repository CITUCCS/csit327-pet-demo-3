using Microsoft.EntityFrameworkCore;
using Pets.Contexts;
using Pets.Models;

namespace Pets.Repositories
{
    public class PetRepository : IRepository<Pet>
    {
        private readonly PetContext _context;

        public PetRepository(PetContext context)
        {
            _context = context;
        }

        public Pet Get(int id)
        {
            return _context.Pets
                .Where(p => p.Id == id)
                .Include(p => p.Details) // Fetch dependent entity
                .FirstOrDefault();
        }

        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets
                .Include(p => p.Details) // Fetch dependent entity
                .ToList();
        }

        public void Add(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public void Delete(Pet pet)
        {
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }

        public void Update(Pet pet, Pet updatePet)
        {
            pet.Name = updatePet.Name;
            pet.Age = updatePet.Age;
            pet.Details.Type = updatePet.Details.Type;
            pet.Details.Biography = updatePet.Details.Biography;
            _context.SaveChanges();
        }
    }
}
