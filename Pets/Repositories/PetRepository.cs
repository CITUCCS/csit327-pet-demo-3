using Microsoft.EntityFrameworkCore;
using Pets.Contexts;
using Pets.Models;

namespace Pets.Repositories
{
    public class PetRepository : IRepository<Pet>
    {
        private readonly DataContext _context;

        public PetRepository(DataContext context)
        {
            _context = context;
        }

        public Pet Get(int id)
        {
            return _context.Pets
                .Where(p => p.Id == id)
                .Include(p => p.Details) // Fetch dependent entity
                .Include(p => p.Owner)
                .FirstOrDefault();
        }

        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets
                .Include(p => p.Details) // Fetch dependent entity
                .Include(p => p.Owner)
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
            pet.Owner = updatePet.Owner;
            _context.SaveChanges();
        }
    }
}
