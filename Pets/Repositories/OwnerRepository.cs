using Microsoft.EntityFrameworkCore;
using Pets.Contexts;
using Pets.Models;

namespace Pets.Repositories
{
    public class OwnerRepository : IRepository<Owner>
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public Owner Get(int id)
        {
            return _context.Owners
                .Where(p => p.Id == id)
                .Include(o => o.Pets) // Fetch dependent entity
                .FirstOrDefault();
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners
                .Include(o => o.Pets)
                .ToList();
        }

        public void Add(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }

        public void Delete(Owner owner)
        {
            _context.Owners.Remove(owner);
            _context.SaveChanges();
        }

        public void Update(Owner owner, Owner updateOwner)
        {
            owner.Name = updateOwner.Name;
            owner.ContactInfo = updateOwner.ContactInfo;
            owner.Address = updateOwner.Address;
            owner.Pets = updateOwner.Pets;
            _context.SaveChanges();
        }
    }
}
