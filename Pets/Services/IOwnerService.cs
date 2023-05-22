using Pets.Dto;

namespace Pets.Services
{
    public interface IOwnerService
    {
        IEnumerable<OwnerDto> GetAllOwners();
        OwnerDto GetOwnerById(int id);
        void AddOwner(CreateOwnerDto owner);
        OwnerDto Update(OwnerDto owner);
        void Delete(int id);
    }
}
